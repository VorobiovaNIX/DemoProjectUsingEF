using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectWorkerCategory
    {
        public ConnectWorkerCategory()
        {
            ConnectVirtualWorkers = new HashSet<ConnectVirtualWorker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConnectVirtualWorker> ConnectVirtualWorkers { get; set; }
    }
}
