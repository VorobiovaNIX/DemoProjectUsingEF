using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class StepEmail
    {
        public int PddSectionStepId { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public byte RouteType { get; set; }
        public int? StepToId { get; set; }

        public virtual SectionStep PddSectionStep { get; set; }
        public virtual SectionStep StepTo { get; set; }
    }
}
