using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FileControlUtility;

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
        public readonly Profile Profile;
        public List<Option> Options;
        private readonly FormProfileMenu ProfileMenu;
        public FileControlImpl FileControl;
        private Thread ExecutionThread;
        private readonly FormCancelExecution CancelExecutionForm;
        //private bool OptionIsExecuting = false;

        //--FORM RESIZING VARIABLES
        private readonly int InitialFormHeight;
        private readonly int InitialFormWidth;
        private readonly int ListOptionHeight = 17;
        private readonly int AditionalListViewItemCount = 6;
        private readonly int InitialListViewItemCount = 10;
        private readonly int MaximumListViewItemCount;        

        public FormOptionsMenu(FormProfileMenu profileMenu, Profile profile)
        {
            //this.listViewOptions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContextMenuStripOptionsList_Click);

            InitializeComponent();

            Profile = profile;
            ProfileMenu = profileMenu;
            CancelExecutionForm = new FormCancelExecution();
            Text = "Profile:  " + this.Profile.Name;
            if (profileMenu.LastReport != null)
                buttonShowResult.Enabled = true;

            InitialFormHeight = Bounds.Height;
            InitialFormWidth = Bounds.Width;
            AditionalListViewItemCount = 6;
            InitialListViewItemCount = 10;
            MaximumListViewItemCount = AditionalListViewItemCount + InitialListViewItemCount;

            LoadListView();
        }

        private void LoadListView()
        {
            try
            {
                Options = DBAccess.ListProfileOptions(this.Profile).OrderBy(x => x.ListViewIndex).ToList();

                foreach (Option option in Options)
                {
                    ListViewItem item = new ListViewItem();
                    EditListViewItem(option, item);
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
            foreach (ListViewItem item in listViewOptions.Items)
            {
                Option option = Options.Find(x => x.Id == int.Parse(item.Tag.ToString()));
                int currentIndex = option.ListViewIndex;
                try
                {
                    option.ListViewIndex = item.Index;
                    DBAccess.UpdateOptionListViewIndex(option);
                }
                catch (Exception)
                {
                    try
                    {
                        option.ListViewIndex = currentIndex;
                        DBAccess.UpdateOptionListViewIndex(option);
                    }
                    catch (Exception) {}
                    throw;
                }
            }
        }

        public void ResizeForm()
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
                FormEditOption form = new FormEditOption(this);
                form.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

        public void EditListViewItem(Option option, ListViewItem item = null)
        {
            if (item == null)
                item = GetListViewItemById(option.Id);
                
            string transferMethod = !option.CleanDestinyDirectory ? option.GetTransferMethodDescription(option.FileNameConflictMethod) : "None";

            //string[] range = Enumerable.Repeat("", Enum.GetNames(typeof(ListViewOptionSubItemIndex)).Length).ToArray();

            item.SubItems.Clear();
            item.Text = option.SourcePath;
            item.SubItems.AddRange(new string[] {
                option.DestinyPath,
                transferMethod,
                option.MoveSubFolders.ToString(),
                option.KeepOriginFiles.ToString(),
                option.CleanDestinyDirectory.ToString(),
                option.DeleteUncommonFiles.ToString()
            });
            
            item.Tag = option.Id;
        }

        private ListViewItem GetListViewItemById(int id)
        {
            foreach (ListViewItem item in listViewOptions.Items)
                if (int.Parse(item.Tag.ToString()) == id) return item;
            return null;
        }

        private void FormOptionsMenu_FormClosing(object sender, FormClosingEventArgs args)
        {
            try
            {
                if (ExecutionThread != null && ExecutionThread.IsAlive)
                {
                    args.Cancel = true;

                    if (MessageBox.Show("Abort transfer?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    Enabled = false;
                    FileControl.CancelExecution = true;
                    CancelExecutionForm.ShowDialog();
                }

                ProfileMenu.Show();
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
                string text = "Delete selected option?";
                if (MessageBox.Show(text, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var option = this.Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    DBAccess.DeleteOption(option);
                    Options.Remove(option);
                    selectedItem.Remove();
                    UpdateOptionListViewIndexes();
                    ResizeForm();
                }
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
                    MessageBox.Show("No options were added.");
                    return;
                }

                this.FileControl = new FileControlImpl(this);

                try
                {
                    progressBarOptions.Maximum = FileControl.FilesTotal(Options.ToList<TransferSettings>());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message}{Environment.NewLine}Transfer canceled.");
                    return;
                }

                this.Options = this.Options.OrderBy(x => x.ListViewIndex).ToList();

                Program.UpdateLastTimeExecuted(this.Profile);

                //this.OptionIsExecuting = true;
                LogManager.BeginWritter();
                LogManager.WriteLine("");
                //LogManager.WriteLine("##### Transfer date: " + DateTime.Now.ToLongDateString());
                progressBarOptions.Step = 1;
                progressBarOptions.Enabled = true;
                this.Cursor = Cursors.AppStarting;
                buttonAddOption.Visible = false;
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

                    try
                    {
                        FileControl.ManageFiles(Options.ToList<TransferSettings>());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e.Message);
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
                        buttonExecute.Visible = true;
                        checkBoxShowResult.Visible = true;
                        buttonShowResult.Visible = true;
                        labelMoveOption.Visible = true;
                        labelMoveOptionDown.Visible = true;
                        labelMoveOptionUp.Visible = true;
                        //this.OptionIsExecuting = false;
                        buttonShowResult.Enabled = true;
                        this.Enabled = true;

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
            if (ExecutionThread.IsAlive)
            {
                FileControl.CancelExecution = true;
                Enabled = false;
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

        //public void ShowErrorDialog(string message,bool enableRepeatButton)
        //{
        //    Invoke(new Action(() =>
        //    {
        //        FormErrorDialog errorDialog = new FormErrorDialog(message, enableRepeatButton);
        //        errorDialog.ShowDialog();
        //    }));
        //}

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

                try
                {
                    selectedOption = Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedOption.ListViewIndex = previousItemIndex;
                    DBAccess.UpdateOptionListViewIndex(selectedOption);

                    previousOption = Options.Find(x => x.Id == int.Parse(previousItem.Tag.ToString()));
                    previousOption.ListViewIndex = selectedItemIndex;
                    DBAccess.UpdateOptionListViewIndex(previousOption);

                }
                catch (Exception)
                {
                    try
                    {
                        selectedOption.ListViewIndex = selectedItemIndex;
                        previousOption.ListViewIndex = previousItemIndex;
                        DBAccess.UpdateOptionListViewIndex(selectedOption);
                        DBAccess.UpdateOptionListViewIndex(previousOption);
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

                try
                {
                    selectedOption = Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedOption.ListViewIndex = nextItemIndex;
                    DBAccess.UpdateOptionListViewIndex(selectedOption);

                    nextOption = Options.Find(x => x.Id == int.Parse(nextItem.Tag.ToString()));
                    nextOption.ListViewIndex = selectedItemIndex;
                    DBAccess.UpdateOptionListViewIndex(nextOption);
                }
                catch (Exception)
                {
                    try
                    {
                        selectedOption.ListViewIndex = selectedItemIndex;
                        nextOption.ListViewIndex = nextItemIndex;
                        DBAccess.UpdateOptionListViewIndex(selectedOption);
                        DBAccess.UpdateOptionListViewIndex(nextOption);
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

                Option clonedOption = selectedOption.Clone();
                clonedOption.ListViewIndex = listViewOptions.Items.Count;
                DBAccess.AddOption(clonedOption);
                Options.Add(clonedOption);
                Program.UpdateLastTimeModified(this.Profile);
                ListViewItem item = new ListViewItem();
                EditListViewItem(clonedOption, item);
                listViewOptions.Items.Add(item);
                ResizeForm();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ToolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            DeleteSelectedOption();
        }
    }
}
