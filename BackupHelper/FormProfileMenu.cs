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
        private List<Profile> Profiles;
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
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEditProfile_KeyDown);
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
                ProfileAccess pf = new ProfileAccess();
                this.Profiles = pf.ListProfiles().OrderBy(x => x.ListViewIndex).ToList();
                
                foreach (Profile prof in Profiles)
                {
                    ListViewItem item = new ListViewItem();
                    EditListViewItem(item, prof);
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
            ProfileAccess pa = new ProfileAccess();

            foreach (ListViewItem item in listViewProfile.Items)
            {
                Profile profile = Profiles.Find(x => x.Id == int.Parse(item.Tag.ToString()));
                int currentIndex = profile.ListViewIndex;

                try
                {
                    profile.ListViewIndex = item.Index;
                    pa.UpdateProfileListViewIndex(profile);
                }
                catch (Exception)
                {
                    try
                    {
                        profile.ListViewIndex = currentIndex;
                        pa.UpdateProfileListViewIndex(profile);
                    }
                    catch (Exception) { }
                    throw;
                }
            }
        }

        private void ResizeForm()
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
                FormOptionsMenu optionMenu = new FormOptionsMenu(this,
                    Profiles.Find(x => x.Id == int.Parse(listViewProfile.SelectedItems[0].Tag.ToString())));
                optionMenu.Show(this);
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
                FormAddProfile addProfile = new FormAddProfile(this);
                addProfile.ShowDialog(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditListViewItem(ListViewItem item, Profile profile)
        {
            string[] range = Enumerable.Repeat("", Enum.GetNames(typeof(ListViewProfileSubItemIndex)).Length).ToArray();
            item.SubItems.AddRange(range);
            item.Tag = profile.Id;
            item.SubItems[(int)ListViewProfileSubItemIndex.INDEX_NAME].Text = profile.Name;
            item.SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_MODIFIED].Text = profile.LastTimeModified == DateTime.MinValue ? "Never" : profile.LastTimeModified.ToString();
            item.SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_EXECUTED].Text = profile.LastTimeExecuted == DateTime.MinValue ? "Never" : profile.LastTimeExecuted.ToString();
            item.SubItems[(int)ListViewProfileSubItemIndex.INDEX_CREATED_AT].Text = profile.TimeCreated.ToString();
        }

        public void AddProfile(Profile profile)
        {
            ProfileAccess pa = new ProfileAccess();
            profile.ListViewIndex = listViewProfile.Items.Count;
            pa.AddProfile(profile);
            Profiles.Add(profile);
            ListViewItem item = new ListViewItem();
            EditListViewItem(item, profile);
            listViewProfile.Items.Add(item);
            ResizeForm();
        }

        private void ButtonEditProfile_Click(object sender, EventArgs args)
        {
            ShowEditProfileForm();
        }

        private void ShowEditProfileForm()
        {
            try
            {
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

        public void ChangeProfileName(Profile profile)
        {
            ProfileAccess pa = new ProfileAccess();
            pa.UpdateProfile(profile);
            listViewProfile.SelectedItems[0].Text = profile.Name;
        }

        private void ButtonDeleteProfile_Click(object sender, EventArgs args)
        {
            DeleteSelectedProfile();
        }

        private void DeleteSelectedProfile()
        {
            try
            {
                ListViewItem selectedItem = listViewProfile.SelectedItems[0];
                FormConfirmAction form = new FormConfirmAction("Delete selected profile...");
                form.ShowDialog();
                if (form.ActionIsConfirmed)
                {
                    ProfileAccess pa = new ProfileAccess();
                    Profile profile = Profiles.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    pa.DeleteProfile(profile);
                    Profiles.Remove(profile);
                    listViewProfile.Items.Remove(selectedItem);
                    UpdateProfileListViewIndexes();
                    ResizeForm();
                }
                form.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a profile for deleting.");
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

        public void UpdateLastTimeModified(Profile profile)
        { 
            ProfileAccess pa = new ProfileAccess();
            profile.LastTimeModified = DateTime.Now;
            pa.UpdateProfile(profile);
            GetListViewItemById(profile.Id).SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_MODIFIED].Text = profile.LastTimeModified.ToString();
        }

        public void UpdateLastTimeExecuted(Profile profile)
        {
            ProfileAccess pa = new ProfileAccess();
            profile.LastTimeExecuted = DateTime.Now;
            pa.UpdateProfile(profile);
            GetListViewItemById(profile.Id).SubItems[(int)ListViewProfileSubItemIndex.INDEX_TIME_EXECUTED].Text = profile.LastTimeExecuted.ToString();
        }

        private ListViewItem GetListViewItemById(int id)
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

                ProfileAccess pa = new ProfileAccess();

                try
                {
                    selectedProfile = Profiles.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedProfile.ListViewIndex = selectedItem.Index - 1;
                    pa.UpdateProfileListViewIndex(selectedProfile);

                    previousProfile = Profiles.Find(x => x.Id == int.Parse(previousItem.Tag.ToString()));
                    previousProfile.ListViewIndex = selectedItem.Index;
                    pa.UpdateProfileListViewIndex(previousProfile);
                }
                catch (Exception)
                {
                    selectedProfile.ListViewIndex = selectedItem.Index;
                    previousProfile.ListViewIndex = previousItem.Index;
                    pa.UpdateProfileListViewIndex(selectedProfile);
                    pa.UpdateProfileListViewIndex(previousProfile);
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

                ProfileAccess pa = new ProfileAccess();

                try
                {
                    selectedProfile = Profiles.Find(x => x.Id == int.Parse(selectedItem.Tag.ToString()));
                    selectedProfile.ListViewIndex = nextItemIndex;
                    pa.UpdateProfileListViewIndex(selectedProfile);

                    nextProfile = Profiles.Find(x => x.Id == int.Parse(nextItem.Tag.ToString()));
                    nextProfile.ListViewIndex = selectedItemIndex;
                    pa.UpdateProfileListViewIndex(nextProfile);
                }
                catch (Exception)
                {
                    try
                    {
                        selectedProfile.ListViewIndex = selectedItem.Index;
                        nextProfile.ListViewIndex = nextItem.Index;
                        pa.UpdateProfileListViewIndex(selectedProfile);
                        pa.UpdateProfileListViewIndex(nextProfile);
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

        private void FormEditProfile_KeyDown(object sender,KeyEventArgs args)
        {
            if (args.KeyCode == Keys.F2 && listViewProfile.SelectedItems.Count > 0)
                ShowEditProfileForm();
        }
    }
}
