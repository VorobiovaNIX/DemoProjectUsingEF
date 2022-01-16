using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectivityMethod
    {
        public ConnectivityMethod()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public bool Predefined { get; set; }
        public int UniqueId { get; set; }
        public int? DefinedByUserId { get; set; }

        public virtual User DefinedByUser { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
