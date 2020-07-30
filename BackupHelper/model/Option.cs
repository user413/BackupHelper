using System;
using System.Collections.Generic;

namespace BackupHelper.model
{
    public enum TransferMethodType
    {
        TYPE_DO_NOT_MOVE = 1,
        TYPE_REPLACE_ALL = 2,
        TYPE_REPLACE_DIFFERENT = 3,
        TYPE_RENAME_DIFFERENT = 4
    }

    public class Option : ICloneable
    {
        public int Id { get; set; }
        public int ListViewIndex { get; set; }
        public string SourcePath { get; set; }
        public string DestinyPath { get; set; }
        public bool MoveSubFolders { get; set; }
        public bool KeepOriginFiles { get; set; }
        public bool CleanDestinyDirectory { get; set; }
        public bool DeleteUncommonFiles { get; set; }
        public bool AllowIgnoreFileExt { get; set; }
        public Profile Profile { get; set; }
        public TransferMethod TransferMethod { get; set; }
        public List<FileExtension> AllowOnlyFileExtensions { get; set; }
        public List<FileExtension> IgnoredFileExtensions { get; set; }
        public void AddAllowOnlyFileExtension(FileExtension ext)
        {
            this.AllowOnlyFileExtensions.Add(ext);
        }
        public void AddIgnoredFileExtensions(FileExtension ext)
        {
            this.IgnoredFileExtensions.Add(ext);
        }

        public object Clone()
        {
            Option optionClone = (Option)this.MemberwiseClone();
            
            optionClone.AllowOnlyFileExtensions = new List<FileExtension>();
            this.AllowOnlyFileExtensions.ForEach((ext) =>
            {
                optionClone.AllowOnlyFileExtensions.Add((FileExtension)ext);
            });
            optionClone.IgnoredFileExtensions = new List<FileExtension>();
            this.IgnoredFileExtensions.ForEach((ext) =>
            {
                optionClone.IgnoredFileExtensions.Add((FileExtension)ext);
            });

            return optionClone;
        }
    }
}
