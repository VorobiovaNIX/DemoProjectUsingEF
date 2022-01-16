using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class SyncingUser
    {
        public SyncingUser()
        {
            SyncingUserRoles = new HashSet<SyncingUserRole>();
        }

        public int Id { get; set; }
        public byte Status { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? ExistingUserId { get; set; }
        public int? ThemeId { get; set; }
        public int LdapSettingId { get; set; }

        public virtual LdapSetting LdapSetting { get; set; }
        public virtual ICollection<SyncingUserRole> SyncingUserRoles { get; set; }
    }
}
