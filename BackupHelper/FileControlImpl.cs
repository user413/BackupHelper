using FileControlUtility;
using System;

namespace BackupHelper
{
    public class FileControlImpl : FileControl
    {
        private readonly FormOptionsMenu Menu;

        public FileControlImpl(FormOptionsMenu menu)
        {
            Menu = menu;
        }

        public override void HandleCurrentFileExecution(string trimmedPathWithFileName)
        {
            if (trimmedPathWithFileName.Length > 100)
                trimmedPathWithFileName = $"...{trimmedPathWithFileName.Substring(trimmedPathWithFileName.Length - 100)}";

            Menu.ShowCurrentFileExecution(trimmedPathWithFileName);
        }

        public override FileTransferErrorActionNonRepeatable HandleErrorDialogNonRepeatable(string errorMessage, Exception e, string originFile, string destinyFile)
        {
            FormErrorDialog form = new FormErrorDialog(typeof(FileTransferErrorActionNonRepeatable), errorMessage);
            form.ShowDialog();
            return (FileTransferErrorActionNonRepeatable)form.Result;
        }

        public override FileTransferErrorActionRepeatable HandleErrorDialogRepeatable(string errorMessage, Exception e, string originFile, string destinyFile)
        {
            FormErrorDialog form = new FormErrorDialog(typeof(FileTransferErrorActionRepeatable), errorMessage);
            form.ShowDialog();
            return (FileTransferErrorActionRepeatable)form.Result;
        }

        public override void HandleLogMessage(string logMessage)
        {
            LogManager.WriteLine(logMessage);
        }
    }
}
