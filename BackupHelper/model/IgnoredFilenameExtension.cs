using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupHelper.model
{
    public class IgnoredFilenameExtension
    {
        public int Id { get; set; }
        public string ExtensionName { get; set; }
        public Option Option { get; set; }
    }
}
