using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ObjectBasedStep
    {
        public ObjectBasedStep()
        {
            ObjectStepInputParams = new HashSet<ObjectStepInputParam>();
        }

        public int PddSectionStepId { get; set; }
        public string ProcessName { get; set; }
        public string SubsheetName { get; set; }
        public Guid ProcessId { get; set; }
        public Guid SubsheetId { get; set; }
        public byte RouteType { get; set; }
        public int? StepToId { get; set; }
        public int? EnvironmentId { get; set; }

        public virtual Environment Environment { get; set; }
        public virtual SectionStep PddSectionStep { get; set; }
        public virtual SectionStep StepTo { get; set; }
        public virtual ICollection<ObjectStepInputParam> ObjectStepInputParams { get; set; }
    }
}
