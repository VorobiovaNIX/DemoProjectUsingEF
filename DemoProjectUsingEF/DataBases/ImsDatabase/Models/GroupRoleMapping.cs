using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class GroupRoleMapping
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Sid { get; set; }
        public string DistinguishedName { get; set; }
        public int GroupType { get; set; }

        public virtual Role Role { get; set; }
    }
}
