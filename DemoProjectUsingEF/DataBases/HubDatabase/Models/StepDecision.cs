using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class StepDecision
    {
        public StepDecision()
        {
            DecisionChoices = new HashSet<DecisionChoice>();
        }

        public int PddSectionStepId { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }

        public virtual SectionStep PddSectionStep { get; set; }
        public virtual ICollection<DecisionChoice> DecisionChoices { get; set; }
    }
}
