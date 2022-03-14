using FileControlUtility;
using System;
using System.IO;

namespace BackupHelper
{
    public class FileControlImpl : FileControl
    {
        private readonly FormOptionsMenu Menu;

        public FileControlImpl(FormOptionsMenu menu)
        {
            Menu = menu;
        }

        protected override void HandleCurrentFileExecution(string trimmedPathWithFileName, FileInfo originFile, string destinyDir, TransferSettings settings)
        {
            if (trimmedPathWithFileName.Length > 100)
                trimmedPathWithFileName = $"...{trimmedPathWithFileName.Substring(trimmedPathWithFileName.Length - 100)}";

            Menu.ShowCurrentFileExecution(trimmedPathWithFileName);
        }

        protected override FileTransferErrorActionNonRepeatable HandleTransferErrorNonRepeatable(string errorMessage, Exception e, FileInfo originFile,
            string destinyDir, TransferSettings settings)
        {
            FormErrorDialog form = new FormErrorDialog(typeof(FileTransferErrorActionNonRepeatable), errorMessage);
            form.ShowDialog();
            return (FileTransferErrorActionNonRepeatable)form.Result;
        }

        protected override FileTransferErrorActionRepeatable HandleTransferErrorRepeatable(string errorMessage, Exception e, FileInfo originFile,
            string destinyDir, TransferSettings settings)
        {
            FormErrorDialog form = new FormErrorDialog(typeof(FileTransferErrorActionRepeatable), errorMessage);
            form.ShowDialog();
            return (FileTransferErrorActionRepeatable)form.Result;
        }

        protected override void HandleLogMessage(string logMessage)
        {
            LogManager.WriteLine(logMessage);
        }
    }
}
