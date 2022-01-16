using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Screen
    {
        public Screen()
        {
            Elements = new HashSet<Element>();
            StepActions = new HashSet<StepAction>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<Element> Elements { get; set; }
        public virtual ICollection<StepAction> StepActions { get; set; }
    }
}
