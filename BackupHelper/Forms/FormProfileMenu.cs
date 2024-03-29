﻿using BackupHelper.model;
using BinanceAutoTrader;
using Nain.FormsUtility;
using System.Data;
using System.Reflection;

namespace BackupHelper
{
    public partial class FormProfileMenu : Form
    {
        public List<Profile> Profiles;
        public FormReport LastReport;

        ////--FORM RESIZING VARIABLES
        //private readonly int InitialFormWidth;
        //private readonly int InitialFormHeight;
        //private readonly int ListProfileHeight = 17;
        //private readonly int AditionalListViewItemCount = 6;
        //private readonly int InitialListViewItemCount = 10;
        //private readonly int MaximumListViewItemCount;

        //-- Clicking/dragdrop functions
        private readonly System.Timers.Timer ClickTimer = new(300);
        private int MouseDownCount = 0;
        private int MouseUpCount = 0;
        private ListViewItem ClickedItem;

        public FormProfileMenu()
        {
            InitializeComponent();
            listViewProfile.Groups.Add("Ungrouped", "Ungrouped");
            contextMenuStripProfile.Opening += ContextMenuStripProfile_Opening;
            
            int strToRemove = Application.ProductVersion.IndexOf('+');
            string version = strToRemove < 0 ? Application.ProductVersion : Application.ProductVersion[..strToRemove];
            
            labelVersion.Text = $"Version {version} ©{Application.CompanyName} 2024";
            KeyPreview = true;
            ClickTimer.Elapsed += ClickTimer_Elapsed;
            ClickTimer.AutoReset = false;
            listViewProfile.KeyDown += new KeyEventHandler(FormProfileMenu_KeyDown);
            listViewProfile.MouseDown += ListViewProfile_MouseDown;
            listViewProfile.MouseUp += ListViewProfile_MouseUp;
            listViewProfile.DragEnter += ListViewProfile_DragEnter;
            listViewProfile.DragDrop += ListViewProfile_DragDrop;
            //InitialFormWidth = Bounds.Width;
            //InitialFormHeight = Bounds.Height;
            //AditionalListViewItemCount = 6;
            //InitialListViewItemCount = 10;
            //MaximumListViewItemCount = AditionalListViewItemCount + InitialListViewItemCount;
            ListProfiles();
        }

        private void ClickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(() =>
            {
                if (ClickedItem == null)
                {
                    MouseDownCount = 0;
                    return;
                }

                if (MouseDownCount == 1)
                {
                    //perform dragdrop if no mouseup
                    if (MouseUpCount > 0) return;
                    List<ListViewItem> selectedItems = listViewProfile.SelectedItems.Cast<ListViewItem>().ToList();

                    if (!selectedItems.Exists(i => i == ClickedItem))
                        selectedItems = new List<ListViewItem>() { ClickedItem };

                    listViewProfile.DoDragDrop(selectedItems, DragDropEffects.Move);
                }
                else //double click
                {
                    OpenSelectedProfile();
                }
            });
        }

        private void ListViewProfile_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            //if (listViewOptions.GetItemAt(e.X, e.Y) == null) return;
            MouseUpCount++;
        }

        private void ListViewProfile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ListViewItem selected = listViewProfile.GetItemAt(e.X, e.Y);
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

        private void ListViewProfile_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            //    e.Effect = DragDropEffects.Move;
            //else
            //    e.Effect = DragDropEffects.None;

            ListViewUtility.DragEnter(e);
        }

        private void ListViewProfile_DragDrop(object sender, DragEventArgs args)
        {
            try
            {
                //List<ListViewItem> selectedItems = (List<ListViewItem>)args.Data.GetData(typeof(List<ListViewItem>));
                //Point targetCoordinates = listViewProfile.PointToClient(new Point(args.X, args.Y));
                //ListViewItem targetItem = listViewProfile.GetItemAt(targetCoordinates.X, targetCoordinates.Y);

                //if (targetItem == null || selectedItems.Exists(i => i == targetItem) /*|| targetItem.Group != selectedItems[0].Group*/) return;

                //bool indexIsBehind = selectedItems.Last().Index < targetItem.Index;

                //try
                //{
                //    foreach (ListViewItem i in selectedItems)
                //    {
                //        listViewProfile.Items.Remove(i);
                //        i.Group = targetItem.Group;
                //    }

                //    for (int i = 0; i < selectedItems.Count; i++)
                //        listViewProfile.Items.Insert(indexIsBehind ? targetItem.Index + 1 + i : targetItem.Index, selectedItems[i]);

                //    //string tempGName;
                //    ListViewGroup tempGroup;

                //    foreach (ListViewItem item in listViewProfile.Items)
                //    {
                //        //-- Due to a bug / makes items appear in the correct listview positions
                //        //tempGName = item.Group.Header;
                //        //item.Group.Header = "tmp";
                //        //item.Group.Header = tempGName;
                //        tempGroup = item.Group;
                //        item.Group = null;
                //        item.Group = tempGroup;
                //        item.Selected = false; //items need to be unselected
                //    }
                //}
                //finally
                //{
                //    UpdateProfileListViewIndexes();
                //}

                ListViewUtility.DragDrop(listViewProfile, args);
                UpdateProfileListViewIndexes();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ContextMenuStripProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listViewProfile.SelectedItems.Count == 1)
            {
                toolStripMenuItemChangeName.Enabled = true;
                toolStripMenuItemClone.Enabled = true;
            }
            else if (listViewProfile.SelectedItems.Count > 1)
            {
                toolStripMenuItemChangeName.Enabled = false;
                toolStripMenuItemClone.Enabled = false;
            }
            else
                e.Cancel = true;
        }

        private void ListProfiles()
        {
            try
            {
                Profiles = DBAccess.ListProfiles().OrderBy(p => p.ListViewIndex).ToList();

                foreach (Profile prof in Profiles)
                {
                    ListViewItem item = new ListViewItem();
                    EditListViewItem(prof, item);
                    listViewProfile.Items.Add(item);
                }

                //ResizeForm();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //public void UpdateListViewItem(Profile profile)
        //{
        //    foreach (ListViewItem i in listViewProfile.Items)
        //        if ((int)i.Tag == profile.Id)
        //        {
        //            EditListViewItem(profile, i);
        //            return;
        //        }
        //}

        private void UpdateProfileListViewIndexes()
        {
            foreach (ListViewItem item in listViewProfile.Items)
            {
                Profile profile = Profiles.Find(o => o.Id == (int)item.Tag);

                if (profile.ListViewIndex != item.Index)
                {
                    profile.ListViewIndex = item.Index;
                    profile.GroupName = item.Group.Header;
                    DBAccess.UpdateProfileListViewIndex(profile);
                }
            }
        }

        //public void ResizeForm()
        //{
        //    //-- CHANGING FORM HEIGHT RESPONSIVELY DEPENDING ON NUMBER OF PROFILES
        //    if (Profiles.Count() > InitialListViewItemCount && Profiles.Count() < MaximumListViewItemCount)
        //        Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (Profiles.Count() - InitialListViewItemCount) * ListProfileHeight);
        //    else if (Profiles.Count() >= MaximumListViewItemCount)
        //        Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (ListProfileHeight * AditionalListViewItemCount));
        //    else if (Bounds.Height != InitialFormHeight)
        //        Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight);
        //}

        //private void ListViewProfileItem_DoubleClick(object sender, EventArgs args)
        //{
        //    OpenSelectedProfile();
        //}

        private void OpenSelectedProfile()
        {
            try
            {
                FormOptionsMenu optionsMenu = new FormOptionsMenu(this,
                    Profiles.Find(x => x.Id == (int)listViewProfile.SelectedItems[0].Tag));

                optionsMenu.Show(this);
                Hide();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a profile.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ButtonAddProfile_Click(object sender, EventArgs args)
        {
            try
            {
                FormEditProfile addProfile = new FormEditProfile(this);
                addProfile.ShowDialog(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void EditListViewItem(Profile profile, ListViewItem item = null)
        {
            if (item == null)
                item = GetListViewItemById(profile.Id);

            //string[] range = Enumerable.Repeat("", Enum.GetNames(typeof(ListViewProfileSubItemIndex)).Length).ToArray();
            //item.SubItems.AddRange(range);

            item.Tag = profile.Id;
            item.Text = profile.Name;
            SetListViewItemGroup(item, profile.GroupName, listViewProfile);
            item.SubItems.AddRange(new string[] {
                profile.LastTimeExecuted == DateTime.MinValue ? "Never" : profile.LastTimeExecuted.ToString(),
                profile.LastTimeModified == DateTime.MinValue ? "Never" : profile.LastTimeModified.ToString(),
                profile.TimeCreated.ToString(),
            });
        }

        private void SetListViewItemGroup(ListViewItem item, string header, ListView listView)
        {
            foreach (ListViewGroup group in listView.Groups)
                if (group.Header == header)
                {
                    item.Group = group;
                    return;
                }

            ListViewGroup newGroup = new ListViewGroup(header);
            listView.Groups.Add(newGroup);
            item.Group = newGroup;
        }

        private void EditSelectedProfileName()
        {
            try
            {
                FormEditProfile edit = new FormEditProfile(this,
                    Profiles.Find(p => p.Id == (int)listViewProfile.SelectedItems[0].Tag));

                edit.ShowDialog(this);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a profile for editing.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private void DeleteSelectedProfiles()
        {
            try
            {
                if (MessageBox.Show("Delete selected profiles(s)?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

                foreach (ListViewItem item in listViewProfile.SelectedItems)
                {
                    Profile profile = Profiles.Find(p => p.Id == int.Parse(item.Tag.ToString()));
                    DBAccess.DeleteProfile(profile);
                    Profiles.Remove(profile);
                    listViewProfile.Items.Remove(item);
                    UpdateProfileListViewIndexes();
                    //ResizeForm(); 
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a profile to delete.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private void ButtonOpenLogFile_Click(object sender, EventArgs args)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt",
                    UseShellExecute = true
                });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private void ListViewProfile_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Delete)
            {
                if (listViewProfile.SelectedItems.Count > 0) DeleteSelectedProfiles();
            }
            else if (args.KeyCode == Keys.Enter)
            {
                if (listViewProfile.SelectedItems.Count > 0) OpenSelectedProfile();
            }
        }

        private void ButtonSelectProfile_Click(object sender, EventArgs args)
        {
            try
            {
                OpenSelectedProfile();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public ListViewItem GetListViewItemById(int id)
        {
            foreach (ListViewItem item in listViewProfile.Items)
                if ((int)item.Tag == id) return item;

            return null;
        }

        private void LabelMoveProfileUp_Click(object sender, EventArgs args)
        {
            try
            {
                if (listViewProfile.SelectedItems[0].Index == 0) return;

                ListViewItem selectedItem = listViewProfile.SelectedItems[0];
                ListViewItem previousItem = listViewProfile.Items[selectedItem.Index - 1];
                int selectedItemIndex = selectedItem.Index;
                int previousItemIndex = previousItem.Index;

                Profile selectedProfile = null;
                Profile previousProfile = null;

                try
                {
                    selectedProfile = Profiles.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedProfile.ListViewIndex = selectedItem.Index - 1;
                    DBAccess.UpdateProfileListViewIndex(selectedProfile);

                    previousProfile = Profiles.Find(x => x.Id == int.Parse(previousItem.Tag.ToString()));
                    previousProfile.ListViewIndex = selectedItem.Index;
                    DBAccess.UpdateProfileListViewIndex(previousProfile);
                }
                catch (Exception)
                {
                    selectedProfile.ListViewIndex = selectedItem.Index;
                    previousProfile.ListViewIndex = previousItem.Index;
                    DBAccess.UpdateProfileListViewIndex(selectedProfile);
                    DBAccess.UpdateProfileListViewIndex(previousProfile);
                    throw;
                }

                ListViewItem selectedItemClone = (ListViewItem)selectedItem.Clone();
                ListViewItem previousItemClone = (ListViewItem)previousItem.Clone();

                listViewProfile.Items[selectedItemIndex] = previousItemClone;
                listViewProfile.Items[previousItemIndex] = selectedItemClone;

                listViewProfile.Items[previousItemIndex].Selected = true;
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LabelMoveProfileDown_Click(object sender, EventArgs args)
        {
            try
            {
                if (listViewProfile.SelectedItems[0].Index == listViewProfile.Items.Count - 1) return;

                ListViewItem selectedItem = listViewProfile.SelectedItems[0];
                ListViewItem nextItem = listViewProfile.Items[selectedItem.Index + 1];
                int selectedItemIndex = selectedItem.Index;
                int nextItemIndex = nextItem.Index;

                Profile selectedProfile = null;
                Profile nextProfile = null;

                try
                {
                    selectedProfile = Profiles.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedProfile.ListViewIndex = nextItemIndex;
                    DBAccess.UpdateProfileListViewIndex(selectedProfile);

                    nextProfile = Profiles.Find(x => x.Id == int.Parse(nextItem.Tag.ToString()));
                    nextProfile.ListViewIndex = selectedItemIndex;
                    DBAccess.UpdateProfileListViewIndex(nextProfile);
                }
                catch (Exception)
                {
                    try
                    {
                        selectedProfile.ListViewIndex = selectedItem.Index;
                        nextProfile.ListViewIndex = nextItem.Index;
                        DBAccess.UpdateProfileListViewIndex(selectedProfile);
                        DBAccess.UpdateProfileListViewIndex(nextProfile);
                    }
                    catch (Exception) { }
                    throw;
                }

                ListViewItem selectedItemClone = (ListViewItem)selectedItem.Clone();
                ListViewItem nextItemClone = (ListViewItem)nextItem.Clone();

                listViewProfile.Items[selectedItemIndex] = nextItemClone;
                listViewProfile.Items[nextItemIndex] = selectedItemClone;

                listViewProfile.Items[nextItemIndex].Selected = true;
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FormProfileMenu_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.F2 && listViewProfile.SelectedItems.Count > 0)
                EditSelectedProfileName();
        }

        private void ToolStripMenuItemChangeName_Click(object sender, EventArgs e)
        {
            EditSelectedProfileName();
        }

        private void ToolStripMenuItemDeleteProfile_Click(object sender, EventArgs e)
        {
            DeleteSelectedProfiles();
        }

        private void ToolStripMenuItemClone_Click(object sender, EventArgs e)
        {
            Profile profile = Profiles.Find(x => x.Id == (int)listViewProfile.SelectedItems[0].Tag);

            Profile clonedProfile = profile.Clone();
            clonedProfile.Name = GenerateEnumeratedName(clonedProfile.Name);
            List<Options> clonedOptions = new();

            foreach (Options option in DBAccess.ListProfileOptions(profile))
            {
                Options clonedOption = option.Clone();
                clonedOption.Profile = clonedProfile;
                clonedOptions.Add(clonedOption);
            }

            clonedProfile.ListViewIndex = listViewProfile.Items.Count;
            DBAccess.AddProfile(clonedProfile);
            Profiles.Add(clonedProfile);

            foreach (Options clonedOption in clonedOptions)
                DBAccess.CreateOption(clonedOption);

            ListViewItem item = new();
            EditListViewItem(clonedProfile, item);
            listViewProfile.Items.Add(item);
            //ResizeForm();
        }

        private string GenerateEnumeratedName(string name)
        {
            int c = 1;
            string newName = $"{name} (cloned)";
            if (Profiles.Find(x => x.Name == newName) == null) return newName;

            while (true)
            {
                newName = $"{name} (cloned) ({c})";

                if (Profiles.Find(x => x.Name == newName) == null)
                    return newName;
                c++;
            }
        }

        private void ToolStripMenuItemGroup_Click(object sender, EventArgs e)
        {
            GroupForm form = new GroupForm(this);
            form.ShowDialog();
        }

        private void ToolStripMenuItemGenerateShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                List<Profile> selectedProfiles = listViewProfile.SelectedItems.Cast<ListViewItem>().Select(i => Profiles.Find(p => p.Id == (int)i.Tag)).ToList();
                saveFileDialogShortcut.DefaultExt = ".bat";
                saveFileDialogShortcut.Title = $"Generate profile shortcut - {selectedProfiles.Count} profile(s) selected";
                saveFileDialogShortcut.Filter = "BAT files (*.bat)|*.bat";

                if (saveFileDialogShortcut.ShowDialog() == DialogResult.OK)
                {
                    string content = $"\"{Program.WorkingDirectory}\\{Application.ProductName}.exe\" \"{string.Join(";", selectedProfiles.Select(p => p.Name))}\"{Environment.NewLine}pause";
                    File.WriteAllText(saveFileDialogShortcut.FileName, content);
                    MessageBox.Show($"File saved as \"{saveFileDialogShortcut.FileName}\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
