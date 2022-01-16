using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class DecisionChoice
    {
        public int Id { get; set; }
        public int DecisionId { get; set; }
        public int? StepToId { get; set; }
        public int? BusinessExceptionId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public byte RouteType { get; set; }

        public virtual ProcessDefinition BusinessException { get; set; }
        public virtual StepDecision Decision { get; set; }
        public virtual SectionStep StepTo { get; set; }
    }
}
