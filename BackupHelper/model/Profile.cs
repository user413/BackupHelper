using System;
using System.Collections.Generic;

namespace BackupHelper.model
{
    public class Profile
    {
        public int Id { get; set; }
        public int ListViewIndex { get; set; }
        public string Name { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime LastTimeModified { get; set; }
        public DateTime LastTimeExecuted { get; set; }
        public List<Option> Options { get; set; }

    }
}
