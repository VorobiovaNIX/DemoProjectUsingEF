using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class WireframeObject
    {
        public WireframeObject()
        {
            WireframeActions = new HashSet<WireframeAction>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Timestamp { get; set; }
        public Guid WireframeId { get; set; }
        public string Type { get; set; }

        public virtual Wireframe Wireframe { get; set; }
        public virtual ICollection<WireframeAction> WireframeActions { get; set; }
    }
}
