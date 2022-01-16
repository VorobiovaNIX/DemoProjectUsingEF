using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class BusinessProcessForm
    {
        public BusinessProcessForm()
        {
            FormVersions = new HashSet<FormVersion>();
            RoleBusinessProcessForms = new HashSet<RoleBusinessProcessForm>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BusinessProcessCategoryId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int? ConnectWorkQueueId { get; set; }
        public int? BusinessProcessId { get; set; }
        public string CategoryImage { get; set; }
        public int? LockedByUserId { get; set; }
        public int? ApproverId { get; set; }
        public int ApproveType { get; set; }
        public int? Priority { get; set; }
        public long? SlaTicks { get; set; }
        public int? EnvironmentId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User Approver { get; set; }
        public virtual BusinessProcess BusinessProcess { get; set; }
        public virtual BusinessProcessCategory BusinessProcessCategory { get; set; }
        public virtual ConnectWorkQueue ConnectWorkQueue { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual User LockedByUser { get; set; }
        public virtual ICollection<FormVersion> FormVersions { get; set; }
        public virtual ICollection<RoleBusinessProcessForm> RoleBusinessProcessForms { get; set; }
    }
}
