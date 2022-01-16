using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class WireframeAction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Published { get; set; }
        public byte[] Timestamp { get; set; }
        public Guid WireframeObjectId { get; set; }

        public virtual WireframeObject WireframeObject { get; set; }
    }
}
