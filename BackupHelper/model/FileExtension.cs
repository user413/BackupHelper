using System;
using System.Collections.Generic;

namespace BackupHelper.model
{
    public class FileExtension : ICloneable
    {
        public int Id { get; set; }
        public string ExtensionName { get; set; }
        public Option Option { get; set; }

        public object Clone()
        {
            FileExtension fileExtensionClose = (FileExtension)this.MemberwiseClone();
            //fileExtensionClose.Option = this.Option;
            return fileExtensionClose;
        }

        public override bool Equals(object obj)
        {
            return obj is FileExtension extension &&
                   ExtensionName == extension.ExtensionName &&
                   EqualityComparer<Option>.Default.Equals(Option, extension.Option);
        }

        public override int GetHashCode()
        {
            var hashCode = 260826493;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ExtensionName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Option>.Default.GetHashCode(Option);
            return hashCode;
        }
    }
}
