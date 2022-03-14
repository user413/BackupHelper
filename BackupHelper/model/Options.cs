using FileControlUtility;
using System.Linq;

namespace BackupHelper.model
{
    public class Options : TransferSettings
    {
        public int Id { get; set; }
        public bool AllowIgnoreFileExt { get; set; }
        public int ListViewIndex { get; set; }
        public Profile Profile { get; set; }

        public Options()
        {
            SpecifiedFileNamesAndExtensions = new System.Collections.Generic.List<string>();
        }

        public Options Clone()
        {
            Options optionClone = (Options)MemberwiseClone();
            optionClone.SpecifiedFileNamesAndExtensions = SpecifiedFileNamesAndExtensions.ToList();
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
