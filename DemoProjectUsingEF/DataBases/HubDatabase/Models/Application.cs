using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Application
    {
        public Application()
        {
            AppAccesses = new HashSet<AppAccess>();
            Screens = new HashSet<Screen>();
            StepActions = new HashSet<StepAction>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Availability { get; set; }
        public TimeSpan? Timeouts { get; set; }
        public int? OwnerId { get; set; }
        public int? ConnectivityMethodId { get; set; }

        public virtual ConnectivityMethod ConnectivityMethod { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<AppAccess> AppAccesses { get; set; }
        public virtual ICollection<Screen> Screens { get; set; }
        public virtual ICollection<StepAction> StepActions { get; set; }
    }
}
