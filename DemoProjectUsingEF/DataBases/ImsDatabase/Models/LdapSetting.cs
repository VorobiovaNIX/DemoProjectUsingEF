using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class LdapSetting
    {
        public LdapSetting()
        {
            SyncingUsers = new HashSet<SyncingUser>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public bool Live { get; set; }
        public string ConnectionName { get; set; }
        public string LdapServer { get; set; }
        public string BaseDn { get; set; }
        public string DomainName { get; set; }
        public DateTime? LastSyncDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UsernameAttribute { get; set; }
        public string FirstNameAttribute { get; set; }
        public string LastNameAttribute { get; set; }
        public string EmailAttribute { get; set; }
        public int PortNumber { get; set; }
        public int TimeOut { get; set; }
        public int? SyncByUserId { get; set; }
        public bool? IsSecure { get; set; }

        public virtual User SyncByUser { get; set; }
        public virtual ICollection<SyncingUser> SyncingUsers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
