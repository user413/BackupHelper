using FileControlUtility;
using System;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormErrorDialog : Form
    {
        private readonly Type ActionType;
        public object Result;

        public FormErrorDialog(Type actionType, string message)
        {
            InitializeComponent();
            textBoxErrorDialog.Text = message;
            textBoxErrorDialog.TabStop = false;
            ActionType = actionType;
            if (actionType == typeof(FileTransferErrorActionNonRepeatable))
                buttonTryAgain.Enabled = false;
        }

        private void ButtonErrorDialogIgnore_Click(object sender, EventArgs e)
        {
            if (ActionType == typeof(FileTransferErrorActionRepeatable))
                Result = FileTransferErrorActionRepeatable.JUMP;
            if (ActionType == typeof(FileTransferErrorActionNonRepeatable))
                Result = FileTransferErrorActionNonRepeatable.JUMP;

            Close();
        }

        private void ButtonErrorDialogCancel_Click(object sender, EventArgs e)
        {
            if (ActionType == typeof(FileTransferErrorActionRepeatable))
                Result = FileTransferErrorActionRepeatable.CANCEL;
            if (ActionType == typeof(FileTransferErrorActionNonRepeatable))
                Result = FileTransferErrorActionNonRepeatable.CANCEL;

            Close();
        }

        private void ButtonTryAgain_Click(object sender, EventArgs e)
        {
            Result = FileTransferErrorActionRepeatable.REPEAT;
            Close();
        }
    }
}
