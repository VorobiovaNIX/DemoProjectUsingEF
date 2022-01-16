using System;
using DemoProjectUsingEF.DataBases.ImsDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase
{
    public partial class ImsContext : DbContext
    {
        public ImsContext()
        {
        }

        public ImsContext(DbContextOptions<ImsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveDirectoryDomain> ActiveDirectoryDomains { get; set; }
        public virtual DbSet<ApiResource> ApiResources { get; set; }
        public virtual DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }
        public virtual DbSet<ApiResourceInfo> ApiResourceInfos { get; set; }
        public virtual DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }
        public virtual DbSet<ApiScope> ApiScopes { get; set; }
        public virtual DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }
        public virtual DbSet<ApiSecret> ApiSecrets { get; set; }
        public virtual DbSet<AuthenticationSetting> AuthenticationSettings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientClaim> ClientClaims { get; set; }
        public virtual DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public virtual DbSet<ClientGrantType> ClientGrantTypes { get; set; }
        public virtual DbSet<ClientIdPrestriction> ClientIdPrestrictions { get; set; }
        public virtual DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public virtual DbSet<ClientProperty> ClientProperties { get; set; }
        public virtual DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public virtual DbSet<ClientScope> ClientScopes { get; set; }
        public virtual DbSet<ClientSecret> ClientSecrets { get; set; }
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; }
        public virtual DbSet<GroupRoleMapping> GroupRoleMappings { get; set; }
        public virtual DbSet<IdentityClaim> IdentityClaims { get; set; }
        public virtual DbSet<IdentityResource> IdentityResources { get; set; }
        public virtual DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }
        public virtual DbSet<LdapSetting> LdapSettings { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistories { get; set; }
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<SyncingUser> SyncingUsers { get; set; }
        public virtual DbSet<SyncingUserRole> SyncingUserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Ims;User ID=sa;Password=Pass1234Qq;Connection Timeout=90;TrustServerCertificate=True;Trusted_Connection=True;Integrated security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ActiveDirectoryDomain>(entity =>
            {
                entity.ToTable("ActiveDirectoryDomain");

                entity.Property(e => e.DistinguishedName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ApiResourceClaim>(entity =>
            {
                entity.ToTable("ApiResourceClaim");

                entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceClaim_ApiResourceId");

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceClaims)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceInfo>(entity =>
            {
                entity.ToTable("ApiResourceInfo");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(2083);
            });

            modelBuilder.Entity<ApiResourceProperty>(entity =>
            {
                entity.ToTable("ApiResourceProperty");

                entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceProperty_ApiResourceId");

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceProperties)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiScope>(entity =>
            {
                entity.ToTable("ApiScope");

                entity.HasIndex(e => e.ApiResourceId, "IX_ApiScope_ApiResourceId");

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiScopes)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiScopeClaim>(entity =>
            {
                entity.ToTable("ApiScopeClaim");

                entity.HasIndex(e => e.ApiScopeId, "IX_ApiScopeClaim_ApiScopeId");

                entity.HasOne(d => d.ApiScope)
                    .WithMany(p => p.ApiScopeClaims)
                    .HasForeignKey(d => d.ApiScopeId);
            });

            modelBuilder.Entity<ApiSecret>(entity =>
            {
                entity.ToTable("ApiSecret");

                entity.HasIndex(e => e.ApiResourceId, "IX_ApiSecret_ApiResourceId");

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiSecrets)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<AuthenticationSetting>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<ClientClaim>(entity =>
            {
                entity.ToTable("ClientClaim");

                entity.HasIndex(e => e.ClientId, "IX_ClientClaim_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientClaims)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientCorsOrigin>(entity =>
            {
                entity.ToTable("ClientCorsOrigin");

                entity.HasIndex(e => e.ClientId, "IX_ClientCorsOrigin_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCorsOrigins)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientGrantType>(entity =>
            {
                entity.ToTable("ClientGrantType");

                entity.HasIndex(e => e.ClientId, "IX_ClientGrantType_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientGrantTypes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientIdPrestriction>(entity =>
            {
                entity.ToTable("ClientIdPRestriction");

                entity.HasIndex(e => e.ClientId, "IX_ClientIdPRestriction_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientIdPrestrictions)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>(entity =>
            {
                entity.ToTable("ClientPostLogoutRedirectUri");

                entity.HasIndex(e => e.ClientId, "IX_ClientPostLogoutRedirectUri_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPostLogoutRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientProperty>(entity =>
            {
                entity.ToTable("ClientProperty");

                entity.HasIndex(e => e.ClientId, "IX_ClientProperty_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProperties)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientRedirectUri>(entity =>
            {
                entity.ToTable("ClientRedirectUri");

                entity.HasIndex(e => e.ClientId, "IX_ClientRedirectUri_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientScope>(entity =>
            {
                entity.ToTable("ClientScope");

                entity.HasIndex(e => e.ClientId, "IX_ClientScope_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientScopes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientSecret>(entity =>
            {
                entity.ToTable("ClientSecret");

                entity.HasIndex(e => e.ClientId, "IX_ClientSecret_ClientId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSecrets)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode")
                    .IsUnique();

                entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<GroupRoleMapping>(entity =>
            {
                entity.ToTable("GroupRoleMapping");

                entity.HasIndex(e => e.RoleId, "IX_GroupRoleMapping_RoleId");

                entity.Property(e => e.DistinguishedName).IsRequired();

                entity.Property(e => e.GroupType).HasDefaultValueSql("((-2147483644))");

                entity.Property(e => e.Sid).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GroupRoleMappings)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<IdentityClaim>(entity =>
            {
                entity.ToTable("IdentityClaim");

                entity.HasIndex(e => e.IdentityResourceId, "IX_IdentityClaim_IdentityResourceId");

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityClaims)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResourceProperty>(entity =>
            {
                entity.ToTable("IdentityResourceProperty");

                entity.HasIndex(e => e.IdentityResourceId, "IX_IdentityResourceProperty_IdentityResourceId");

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityResourceProperties)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<LdapSetting>(entity =>
            {
                entity.HasIndex(e => e.DomainName, "IX_AuthenticationSettings_DomainName");

                entity.HasIndex(e => e.SyncByUserId, "IX_AuthenticationSettings_SyncByUserId");

                entity.Property(e => e.BaseDn).HasColumnName("BaseDN");

                entity.Property(e => e.IsSecure)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.SyncByUser)
                    .WithMany(p => p.LdapSettings)
                    .HasForeignKey(d => d.SyncByUserId);
            });

            modelBuilder.Entity<PasswordHistory>(entity =>
            {
                entity.ToTable("PasswordHistory");

                entity.HasIndex(e => e.UserId, "IX_PasswordHistory_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PasswordHistories)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UniqueId).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_RoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<SyncingUser>(entity =>
            {
                entity.HasIndex(e => e.LdapSettingId, "IX_SyncingUsers_AuthenticationSettingId");

                entity.HasIndex(e => e.Username, "IX_SyncingUsers_Username");

                entity.Property(e => e.Email).HasMaxLength(512);

                entity.Property(e => e.FirstName).HasMaxLength(512);

                entity.Property(e => e.LastName).HasMaxLength(512);

                entity.Property(e => e.Username).HasMaxLength(512);

                entity.HasOne(d => d.LdapSetting)
                    .WithMany(p => p.SyncingUsers)
                    .HasForeignKey(d => d.LdapSettingId);
            });

            modelBuilder.Entity<SyncingUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_SyncingUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SyncingUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SyncingUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.LdapSettingId, "IX_Users_AuthenticationSettingId");

                entity.HasIndex(e => e.Sid, "IX_Users_Sid")
                    .IsUnique()
                    .HasFilter("([Sid] IS NOT NULL)");

                entity.Property(e => e.AuthenticationTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.FromLdap).HasColumnName("FromLDAP");

                entity.Property(e => e.IsDarkMode)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsRequestResetPassword)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsSeedAdmin)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PublicId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.LdapSetting)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LdapSettingId);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_UserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
