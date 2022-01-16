using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ObjectStepInputParam
    {
        public int Id { get; set; }
        public Guid StageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string UnderlyingType { get; set; }
        public int ObjectBasedStepId { get; set; }

        public virtual ObjectBasedStep ObjectBasedStep { get; set; }
    }
}
