using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ClassifierApplication
    {
        public ClassifierApplication()
        {
            ClassifierEndpoints = new HashSet<ClassifierEndpoint>();
            ClassifierVersions = new HashSet<ClassifierVersion>();
        }

        public int Id { get; set; }
        public Guid LuisId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UsageScenario { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? LastTrainedDateTime { get; set; }
        public DateTime? LastPublishedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int CreatorId { get; set; }
        public int CultureId { get; set; }

        public virtual User Creator { get; set; }
        public virtual ClassifierCulture Culture { get; set; }
        public virtual ICollection<ClassifierEndpoint> ClassifierEndpoints { get; set; }
        public virtual ICollection<ClassifierVersion> ClassifierVersions { get; set; }
    }
}
