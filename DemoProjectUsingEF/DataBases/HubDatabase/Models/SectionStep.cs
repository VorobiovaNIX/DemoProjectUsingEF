using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class SectionStep
    {
        public SectionStep()
        {
            DecisionChoices = new HashSet<DecisionChoice>();
            ObjectBasedStepStepTos = new HashSet<ObjectBasedStep>();
            StepActionStepTos = new HashSet<StepAction>();
            StepEmailStepTos = new HashSet<StepEmail>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public int SectionId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }

        public virtual ProcessDefinitionSection Section { get; set; }
        public virtual ObjectBasedStep ObjectBasedStepPddSectionStep { get; set; }
        public virtual StepAction StepActionPddSectionStep { get; set; }
        public virtual StepDecision StepDecision { get; set; }
        public virtual StepEmail StepEmailPddSectionStep { get; set; }
        public virtual ICollection<DecisionChoice> DecisionChoices { get; set; }
        public virtual ICollection<ObjectBasedStep> ObjectBasedStepStepTos { get; set; }
        public virtual ICollection<StepAction> StepActionStepTos { get; set; }
        public virtual ICollection<StepEmail> StepEmailStepTos { get; set; }
    }
}
