using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BackupHelper
{
    public enum ListViewOptionSubItemIndex
    {
        INDEX_SOURCE_PATH = 0,
        INDEX_DESTINY_PATH = 1,
        INDEX_METHOD = 2,
        INDEX_MOVE_SUBFOLDER = 3,
        INDEX_KEEP_ORIGIN_FILES = 4,
        INDEX_CLEAN_DESTINY = 5,
        INDEX_REMOVE_COMMON = 6
    }

    public partial class FormOptionsMenu : Form
    {
        private readonly Profile Profile;
        private readonly FormProfileMenu ProfileMenu;
        public List<Option> Options;
        public FileControl FileControl;
        private Thread ExecutionThread;
        private readonly FormCancelExecution CancelExecutionForm;
        private bool OptionIsExecuting = false;

        //--FORM RESIZING VARIABLES
        private readonly int InitialFormHeight;
        private readonly int InitialFormWidth;
        private readonly int ListOptionHeight = 17;
        private readonly int AditionalListViewItemCount = 6;
        private readonly int InitialListViewItemCount = 10;
        private readonly int MaximumListViewItemCount;

        public FormOptionsMenu(FormProfileMenu profileMenu,Profile profile)
        {
            //this.listViewOptions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContextMenuStripOptionsList_Click);

            InitializeComponent();

            this.Profile = profile;
            this.ProfileMenu = profileMenu;
            this.CancelExecutionForm = new FormCancelExecution();
            this.Text = "Profile:  " + this.Profile.Name;
            if (profileMenu.LastReport != null)
                buttonShowResult.Enabled = true;

            InitialFormHeight = this.Bounds.Height;
            InitialFormWidth = this.Bounds.Width;
            AditionalListViewItemCount = 6;
            InitialListViewItemCount = 10;
            MaximumListViewItemCount = AditionalListViewItemCount + InitialListViewItemCount;

            LoadListView();
        }

        private void LoadListView()
        {
            try
            {
                OptionAccess optionAccess = new OptionAccess();
                this.Options = optionAccess.ListProfileOptions(this.Profile).OrderBy(x => x.ListViewIndex).ToList();

                foreach (Option option in this.Options)
                {
                    ListViewItem item = new ListViewItem();
                    EditListViewItem(item, option);
                    listViewOptions.Items.Add(item);
                }
                ResizeForm();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateOptionListViewIndexes()
        {
            OptionAccess oa = new OptionAccess();

            foreach (ListViewItem item in listViewOptions.Items)
            {
                Option option = Options.Find(x => x.Id == int.Parse(item.Tag.ToString()));
                int currentIndex = option.ListViewIndex;
                try
                {
                    option.ListViewIndex = item.Index;
                    oa.UpdateOptionListViewIndex(option);
                }
                catch (Exception)
                {
                    try
                    {
                        option.ListViewIndex = currentIndex;
                        oa.UpdateOptionListViewIndex(option);
                    }
                    catch (Exception) {}
                    throw;
                }
            }
        }

        private void ResizeForm()
        {
            //CHANGING FORM HEIGHT RESPONSIVELY DEPENDING ON NUMBER OF OPTIONS
            if (this.Options.Count() > InitialListViewItemCount && this.Options.Count() < MaximumListViewItemCount)
                this.Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (this.Options.Count() - InitialListViewItemCount) * ListOptionHeight);
            else if (this.Options.Count() >= MaximumListViewItemCount)
                this.Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (ListOptionHeight * AditionalListViewItemCount));
            else if (this.Bounds.Height != InitialFormHeight)
                this.Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight);
        }

        private void ButtonAddOption_Click(object sender, EventArgs args)
        {
            try
            {
                Option opt = new Option
                {
                    SourcePath = "C:\\origin...",
                    DestinyPath = "C:\\destiny...",
                    TransferMethod = new TransferMethod(){Id = 1},
                    MoveSubFolders = true,
                    KeepOriginFiles = true,
                    CleanDestinyDirectory = false,
                    AllowIgnoreFileExt = false,
                    DeleteUncommonFiles = false,
                    Profile = this.Profile,
                    AllowOnlyFileExtensions = new List<FileExtension>(),
                    IgnoredFileExtensions = new List<FileExtension>()
                };

                FormEditOption feo = new FormEditOption(this, opt);
                feo.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AddOption(Option option)
        {
            OptionAccess optAccess = new OptionAccess();
            option.ListViewIndex = listViewOptions.Items.Count;
            optAccess.AddOption(option);
            this.Options.Add(option);
            this.ProfileMenu.UpdateLastTimeModified(this.Profile);
            ListViewItem item = new ListViewItem();
            EditListViewItem(item, option);
            listViewOptions.Items.Add(item);
            ResizeForm();
        }

        private void ButtonEditOption_Click(object sender, EventArgs args)
        {
            EditSelectedOption();
        }

        private void EditSelectedOption()
        {
            try
            {
                ListViewItem item = listViewOptions.SelectedItems[0];
                Option option = this.Options.Find(x => x.Id == int.Parse(item.Tag.ToString()));
                FormEditOption edit = new FormEditOption(this, option);
                edit.Show(this);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select an option for editing.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void EditOption(Option option)
        {
            OptionAccess oa = new OptionAccess();
            oa.UpdateOption(option);
            this.ProfileMenu.UpdateLastTimeModified(this.Profile);
            EditListViewItem(listViewOptions.SelectedItems[0], option);
        }

        public void EditListViewItem(ListViewItem item, Option opt)
        {
            string transferMethod = !opt.CleanDestinyDirectory ? opt.TransferMethod.MethodName : "None";

            //string[] range = Enumerable.Repeat("", Enum.GetNames(typeof(ListViewOptionSubItemIndex)).Length).ToArray();

            item.SubItems.Clear();
            item.SubItems.AddRange(new string[] {
                opt.SourcePath,
                opt.DestinyPath,
                transferMethod,
                opt.MoveSubFolders.ToString(),
                opt.KeepOriginFiles.ToString(),
                opt.CleanDestinyDirectory.ToString(),
                opt.DeleteUncommonFiles.ToString()
            });
            
            item.Tag = opt.Id;
        }

        private void FormOptionsMenu_FormClosed(object sender, EventArgs args)
        {
            try
            {
                if (this.OptionIsExecuting && !this.FileControl.CancelExecution)
                {
                    this.FileControl.CancelExecution = true;
                    this.CancelExecutionForm.ShowDialog();
                    while (OptionIsExecuting == true) { };
                    CancelExecutionForm.Close();
                }
                this.ProfileMenu.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ButtonDeleteOption_Click(object sender, EventArgs args)
        {
            DeleteSelectedOption();
        }

        private void DeleteSelectedOption()
        {
            try
            {
                ListViewItem selectedItem = listViewOptions.SelectedItems[0];
                FormConfirmAction form = new FormConfirmAction("Delete selected option...");
                form.ShowDialog();
                if (form.ActionIsConfirmed)
                {
                    OptionAccess optAccess = new OptionAccess();
                    var option = this.Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    optAccess.DeleteOption(option);
                    Options.Remove(option);
                    selectedItem.Remove();
                    UpdateOptionListViewIndexes();
                    ResizeForm();
                }
                form.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select an option for deleting.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ButtonExecute_Click(object sender, EventArgs args)
        {
            try
            {

                if (this.Options.Count() == 0)
                {
                    MessageBox.Show("No options were added. Transfer canceled.");
                    return;
                }
                this.FileControl = new FileControl(this);
                try
                {
                    progressBarOptions.Maximum = FileControl.FilesTotal(this.Options);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message} Transfer canceled.");
                    return;
                }

                this.Options = this.Options.OrderBy(x => x.ListViewIndex).ToList();

                this.ProfileMenu.UpdateLastTimeExecuted(this.Profile);

                this.OptionIsExecuting = true;
                LogManager.BeginWritter();
                LogManager.WriteLine("##### Transfer date: " + DateTime.Now.ToLongDateString());
                progressBarOptions.Step = 1;
                progressBarOptions.Enabled = true;
                this.Cursor = Cursors.AppStarting;
                buttonAddOption.Visible = false;
                buttonEditOption.Visible = false;
                buttonDeleteOption.Visible = false;
                buttonExecute.Visible = false;
                buttonShowResult.Visible = false;
                checkBoxShowResult.Visible = false;
                labelTransfering.Visible = true;
                textBoxTransfering.Visible = true;
                buttonCancel.Visible = true;
                labelMoveOption.Visible = false;
                labelMoveOptionDown.Visible = false;
                labelMoveOptionUp.Visible = false;
                buttonCancel.BackColor = Color.FromArgb(255, 128, 128);

                ExecutionThread = new Thread(() =>
                {
                    foreach (Option opt in this.Options)
                    {
                        try
                        {
                            FileControl.ManageFiles(opt);
                        }
                        catch (Exception e2)
                        {
                            if (FileControl.CancelExecution == false)
                            {
                                FileControl.CancelExecution = true;
                                LogManager.WriteLine("Aborting...");
                            }
                            MessageBox.Show($"Error: {e2.Message} Aborting.");
                        }
                    }

                    Invoke(new Action(() =>
                    {
                        CancelExecutionForm.Hide();
                        LogManager.WriteLine("DONE");
                        LogManager.CloseWritter();
                        progressBarOptions.Enabled = false;
                        progressBarOptions.Value = 0;
                        this.Cursor = Cursors.Default;
                        labelTransfering.Visible = false;
                        textBoxTransfering.Visible = false;
                        textBoxTransfering.Text = "";
                        buttonCancel.BackColor = Color.FromArgb(255, 192, 192);
                        buttonCancel.Visible = false;
                        buttonAddOption.Visible = true;
                        buttonEditOption.Visible = true;
                        buttonDeleteOption.Visible = true;
                        buttonExecute.Visible = true;
                        checkBoxShowResult.Visible = true;
                        buttonShowResult.Visible = true;
                        labelMoveOption.Visible = true;
                        labelMoveOptionDown.Visible = true;
                        labelMoveOptionUp.Visible = true;
                        this.OptionIsExecuting = false;
                        buttonShowResult.Enabled = true;

                        ProfileMenu.LastReport = new FormReport(this, FileControl.TransFilesReports, FileControl.NotTransFilesReports,
                            FileControl.RenamedFilesReports, FileControl.CreatedDirReports, FileControl.ReplacedFilesReports, 
                            FileControl.RemovedFilesAndDirReports);
                        if (checkBoxShowResult.Checked)
                            ProfileMenu.LastReport.Show();
                    }));
                });
                ExecutionThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            if (OptionIsExecuting && !this.FileControl.CancelExecution)
            {
                this.FileControl.CancelExecution = true;
                CancelExecutionForm.ShowDialog(this);
            }
        }

        public void ShowCurrentFileExecution(string filename)
        {
            Invoke(new Action(() =>
            {
                textBoxTransfering.Text = filename;
                progressBarOptions.PerformStep();
            }));
        }

        public void ShowErrorDialog(string message,bool enableRepeatButton)
        {
            //if (!this.fileControl.CancelExecution)
            //{
                Invoke(new Action(() =>
                {
                    FormErrorDialog errorDialog = new FormErrorDialog(this, message, enableRepeatButton);
                    errorDialog.ShowDialog();
                }));
            //}
            //else
            //{
            //    LogManager.WriteLine("Canceling operation...");
            //    MessageBox.Show(message);
            //}
        }

        private void ContextMenuStripOptionsList_Opening(object sender, CancelEventArgs args)
        {
            if (listViewOptions.SelectedItems.Count <= 0) args.Cancel = true;
        }

        private void ToolStripMenuItemCopySourcePath_Click(object sender, EventArgs e)
        {
            CopyToClipboard(this.listViewOptions.SelectedItems[0].Text);
        }

        private void ToolStripMenuItemCopyDestinyPath_Click(object sender, EventArgs e)
        {
            CopyToClipboard(this.listViewOptions.SelectedItems[0].SubItems[(int)ListViewOptionSubItemIndex.INDEX_DESTINY_PATH].Text);
        }

        private void ToolStripMenuItemOpenSourceFolder_Click(object sender, EventArgs e)
        {
            OpenFolder(this.listViewOptions.SelectedItems[0].Text);
        }

        private void ToolStripMenuItemOpenDestinyFolder_Click(object sender, EventArgs e)
        {
            OpenFolder(this.listViewOptions.SelectedItems[0].SubItems[(int)ListViewOptionSubItemIndex.INDEX_DESTINY_PATH].Text);
        }

        private void ListViewOptionsMenu_DoubleClick(object sender, EventArgs args)
        {
            EditSelectedOption();
        }

        private void ListViewOptions_KeyPress(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Delete)
            {
                if (listViewOptions.SelectedItems.Count > 0) DeleteSelectedOption();
            }
            else if (args.KeyCode == Keys.Enter)
            {
                if(listViewOptions.SelectedItems.Count > 0) EditSelectedOption();
            }
        }

        private void CopyToClipboard(string text)
        {
            try
            {
                Clipboard.SetDataObject(text, false, 5, 200);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private void OpenFolder(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private void ButtonShowResult_Click(object sender, EventArgs args)
        {
            if (ProfileMenu.LastReport != null)
                ProfileMenu.LastReport.Show();
        }

        private void LabelMoveOptionUp_Click(object sender, EventArgs args)
        {
            try
            {
                if (listViewOptions.SelectedItems[0].Index == 0) return;

                ListViewItem selectedItem = listViewOptions.SelectedItems[0];
                ListViewItem previousItem = listViewOptions.Items[selectedItem.Index - 1];
                int selectedItemIndex = selectedItem.Index;
                int previousItemIndex = previousItem.Index;

                Option selectedOption = null;
                Option previousOption = null;

                OptionAccess oa = new OptionAccess();
                try
                {
                    selectedOption = Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedOption.ListViewIndex = previousItemIndex;
                    oa.UpdateOptionListViewIndex(selectedOption);

                    previousOption = Options.Find(x => x.Id == int.Parse(previousItem.Tag.ToString()));
                    previousOption.ListViewIndex = selectedItemIndex;
                    oa.UpdateOptionListViewIndex(previousOption);

                }
                catch (Exception)
                {
                    try
                    {
                        selectedOption.ListViewIndex = selectedItemIndex;
                        previousOption.ListViewIndex = previousItemIndex;
                        oa.UpdateOptionListViewIndex(selectedOption);
                        oa.UpdateOptionListViewIndex(previousOption);
                    }
                    catch (Exception) { }
                    throw;
                }

                ListViewItem selectedItemClone = (ListViewItem)selectedItem.Clone();
                ListViewItem previousItemClone = (ListViewItem)previousItem.Clone();

                listViewOptions.Items[selectedItemIndex] = previousItemClone;
                listViewOptions.Items[previousItemIndex] = selectedItemClone;
                
                listViewOptions.Items[previousItemIndex].Selected = true;
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception e) { 
                MessageBox.Show(e.Message);
            }
        }

        private void LabelMoveOptionDown_Click(object sender, EventArgs args)
        {
            try
            {
                if (listViewOptions.SelectedItems[0].Index == listViewOptions.Items.Count - 1) return;

                ListViewItem selectedItem = listViewOptions.SelectedItems[0];
                ListViewItem nextItem = listViewOptions.Items[selectedItem.Index + 1];
                int selectedItemIndex = selectedItem.Index;
                int nextItemIndex = nextItem.Index;

                Option selectedOption = null;
                Option nextOption = null;

                OptionAccess oa = new OptionAccess();

                try
                {
                    selectedOption = Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedOption.ListViewIndex = nextItemIndex;
                    oa.UpdateOptionListViewIndex(selectedOption);

                    nextOption = Options.Find(x => x.Id == int.Parse(nextItem.Tag.ToString()));
                    nextOption.ListViewIndex = selectedItemIndex;
                    oa.UpdateOptionListViewIndex(nextOption);
                }
                catch (Exception)
                {
                    try
                    {
                        selectedOption.ListViewIndex = selectedItemIndex;
                        nextOption.ListViewIndex = nextItemIndex;
                        oa.UpdateOptionListViewIndex(selectedOption);
                        oa.UpdateOptionListViewIndex(nextOption);
                    }
                    catch (Exception) {}
                    throw;
                }

                ListViewItem selectedItemClone = (ListViewItem)selectedItem.Clone();
                ListViewItem nextItemClone = (ListViewItem)nextItem.Clone();

                listViewOptions.Items[selectedItemIndex] = nextItemClone;
                listViewOptions.Items[nextItemIndex] = selectedItemClone;

                listViewOptions.Items[nextItemIndex].Selected = true;
            }
            catch (ArgumentOutOfRangeException) {}
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CloneOptionToolStripMenuItem_Click(object sender, EventArgs args)
        {
            try
            {
                Option selectedOption = Options.Find(
                       x => x.Id == int.Parse(listViewOptions.SelectedItems[0].Tag.ToString()));
                Option clonedOption = (Option)selectedOption.Clone();
                clonedOption.ListViewIndex = listViewOptions.Items.Count;
                OptionAccess oa = new OptionAccess();
                oa.AddOption(clonedOption);
                Options.Add(clonedOption);
                this.ProfileMenu.UpdateLastTimeModified(this.Profile);
                ListViewItem item = new ListViewItem();
                EditListViewItem(item, clonedOption);
                listViewOptions.Items.Add(item);
                ResizeForm();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
