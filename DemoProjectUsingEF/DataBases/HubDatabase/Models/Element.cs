using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Element
    {
        public Element()
        {
            StepActions = new HashSet<StepAction>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int ScreenId { get; set; }

        public virtual Screen Screen { get; set; }
        public virtual ICollection<StepAction> StepActions { get; set; }
    }
}
