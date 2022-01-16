using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ClassifierEndpoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VersionId { get; set; }
        public bool IsStaging { get; set; }
        public string EndpointUrl { get; set; }
        public string EndpointRegion { get; set; }
        public string AssignedEndpointKey { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public int ClassifierAppId { get; set; }

        public virtual ClassifierApplication ClassifierApp { get; set; }
    }
}
