using System;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormErrorDialog : Form
    {
        private readonly FormOptionsMenu OptionsMenu;

        public FormErrorDialog(FormOptionsMenu menu, string message, bool enableRepeatButton)
        {
            InitializeComponent();
            textBoxErrorDialog.Text = message;
            this.OptionsMenu = menu;
            this.buttonTryAgain.Enabled = enableRepeatButton;
        }

        private void ButtonErrorDialogIgnore_Click(object sender, EventArgs e)
        {
            this.OptionsMenu.FileControl.JumpFileExecution = true;
            this.OptionsMenu.FileControl.RepeatFileExecution = false;
            LogManager.WriteLine("Continued by the user");
            this.Close();
        }

        private void ButtonErrorDialogCancel_Click(object sender, EventArgs e)
        {
            this.OptionsMenu.FileControl.CancelExecution = true;
            this.OptionsMenu.FileControl.RepeatFileExecution = false;
            LogManager.WriteLine("Canceled by user...");
            this.Close();
        }

        private void ButtonTryAgain_Click(object sender, EventArgs e)
        {
            this.OptionsMenu.FileControl.RepeatFileExecution = true;
            LogManager.WriteLine("Repeated by user...");
            this.Close();
        }
    }
}
