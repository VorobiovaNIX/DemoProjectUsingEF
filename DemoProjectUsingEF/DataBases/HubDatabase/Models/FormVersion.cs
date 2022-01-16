using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class FormVersion
    {
        public FormVersion()
        {
            FormPages = new HashSet<FormPage>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLatest { get; set; }
        public bool IsDraft { get; set; }
        public string Version { get; set; }
        public string UpdatedNote { get; set; }
        public int? UpdatedByUserId { get; set; }
        public int BusinessProcessFormId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ImportedFileName { get; set; }

        public virtual BusinessProcessForm BusinessProcessForm { get; set; }
        public virtual User UpdatedByUser { get; set; }
        public virtual ICollection<FormPage> FormPages { get; set; }
    }
}
