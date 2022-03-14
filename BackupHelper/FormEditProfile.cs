using BackupHelper.model;
using System;
using System.IO;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormEditProfile : Form
    {
        private enum FormEditProfileAction { ADD, EDIT }

        private readonly Profile Profile;
        private readonly FormProfileMenu ProfileMenu;
        private readonly FormEditProfileAction Action = FormEditProfileAction.EDIT;

        public FormEditProfile(FormProfileMenu menu, Profile profile = null)
        {
            InitializeComponent();
            textBoxProfileName.AcceptsReturn = false;
            KeyPreview = true;
            ProfileMenu = menu;

            if (profile == null)
            {
                Action = FormEditProfileAction.ADD;
                Text = "Add profile";
                textBoxProfileName.Text = "New Profile";
            }
            else
            {
                Profile = profile;
                textBoxProfileName.Text = profile.Name;
            }
        }

        private void ButtonSaveProfile_Click(object sender, EventArgs args)
        {
            SaveProfile();
        }

        private void SaveProfile()
        {
            if (Action == FormEditProfileAction.EDIT && textBoxProfileName.Text == Profile.Name)
            {
                Close();
                return;
            }

            if (textBoxProfileName.Text == "")
            {
                MessageBox.Show("Invalid name.");
                return;
            }

            if (textBoxProfileName.Text.Contains(";"))
            {
                MessageBox.Show("Name contains the reserved character \";\".");
                return;
            }

            if (TextContainsInvalidCharacters(textBoxProfileName.Text))
            {
                MessageBox.Show("Name contains invalid characters.");
                return;
            }

            if (ProfileMenu.Profiles.Exists(p => p.Name == textBoxProfileName.Text))
            {
                MessageBox.Show("Name already exists.");
                return;
            }

            try
            {
                if (Action == FormEditProfileAction.EDIT)
                    EditProfileName();
                else
                    AddProfile();

                Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddProfile()
        {
            Profile profile = new Profile
            {
                Name = textBoxProfileName.Text,
                TimeCreated = DateTime.Now, //yyyy-MM-dd HH:mm:ss,
                LastTimeModified = DateTime.MinValue,
                LastTimeExecuted = DateTime.MinValue
            };

            profile.ListViewIndex = ProfileMenu.listViewProfile.Items.Count;
            DBAccess.AddProfile(profile);
            ProfileMenu.Profiles.Add(profile);
            ListViewItem item = new ListViewItem();
            ProfileMenu.EditListViewItem(profile, item);
            ProfileMenu.listViewProfile.Items.Add(item);
            //ProfileMenu.ResizeForm();
        }

        private void EditProfileName()
        {
            Profile.Name = textBoxProfileName.Text;
            DBAccess.UpdateProfile(Profile);
            ProfileMenu.EditListViewItem(Profile);
        }

        private void TextBoxProfileName_KeyDown(object o, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveProfile();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private bool TextContainsInvalidCharacters(string text)
        {
            foreach (char s in Path.GetInvalidFileNameChars())
                if (text.Contains(s.ToString())) return true;

            return false;
        }
    }
}
