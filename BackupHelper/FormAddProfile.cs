using BackupHelper.model;
using System;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormAddProfile : Form
    {
        readonly FormProfileMenu ProfileMenu;
        public FormAddProfile(FormProfileMenu menu)
        {
            InitializeComponent();
            this.ProfileMenu = menu;
            this.KeyPreview = true;
        }

        private void ButtonSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }
        private void TextBoxProfileName_KeyDown(object sender , KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Enter)
                SaveProfile();
            else if (args.KeyCode == Keys.Escape)
                this.Close();
        }
        private void SaveProfile()
        {
            if (textBoxProfileName.Text == "")
            {
                MessageBox.Show("Invalid name.");
                return;
            }
            Profile prof = new Profile
            {
                Name = textBoxProfileName.Text,
                TimeCreated = DateTime.Now, //yyyy-MM-dd HH:mm:ss,
                LastTimeModified = DateTime.MinValue,
                LastTimeExecuted = DateTime.MinValue
            };
            this.ProfileMenu.AddProfile(prof);
            this.Close();
        }
    }
}
