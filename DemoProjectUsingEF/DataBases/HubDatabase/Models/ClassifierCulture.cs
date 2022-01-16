using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ClassifierCulture
    {
        public ClassifierCulture()
        {
            ClassifierApplications = new HashSet<ClassifierApplication>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<ClassifierApplication> ClassifierApplications { get; set; }
    }
}
