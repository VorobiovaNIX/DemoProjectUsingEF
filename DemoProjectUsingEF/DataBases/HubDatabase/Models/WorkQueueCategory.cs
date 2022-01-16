using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class WorkQueueCategory
    {
        public WorkQueueCategory()
        {
            ConnectWorkQueues = new HashSet<ConnectWorkQueue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConnectWorkQueue> ConnectWorkQueues { get; set; }
    }
}
