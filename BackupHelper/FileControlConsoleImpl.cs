using FileControlUtility;
using System;
using System.IO;

namespace BackupHelper
{
    public class FileControlConsoleImpl : FileControl
    {
        private readonly bool showDialogs;

        public FileControlConsoleImpl(bool showDialogs)
        {
            this.showDialogs = showDialogs;
        }

        protected override void HandleCurrentFileExecution(string trimmedPathWithFileName, FileInfo originFile, string destinyDir, TransferSettings settings)
        {
            //Console.WriteLine($"Transfering: {trimmedPathWithFileName}");
        }

        protected override FileTransferErrorActionNonRepeatable HandleTransferErrorNonRepeatable(string errorMessage, Exception e, FileInfo originFile, 
            string destinyDir, TransferSettings settings)
        {
            if (!showDialogs) return FileTransferErrorActionNonRepeatable.SKIP;

            FormErrorDialog form = new FormErrorDialog(typeof(FileTransferErrorActionNonRepeatable), errorMessage);
            form.ShowDialog();
            return (FileTransferErrorActionNonRepeatable)form.Result;
        }

        protected override FileTransferErrorActionRepeatable HandleTransferErrorRepeatable(string errorMessage, Exception e, FileInfo originFile, 
            string destinyDir, TransferSettings settings)
        {
            if (!showDialogs) return FileTransferErrorActionRepeatable.SKIP;

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
