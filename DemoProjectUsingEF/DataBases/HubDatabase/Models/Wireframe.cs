using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Wireframe
    {
        public Wireframe()
        {
            WireframeObjects = new HashSet<WireframeObject>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifedDate { get; set; }
        public bool Shared { get; set; }
        public bool Deployed { get; set; }
        public Guid ClonedFrom { get; set; }
        public byte[] Timestamp { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ModifiedByUserId { get; set; }
        public int? LockedByUserId { get; set; }
        public int? EnvironmentId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual User LockedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual ICollection<WireframeObject> WireframeObjects { get; set; }
    }
}
