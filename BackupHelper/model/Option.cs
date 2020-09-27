using FileControlUtility;
using System.Linq;

namespace BackupHelper.model
{
    public class Option : TransferSettings
    {
        public int Id { get; set; }
        public int ListViewIndex { get; set; }
        public Profile Profile { get; set; }

        public Option Clone()
        {
            Option optionClone = (Option)this.MemberwiseClone();
            optionClone.SpecifiedFileNamesAndExtensions = this.SpecifiedFileNamesAndExtensions.ToList();
            return optionClone;
        }

        public string GetTransferMethodDescription(FileNameConflictMethod fileNameConflictMethod)
        {
            switch (fileNameConflictMethod)
            {
                case FileNameConflictMethod.DO_NOT_MOVE:
                    return "Do not move";
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
