using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Role
    {
        public Role()
        {
            GroupRoleMappings = new HashSet<GroupRoleMapping>();
            RoleBusinessProcessForms = new HashSet<RoleBusinessProcessForm>();
            RolePlugins = new HashSet<RolePlugin>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UniqueId { get; set; }
        public int Type { get; set; }
        public bool Predefined { get; set; }

        public virtual ICollection<GroupRoleMapping> GroupRoleMappings { get; set; }
        public virtual ICollection<RoleBusinessProcessForm> RoleBusinessProcessForms { get; set; }
        public virtual ICollection<RolePlugin> RolePlugins { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
