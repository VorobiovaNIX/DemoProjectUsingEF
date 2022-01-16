using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ClassifierVersion
    {
        public ClassifierVersion()
        {
            Intents = new HashSet<Intent>();
        }

        public int Id { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? LastTrainedDateTime { get; set; }
        public DateTime? LastPublishedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int ClassifierId { get; set; }

        public virtual ClassifierApplication Classifier { get; set; }
        public virtual ICollection<Intent> Intents { get; set; }
    }
}
