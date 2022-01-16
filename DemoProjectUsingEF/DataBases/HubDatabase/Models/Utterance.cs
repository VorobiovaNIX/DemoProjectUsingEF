using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Utterance
    {
        public long Id { get; set; }
        public long LuisId { get; set; }
        public string OriginalText { get; set; }
        public string NormalizedText { get; set; }
        public int IntentId { get; set; }

        public virtual Intent Intent { get; set; }
    }
}
