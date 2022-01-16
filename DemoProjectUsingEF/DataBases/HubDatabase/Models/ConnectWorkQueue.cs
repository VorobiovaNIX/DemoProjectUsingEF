using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectWorkQueue
    {
        public ConnectWorkQueue()
        {
            BusinessProcessForms = new HashSet<BusinessProcessForm>();
        }

        public int Id { get; set; }
        public Guid RemoteId { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public int? CategoryId { get; set; }
        public int? EnvironmentId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual WorkQueueCategory Category { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual ICollection<BusinessProcessForm> BusinessProcessForms { get; set; }
    }
}
