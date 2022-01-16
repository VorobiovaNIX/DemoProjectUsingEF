using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Environment
    {
        public Environment()
        {
            AppAccesses = new HashSet<AppAccess>();
            BusinessProcessForms = new HashSet<BusinessProcessForm>();
            ConnectVirtualWorkers = new HashSet<ConnectVirtualWorker>();
            ConnectWorkQueues = new HashSet<ConnectWorkQueue>();
            ObjectBasedSteps = new HashSet<ObjectBasedStep>();
            Wireframes = new HashSet<Wireframe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual EnvironmentConnection EnvironmentConnection { get; set; }
        public virtual ICollection<AppAccess> AppAccesses { get; set; }
        public virtual ICollection<BusinessProcessForm> BusinessProcessForms { get; set; }
        public virtual ICollection<ConnectVirtualWorker> ConnectVirtualWorkers { get; set; }
        public virtual ICollection<ConnectWorkQueue> ConnectWorkQueues { get; set; }
        public virtual ICollection<ObjectBasedStep> ObjectBasedSteps { get; set; }
        public virtual ICollection<Wireframe> Wireframes { get; set; }
    }
}
