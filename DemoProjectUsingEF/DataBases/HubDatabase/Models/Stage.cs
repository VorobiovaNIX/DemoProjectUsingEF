using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Stage
    {
        public Stage()
        {
            BusinessProcesses = new HashSet<BusinessProcess>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual ICollection<BusinessProcess> BusinessProcesses { get; set; }
    }
}
