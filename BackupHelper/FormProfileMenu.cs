using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BackupHelper
{
    public enum ListViewProfileSubItemIndex
    {
        INDEX_NAME = 0,
        INDEX_TIME_EXECUTED = 1,
        INDEX_TIME_MODIFIED = 2,
        INDEX_CREATED_AT = 3
    }

    public partial class FormProfileMenu : Form
    {
        public List<Profile> Profiles;
        public FormReport LastReport;

        //--FORM RESIZING VARIABLES
        private readonly int InitialFormWidth;
        private readonly int InitialFormHeight;
        private readonly int ListProfileHeight = 17;
        private readonly int AditionalListViewItemCount = 6;
        private readonly int InitialListViewItemCount = 10;
        private readonly int MaximumListViewItemCount;

        public FormProfileMenu()
        {
            InitializeComponent();
            KeyPreview = true;
            listViewProfile.KeyDown += new KeyEventHandler(this.FormProfileMenu_KeyDown);
            InitialFormWidth = this.Bounds.Width;
            InitialFormHeight = this.Bounds.Height;
            AditionalListViewItemCount = 6;
            InitialListViewItemCount = 10;
            MaximumListViewItemCount = AditionalListViewItemCount + InitialListViewItemCount;
            LoadListView();
        }

        private void LoadListView()
        {
            try
            {
                this.Profiles = DBAccess.ListProfiles().OrderBy(x => x.ListViewIndex).ToList();
                
                foreach (Profile prof in Profiles)
                {
                    ListViewItem item = new ListViewItem();
                    EditListViewItem(prof, item);
                    listViewProfile.Items.Add(item);
                }

                ResizeForm();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateProfileListViewIndexes()
        {
            foreach (ListViewItem item in listViewProfile.Items)
            {
                Profile profile = Profiles.Find(x => x.Id == int.Parse(item.Tag.ToString()));
                int currentIndex = profile.ListViewIndex;

                try
                {
                    profile.ListViewIndex = item.Index;
                    DBAccess.UpdateProfileListViewIndex(profile);
                }
                catch (Exception)
                {
                    try
                    {
                        profile.ListViewIndex = currentIndex;
                        DBAccess.UpdateProfileListViewIndex(profile);
                    }
                    catch (Exception) { }
                    throw;
                }
            }
        }

        public void ResizeForm()
        {
            //-- CHANGING FORM HEIGHT RESPONSIVELY DEPENDING ON NUMBER OF PROFILES
            if (this.Profiles.Count() > InitialListViewItemCount && this.Profiles.Count() < MaximumListViewItemCount)
                this.Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (this.Profiles.Count() - InitialListViewItemCount) * ListProfileHeight);
            else if (this.Profiles.Count() >= MaximumListViewItemCount)
                this.Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight + (ListProfileHeight * AditionalListViewItemCount));
            else if (this.Bounds.Height != InitialFormHeight)
                this.Size = new System.Drawing.Size(InitialFormWidth, InitialFormHeight);
        }

        private void ListViewProfileItem_DoubleClick(object sender, EventArgs args)
        {
            OpenSelectedProfile();
        }

        private void OpenSelectedProfile()
        {
            try
            {
                if(listViewProfile.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Click a profile first.");
                    return;
                }

                FormOptionsMenu optionsMenu = new FormOptionsMenu(this,
                    Profiles.Find(x => x.Id == int.Parse(listViewProfile.SelectedItems[0].Tag.ToString())));

                optionsMenu.Show(this);
                this.Hide();
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
            item.SubItems.AddRange(new string[] {
                profile.LastTimeModified == DateTime.MinValue ? "Never" : profile.LastTimeModified.ToString(),
                profile.LastTimeExecuted == DateTime.MinValue ? "Never" : profile.LastTimeExecuted.ToString(),
                profile.TimeCreated.ToString(),
            });
        }

        private void EditSelectedProfileName()
        {
            try
            {
                if (listViewProfile.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Click a profile first.");
                    return;
                }

                FormEditProfile edit = new FormEditProfile(this,
                    Profiles.Find(x => x.Id == int.Parse(listViewProfile.SelectedItems[0].Tag.ToString())));

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

        private void DeleteSelectedProfile()
        {
            try
            {
                ListViewItem selectedItem = listViewProfile.SelectedItems[0];
                Profile profile = Profiles.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                string text = $"Delete \"{profile.Name}\"?";

                if (MessageBox.Show(text, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DBAccess.DeleteProfile(profile);
                    Profiles.Remove(profile);
                    listViewProfile.Items.Remove(selectedItem);
                    UpdateProfileListViewIndexes();
                    ResizeForm();
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
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt");
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
                if (listViewProfile.SelectedItems.Count > 0) DeleteSelectedProfile();
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
            foreach(ListViewItem item in listViewProfile.Items)
                if (int.Parse(item.Tag.ToString()) == id) return item;
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
                    catch (Exception){}
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
            DeleteSelectedProfile();
        }

        private void ToolStripMenuItemClone_Click(object sender, EventArgs e)
        {
            Profile profile = Profiles.Find(x => x.Id == int.Parse(listViewProfile.SelectedItems[0].Tag.ToString()));

            Profile clonedProfile = profile.Clone();
            clonedProfile.Name = GenerateEnumeratedName(clonedProfile.Name);
            List<Option> clonedOptions = new List<Option>();

            foreach (Option option in DBAccess.ListProfileOptions(profile))
            {
                Option clonedOption= option.Clone();
                clonedOption.Profile = clonedProfile;
                clonedOptions.Add(clonedOption);
            }

            clonedProfile.ListViewIndex = listViewProfile.Items.Count;
            DBAccess.AddProfile(clonedProfile);
            Profiles.Add(clonedProfile);

            foreach (Option clonedOption in clonedOptions)
                DBAccess.AddOption(clonedOption);

            ListViewItem item = new ListViewItem();
            EditListViewItem(clonedProfile, item);
            listViewProfile.Items.Add(item);
            ResizeForm();
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
    }
}
