using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class User
    {
        public User()
        {
            Applications = new HashSet<Application>();
            BusinessProcessFormApprovers = new HashSet<BusinessProcessForm>();
            BusinessProcessFormLockedByUsers = new HashSet<BusinessProcessForm>();
            BusinessProcessUsers = new HashSet<BusinessProcessUser>();
            BusinessProcesses = new HashSet<BusinessProcess>();
            ClassifierApplications = new HashSet<ClassifierApplication>();
            ConnectDashboards = new HashSet<ConnectDashboard>();
            ConnectivityMethods = new HashSet<ConnectivityMethod>();
            FormVersions = new HashSet<FormVersion>();
            LayoutSettings = new HashSet<LayoutSetting>();
            ProcessDefinitionVersionLockedByUsers = new HashSet<ProcessDefinitionVersion>();
            ProcessDefinitionVersionUpdatedByUsers = new HashSet<ProcessDefinitionVersion>();
            UserRoles = new HashSet<UserRole>();
            WireframeCreatedByUsers = new HashSet<Wireframe>();
            WireframeLockedByUsers = new HashSet<Wireframe>();
            WireframeModifiedByUsers = new HashSet<Wireframe>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Department { get; set; }
        public string AvatarBase64 { get; set; }
        public string TimeZoneId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsWhatsNewRead { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool IsSeedAdmin { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<BusinessProcessForm> BusinessProcessFormApprovers { get; set; }
        public virtual ICollection<BusinessProcessForm> BusinessProcessFormLockedByUsers { get; set; }
        public virtual ICollection<BusinessProcessUser> BusinessProcessUsers { get; set; }
        public virtual ICollection<BusinessProcess> BusinessProcesses { get; set; }
        public virtual ICollection<ClassifierApplication> ClassifierApplications { get; set; }
        public virtual ICollection<ConnectDashboard> ConnectDashboards { get; set; }
        public virtual ICollection<ConnectivityMethod> ConnectivityMethods { get; set; }
        public virtual ICollection<FormVersion> FormVersions { get; set; }
        public virtual ICollection<LayoutSetting> LayoutSettings { get; set; }
        public virtual ICollection<ProcessDefinitionVersion> ProcessDefinitionVersionLockedByUsers { get; set; }
        public virtual ICollection<ProcessDefinitionVersion> ProcessDefinitionVersionUpdatedByUsers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Wireframe> WireframeCreatedByUsers { get; set; }
        public virtual ICollection<Wireframe> WireframeLockedByUsers { get; set; }
        public virtual ICollection<Wireframe> WireframeModifiedByUsers { get; set; }
    }
}
