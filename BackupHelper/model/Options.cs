using FileControlUtility;

namespace BackupHelper.model
{
    public class Options : TransferSettings
    {
        public int Id { get; set; }
        public bool FilterFilesAndExts { get; set; }
        public bool FilterDirectories { get; set; }
        public int ListViewIndex { get; set; }
        public Profile Profile { get; set; }

        public Options()
        {
            FilteredFileNamesAndExtensions = new List<string>();
            FilteredDirectories = new List<string>();
        }

        public Options Clone()
        {
            Options optionClone = (Options)MemberwiseClone();
            optionClone.FilteredFileNamesAndExtensions = FilteredFileNamesAndExtensions.ToList();
            optionClone.FilteredDirectories = FilteredDirectories.ToList();
            return optionClone;
        }

        public string GetTransferMethodDescription(FileNameConflictMethod fileNameConflictMethod)
        {
            switch (fileNameConflictMethod)
            {
                case FileNameConflictMethod.SKIP:
                    return "Skip";
                case FileNameConflictMethod.REPLACE_ALL:
                    return "Replace all";
                case FileNameConflictMethod.REPLACE_DIFFERENT:
                    return "Replace only different files (binary comparison)";
                case FileNameConflictMethod.RENAME_DIFFERENT:
                    return "Rename different files (binary comparison)";
            }

            return "";
        }
    }
}
