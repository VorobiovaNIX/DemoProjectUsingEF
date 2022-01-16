using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class FormPage
    {
        public FormPage()
        {
            FormFields = new HashSet<FormField>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public int FormVersionId { get; set; }
        public string Rules { get; set; }
        public string UniqueId { get; set; }

        public virtual FormVersion FormVersion { get; set; }
        public virtual ICollection<FormField> FormFields { get; set; }
    }
}
