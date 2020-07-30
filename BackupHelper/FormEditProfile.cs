using BackupHelper.model;
using System;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormEditProfile : Form
    {
        readonly Profile Profile;
        readonly FormProfileMenu ProfileMenu;

        public FormEditProfile(FormProfileMenu menu, Profile profile)
        {
            this.ProfileMenu = menu;
            this.Profile = profile;
            InitializeComponent();
            textBoxProfileName.Text = profile.Name;
            textBoxProfileName.AcceptsReturn = false;
            this.KeyPreview = true;
        }

        private void ButtonSaveProfile_Click(object sender, EventArgs e)
        {
            EditProfileName();
        }
        private void TextBoxProfileName_KeyDown(object o,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                EditProfileName();
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void EditProfileName()
        {
            try
            {
                if (textBoxProfileName.Text == "")
                {
                    MessageBox.Show("Invalid name.");
                    return;
                }
                this.Profile.Name = textBoxProfileName.Text;
                this.ProfileMenu.ChangeProfileName(Profile);
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
