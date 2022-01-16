using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class Role
    {
        public Role()
        {
            GroupRoleMappings = new HashSet<GroupRoleMapping>();
            RoleClaims = new HashSet<RoleClaim>();
            SyncingUserRoles = new HashSet<SyncingUserRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string UniqueId { get; set; }
        public int Type { get; set; }
        public bool Predefined { get; set; }

        public virtual ICollection<GroupRoleMapping> GroupRoleMappings { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        public virtual ICollection<SyncingUserRole> SyncingUserRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
