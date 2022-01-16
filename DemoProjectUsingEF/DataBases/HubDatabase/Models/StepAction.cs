using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class StepAction
    {
        public int PddSectionStepId { get; set; }
        public int ApplicationId { get; set; }
        public int? ScreenId { get; set; }
        public int? ElementId { get; set; }
        public int ActionType { get; set; }
        public byte RouteType { get; set; }
        public int? StepToId { get; set; }
        public string CustomActionName { get; set; }

        public virtual Application Application { get; set; }
        public virtual Element Element { get; set; }
        public virtual SectionStep PddSectionStep { get; set; }
        public virtual Screen Screen { get; set; }
        public virtual SectionStep StepTo { get; set; }
    }
}
