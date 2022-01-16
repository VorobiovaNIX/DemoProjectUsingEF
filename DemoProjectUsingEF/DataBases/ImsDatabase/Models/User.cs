using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class User
    {
        public User()
        {
            LdapSettings = new HashSet<LdapSetting>();
            PasswordHistories = new HashSet<PasswordHistory>();
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public bool FromLdap { get; set; }
        public bool IsDeleted { get; set; }
        public int? LdapSettingId { get; set; }
        public int? ThemeId { get; set; }
        public int RegistrationStatus { get; set; }
        public bool? IsRequestResetPassword { get; set; }
        public bool? IsSeedAdmin { get; set; }
        public int? Language { get; set; }
        public bool? IsDarkMode { get; set; }
        public Guid PublicId { get; set; }
        public int AuthenticationTypeId { get; set; }
        public string DistinguishedName { get; set; }
        public string Sid { get; set; }

        public virtual LdapSetting LdapSetting { get; set; }
        public virtual ICollection<LdapSetting> LdapSettings { get; set; }
        public virtual ICollection<PasswordHistory> PasswordHistories { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}
