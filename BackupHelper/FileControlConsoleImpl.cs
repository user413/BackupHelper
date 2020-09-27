using FileControlUtility;
using System;

namespace BackupHelper
{
    public class FileControlConsoleImpl : FileControl
    {
        private readonly bool showDialogs;

        public FileControlConsoleImpl(bool showDialogs)
        {
            this.showDialogs = showDialogs;
        }

        public override void HandleCurrentFileExecution(string trimmedPathWithFileName)
        {
            Console.WriteLine($"Transfering: {trimmedPathWithFileName}");
        }

        public override FileTransferErrorActionNonRepeatable HandleErrorDialogNonRepeatable(string errorMessage, Exception e, string originFile, string destinyFile)
        {
            if (!showDialogs) return FileTransferErrorActionNonRepeatable.JUMP;

            FormErrorDialog form = new FormErrorDialog(typeof(FileTransferErrorActionNonRepeatable), errorMessage);
            form.ShowDialog();
            return (FileTransferErrorActionNonRepeatable)form.Result;
        }

        public override FileTransferErrorActionRepeatable HandleErrorDialogRepeatable(string errorMessage, Exception e, string originFile, string destinyFile)
        {
            if (!showDialogs) return FileTransferErrorActionRepeatable.JUMP;

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
