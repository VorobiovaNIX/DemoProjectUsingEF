using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectVirtualWorker
    {
        public ConnectVirtualWorker()
        {
            VirtualWorkerAppAccesses = new HashSet<VirtualWorkerAppAccess>();
            VirtualWorkerBusinessProcesses = new HashSet<VirtualWorkerBusinessProcess>();
        }

        public int Id { get; set; }
        public Guid ResourceId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string AvatarBase64 { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public int CategoryId { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDebug { get; set; }
        public bool IsQuickLaunch { get; set; }
        public int? EnvironmentId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ConnectWorkerCategory Category { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual ICollection<VirtualWorkerAppAccess> VirtualWorkerAppAccesses { get; set; }
        public virtual ICollection<VirtualWorkerBusinessProcess> VirtualWorkerBusinessProcesses { get; set; }
    }
}
