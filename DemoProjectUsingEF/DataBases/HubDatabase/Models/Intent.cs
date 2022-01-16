using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Intent
    {
        public Intent()
        {
            Utterances = new HashSet<Utterance>();
        }

        public int Id { get; set; }
        public Guid LuisId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string ReadableType { get; set; }
        public bool InheritedFromPrebuilt { get; set; }
        public string InheritedDomainName { get; set; }
        public string InheritedModelName { get; set; }
        public int ClassifierVersionId { get; set; }

        public virtual ClassifierVersion ClassifierVersion { get; set; }
        public virtual ICollection<Utterance> Utterances { get; set; }
    }
}
