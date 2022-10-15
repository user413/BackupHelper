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
    public partial class FormOptionsMenu : Form
    {
        public readonly Profile Profile;
        public List<Options> Options;
        private readonly FormProfileMenu ProfileMenu;
        public FileControlImpl FileControl;
        private Thread ExecutionThread;
        private readonly FormCancelExecution CancelExecutionForm;

        //-- Clicking/dragdrop functions
        private System.Timers.Timer ClickTimer = new System.Timers.Timer(300);
        private int MouseDownCount = 0;
        private int MouseUpCount = 0;
        private ListViewItem ClickedItem;
        //private bool OptionIsExecuting = false;

        ////--FORM RESIZING VARIABLES
        //private readonly int InitialFormHeight;
        //private readonly int InitialFormWidth;
        //private readonly int ListOptionHeight = 17;
        //private readonly int AditionalListViewItemCount = 6;
        //private readonly int InitialListViewItemCount = 10;
        //private readonly int MaximumListViewItemCount;

        public FormOptionsMenu(FormProfileMenu profileMenu, Profile profile)
        {
            //this.listViewOptions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContextMenuStripOptionsList_Click);
            ClickTimer.Elapsed += ClickTimer_Elapsed;
            ClickTimer.AutoReset = false;
            InitializeComponent();
            listViewOptions.MouseDown += ListViewOptions_MouseDown;
            listViewOptions.DragEnter += ListViewOptions_DragEnter;
            listViewOptions.DragDrop += ListViewOptions_DragDrop;
            listViewOptions.MouseUp += ListViewOptions_MouseUp;

            Profile = profile;
            ProfileMenu = profileMenu;
            CancelExecutionForm = new FormCancelExecution();
            Text = "Profile:  " + Profile.Name;
            if (profileMenu.LastReport != null)
                buttonShowResult.Enabled = true;

            //InitialFormHeight = Bounds.Height;
            //InitialFormWidth = Bounds.Width;
            //AditionalListViewItemCount = 6;
            //InitialListViewItemCount = 10;
            //MaximumListViewItemCount = AditionalListViewItemCount + InitialListViewItemCount;

            ListOptions();
        }

        private void ListViewOptions_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            //if (listViewOptions.GetItemAt(e.X, e.Y) == null) return;
            MouseUpCount++;
        }

        private void ClickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                //if (e.Button != MouseButtons.Left) return;
                if (ClickedItem == null)
                {
                    MouseDownCount = 0;
                    return;
                }

                if (MouseDownCount == 1)
                {
                    if (MouseUpCount > 0) return;
                    List<ListViewItem> selectedItems = listViewOptions.SelectedItems.Cast<ListViewItem>().ToList();

                    if (!selectedItems.Exists(i => i == ClickedItem))
                        selectedItems = new List<ListViewItem>() { ClickedItem };

                    listViewOptions.DoDragDrop(selectedItems, DragDropEffects.Move);
                }
                else
                {
                    EditSelectedOption();
                }
            }));
        }

        private void ListViewOptions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ListViewItem selected = listViewOptions.GetItemAt(e.X, e.Y);
            if (selected == null) return;

            if (!ClickTimer.Enabled)
            {
                MouseDownCount = 0;
                MouseUpCount = 0;
                ClickTimer.Start();
                ClickedItem = selected;
            }
            else
                if (selected != ClickedItem) ClickedItem = null;

            MouseDownCount++;
        }

        private void ListViewOptions_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ListViewOptions_DragDrop(object sender, DragEventArgs args)
        {
            try
            {
                List<ListViewItem> selectedItems = (List<ListViewItem>)args.Data.GetData(typeof(List<ListViewItem>));
                Point targetCoordinates = listViewOptions.PointToClient(new Point(args.X, args.Y));
                ListViewItem targetItem = listViewOptions.GetItemAt(targetCoordinates.X, targetCoordinates.Y);

                if (targetItem == null || selectedItems.Exists(i => i == targetItem) /*|| targetItem.Group != selectedItems[0].Group*/) return;

                bool indexIsBehind = selectedItems.Last().Index < targetItem.Index;

                try
                {
                    foreach (ListViewItem i in selectedItems)
                    {
                        listViewOptions.Items.Remove(i);
                        i.Group = targetItem.Group;
                    }

                    for (int i = 0; i < selectedItems.Count; i++)
                        listViewOptions.Items.Insert(indexIsBehind ? targetItem.Index + 1 + i : targetItem.Index, selectedItems[i]);

                    //-- Due to a bug / makes items appear in the correct listview positions
                    //string tempGName = targetItem.Group.Header;
                    //targetItem.Group.Header = "tmp";
                    //targetItem.Group.Header = tempGName;
                }
                finally
                {
                    UpdateOptionListViewIndexes();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ListOptions()
        {
            try
            {
                Options = DBAccess.ListProfileOptions(Profile).OrderBy(o => o.ListViewIndex).ToList();

                foreach (Options option in Options)
                {
                    ListViewItem item = new ListViewItem();
                    EditListViewItem(option, item);
                    listViewOptions.Items.Add(item);
                }

                //ResizeForm();
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
                Options option = Options.Find(o => o.Id == (int)item.Tag);

                if (option.ListViewIndex != item.Index)
                {
                    option.ListViewIndex = item.Index;
                    DBAccess.UpdateOptionListViewIndex(option);
                }
            }
        }

        //public void ResizeForm()
        //{
        //    //CHANGING FORM HEIGHT RESPONSIVELY DEPENDING ON NUMBER OF OPTIONS
        //    if (Options.Count() > InitialListViewItemCount && Options.Count() < MaximumListViewItemCount)
        //        Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (Options.Count() - InitialListViewItemCount) * ListOptionHeight);
        //    else if (Options.Count() >= MaximumListViewItemCount)
        //        Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (ListOptionHeight * AditionalListViewItemCount));
        //    else if (Bounds.Height != InitialFormHeight)
        //        Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight);
        //}

        private void ButtonAddOption_Click(object sender, EventArgs args)
        {
            try
            {
                FormEditOptions form = FormEditOptions.GetInstance(this);
                
                if (form.Visible)
                    form.WindowState = FormWindowState.Normal;
                else
                    form.Show(this);
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
                Options option = Options.Find(o => o.Id == (int)listViewOptions.SelectedItems[0].Tag);
                
                FormEditOptions form = FormEditOptions.GetInstance(this, option);

                if (form.Visible)
                    form.WindowState = FormWindowState.Normal;
                else
                    form.Show(this);
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

        public void EditListViewItem(Options option, ListViewItem item = null)
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
                option.IncludeSubFolders.ToString(),
                option.KeepOriginFiles.ToString(),
                option.CleanDestinyDirectory.ToString(),
                option.DeleteUncommonFiles.ToString(),
                option.ReenumerateRenamedFiles.ToString()
            });
            
            item.Tag = option.Id;
        }

        private ListViewItem GetListViewItemById(int id)
        {
            foreach (ListViewItem item in listViewOptions.Items)
                if ((int)item.Tag == id) return item;

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

                if (MessageBox.Show("Delete selected option?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var option = Options.Find(o => o.Id == (int)selectedItem.Tag);
                    DBAccess.DeleteOption(option);
                    Options.Remove(option);
                    selectedItem.Remove();
                    Program.UpdateLastTimeModified(Profile);
                    UpdateOptionListViewIndexes();
                    //ResizeForm();
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
                if (Options.Count() == 0)
                {
                    MessageBox.Show("No options were added.");
                    return;
                }

                List<Options> options = Options.OrderBy(o => o.ListViewIndex).Select(o => o.Clone()).ToList();
                foreach (Options o in options)
                {
                    if (!o.AllowIgnoreFileExt) o.SpecifiedFileNamesAndExtensions.Clear(); //-- Names must be ignored
                    o.SourcePath = Environment.ExpandEnvironmentVariables(o.SourcePath);
                    o.DestinyPath = Environment.ExpandEnvironmentVariables(o.DestinyPath);
                }

                FileControl = new FileControlImpl(this);
                progressBarOptions.Maximum = FileControl.FilesTotal(options.ToList<TransferSettings>());

                //this.OptionIsExecuting = true;
                LogManager.BeginWritter();
                LogManager.WriteLine("");
                //LogManager.WriteLine("##### Transfer date: " + DateTime.Now.ToLongDateString());
                progressBarOptions.Step = 1;
                progressBarOptions.Enabled = true;
                Cursor = Cursors.AppStarting;
                buttonAddOption.Visible = false;
                buttonExecute.Visible = false;
                buttonShowResult.Visible = false;
                checkBoxShowResult.Visible = false;
                labelTransfering.Visible = true;
                textBoxTransfering.Visible = true;
                buttonCancel.Visible = true;
                buttonCancel.BackColor = Color.FromArgb(255, 128, 128);

                Program.UpdateLastTimeExecuted(Profile);

                ExecutionThread = new Thread(() =>
                {
                    try
                    {
                        FileControl.ManageFiles(options.ToList<TransferSettings>());
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
                        Cursor = Cursors.Default;
                        labelTransfering.Visible = false;
                        textBoxTransfering.Visible = false;
                        textBoxTransfering.Text = "";
                        buttonCancel.BackColor = Color.FromArgb(255, 192, 192);
                        buttonCancel.Visible = false;
                        buttonAddOption.Visible = true;
                        buttonExecute.Visible = true;
                        checkBoxShowResult.Visible = true;
                        buttonShowResult.Visible = true;
                        //this.OptionIsExecuting = false;
                        buttonShowResult.Enabled = true;
                        Enabled = true;

                        ProfileMenu.LastReport = new FormReport(this, FileControl.TransferedFilesReports, FileControl.NotTransferedFilesReports,
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
            if (listViewOptions.SelectedItems.Count != 1) args.Cancel = true;
        }

        private void ToolStripMenuItemCopySourcePath_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewOptions.SelectedItems[0].Text);
        }

        private void ToolStripMenuItemCopyDestinyPath_Click(object sender, EventArgs e)
        {
            //CopyToClipboard(listViewOptions.SelectedItems[0].SubItems[(int)ListViewOptionSubItemIndex.INDEX_DESTINY_PATH].Text);
            CopyToClipboard(Options.Find(o => o.Id == (int)listViewOptions.SelectedItems[0].Tag).DestinyPath);
        }

        private void ToolStripMenuItemOpenSourceFolder_Click(object sender, EventArgs e)
        {
            OpenFolder(Environment.ExpandEnvironmentVariables(listViewOptions.SelectedItems[0].Text));
        }

        private void ToolStripMenuItemOpenDestinyFolder_Click(object sender, EventArgs e)
        {
            OpenFolder(Environment.ExpandEnvironmentVariables(
                //listViewOptions.SelectedItems[0].SubItems[(int)ListViewOptionSubItemIndex.INDEX_DESTINY_PATH].Text));
                Options.Find(o => o.Id == (int)listViewOptions.SelectedItems[0].Tag).DestinyPath));
        }

        //private void ListViewOptions_DoubleClick(object sender, EventArgs args)
        //{
        //    EditSelectedOption();
        //}

        private void ListViewOptions_KeyPress(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Delete)
            {
                if (listViewOptions.SelectedItems.Count > 0) DeleteSelectedOption();
            }
            else if (args.KeyCode == Keys.Enter)
            {
                if (listViewOptions.SelectedItems.Count > 0) EditSelectedOption();
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

        //private void LabelMoveOptionUp_Click(object sender, EventArgs args)
        //{
        //    try
        //    {
        //        if (listViewOptions.SelectedItems[0].Index == 0) return;

        //        ListViewItem selectedItem = listViewOptions.SelectedItems[0];
        //        ListViewItem previousItem = listViewOptions.Items[selectedItem.Index - 1];
        //        int selectedItemIndex = selectedItem.Index;
        //        int previousItemIndex = previousItem.Index;

        //        Option selectedOption = null;
        //        Option previousOption = null;

        //        try
        //        {
        //            selectedOption = Options.Find(x => x.Id == (int)selectedItem.Tag);
        //            selectedOption.ListViewIndex = previousItemIndex;
        //            DBAccess.UpdateOptionListViewIndex(selectedOption);

        //            previousOption = Options.Find(x => x.Id == (int)previousItem.Tag);
        //            previousOption.ListViewIndex = selectedItemIndex;
        //            DBAccess.UpdateOptionListViewIndex(previousOption);

        //        }
        //        catch (Exception)
        //        {
        //            try
        //            {
        //                selectedOption.ListViewIndex = selectedItemIndex;
        //                previousOption.ListViewIndex = previousItemIndex;
        //                DBAccess.UpdateOptionListViewIndex(selectedOption);
        //                DBAccess.UpdateOptionListViewIndex(previousOption);
        //            }
        //            catch (Exception) { }
        //            throw;
        //        }

        //        ListViewItem selectedItemClone = (ListViewItem)selectedItem.Clone();
        //        ListViewItem previousItemClone = (ListViewItem)previousItem.Clone();

        //        listViewOptions.Items[selectedItemIndex] = previousItemClone;
        //        listViewOptions.Items[previousItemIndex] = selectedItemClone;
                
        //        listViewOptions.Items[previousItemIndex].Selected = true;
        //    }
        //    catch (ArgumentOutOfRangeException) { }
        //    catch (Exception e) { 
        //        MessageBox.Show(e.Message);
        //    }
        //}

        //private void LabelMoveOptionDown_Click(object sender, EventArgs args)
        //{
        //    try
        //    {
        //        if (listViewOptions.SelectedItems[0].Index == listViewOptions.Items.Count - 1) return;

        //        ListViewItem selectedItem = listViewOptions.SelectedItems[0];
        //        ListViewItem nextItem = listViewOptions.Items[selectedItem.Index + 1];
        //        int selectedItemIndex = selectedItem.Index;
        //        int nextItemIndex = nextItem.Index;

        //        Option selectedOption = null;
        //        Option nextOption = null;

        //        try
        //        {
        //            selectedOption = Options.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
        //            selectedOption.ListViewIndex = nextItemIndex;
        //            DBAccess.UpdateOptionListViewIndex(selectedOption);

        //            nextOption = Options.Find(x => x.Id == int.Parse(nextItem.Tag.ToString()));
        //            nextOption.ListViewIndex = selectedItemIndex;
        //            DBAccess.UpdateOptionListViewIndex(nextOption);
        //        }
        //        catch (Exception)
        //        {
        //            try
        //            {
        //                selectedOption.ListViewIndex = selectedItemIndex;
        //                nextOption.ListViewIndex = nextItemIndex;
        //                DBAccess.UpdateOptionListViewIndex(selectedOption);
        //                DBAccess.UpdateOptionListViewIndex(nextOption);
        //            }
        //            }
        //            catch (Exception) {}
        //            throw;
        //        }

        //        ListViewItem selectedItemClone = (ListViewItem)selectedItem.Clone();
        //        ListViewItem nextItemClone = (ListViewItem)nextItem.Clone();

        //        listViewOptions.Items[selectedItemIndex] = nextItemClone;
        //        listViewOptions.Items[nextItemIndex] = selectedItemClone;

        //        listViewOptions.Items[nextItemIndex].Selected = true;
        //    }
        //    catch (ArgumentOutOfRangeException) {}
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

        private void CloneOptionToolStripMenuItem_Click(object sender, EventArgs args)
        {
            try
            {
                Options selectedOption = Options.Find(o => o.Id == (int)listViewOptions.SelectedItems[0].Tag);

                Options clonedOption = selectedOption.Clone();
                clonedOption.ListViewIndex = listViewOptions.Items.Count;
                DBAccess.AddOption(clonedOption);
                Options.Add(clonedOption);
                Program.UpdateLastTimeModified(Profile);
                ListViewItem item = new ListViewItem();
                EditListViewItem(clonedOption, item);
                listViewOptions.Items.Add(item);
                //ResizeForm();
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
