using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class BusinessProcessCategory
    {
        public BusinessProcessCategory()
        {
            BusinessProcessForms = new HashSet<BusinessProcessForm>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BusinessProcessForm> BusinessProcessForms { get; set; }
    }
}
