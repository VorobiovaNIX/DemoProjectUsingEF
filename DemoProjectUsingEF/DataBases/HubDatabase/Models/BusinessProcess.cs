using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class BusinessProcess
    {
        public BusinessProcess()
        {
            BusinessProcessUsers = new HashSet<BusinessProcessUser>();
            VirtualWorkerBusinessProcesses = new HashSet<VirtualWorkerBusinessProcess>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomId { get; set; }
        public int StageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StageProgression { get; set; }
        public int? MaxWorkersCount { get; set; }
        public int? CreatedById { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual BusinessProcessForm BusinessProcessForm { get; set; }
        public virtual ProcessDefinition ProcessDefinition { get; set; }
        public virtual ICollection<BusinessProcessUser> BusinessProcessUsers { get; set; }
        public virtual ICollection<VirtualWorkerBusinessProcess> VirtualWorkerBusinessProcesses { get; set; }
    }
}
