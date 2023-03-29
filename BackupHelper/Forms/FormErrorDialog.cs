using FileControlUtility;

namespace BackupHelper
{
    public partial class FormErrorDialog : Form
    {
        //private readonly Type ActionType;
        //public object Result;
        public TransferErrorAction Result;

        //public FormErrorDialog(Type actionType, string message)
        public FormErrorDialog(string message)
        {
            InitializeComponent();
            textBoxErrorDialog.Text = message;
            textBoxErrorDialog.TabStop = false;
            //ActionType = actionType;
            //if (actionType == typeof(FileTransferErrorActionNonRepeatable))
            //    buttonTryAgain.Enabled = false;
        }

        private void ButtonErrorDialogIgnore_Click(object sender, EventArgs e)
        {
            //if (ActionType == typeof(FileTransferErrorActionRepeatable))
            //    Result = FileTransferErrorActionRepeatable.SKIP;
            //if (ActionType == typeof(FileTransferErrorActionNonRepeatable))
            //    Result = FileTransferErrorActionNonRepeatable.SKIP;

            Result = TransferErrorAction.SKIP;
            Close();
        }

        private void ButtonErrorDialogCancel_Click(object sender, EventArgs e)
        {
            //if (ActionType == typeof(FileTransferErrorActionRepeatable))
            //    Result = FileTransferErrorActionRepeatable.CANCEL;
            //if (ActionType == typeof(FileTransferErrorActionNonRepeatable))
            //    Result = FileTransferErrorActionNonRepeatable.CANCEL;

            Result = TransferErrorAction.CANCEL;
            Close();
        }

        private void ButtonTryAgain_Click(object sender, EventArgs e)
        {
            //Result = FileTransferErrorActionRepeatable.REPEAT;
            Result = TransferErrorAction.RETRY;
            Close();
        }
    }
}
