using System;
using DemoProjectUsingEF.DataBases.HubDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase
{
    public partial class HubContext : DbContext
    {
        public HubContext()
        {
        }

        public HubContext(DbContextOptions<HubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppAccess> AppAccesses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<BusinessProcess> BusinessProcesses { get; set; }
        public virtual DbSet<BusinessProcessCategory> BusinessProcessCategories { get; set; }
        public virtual DbSet<BusinessProcessForm> BusinessProcessForms { get; set; }
        public virtual DbSet<BusinessProcessUser> BusinessProcessUsers { get; set; }
        public virtual DbSet<ClassifierApplication> ClassifierApplications { get; set; }
        public virtual DbSet<ClassifierCulture> ClassifierCultures { get; set; }
        public virtual DbSet<ClassifierEndpoint> ClassifierEndpoints { get; set; }
        public virtual DbSet<ClassifierVersion> ClassifierVersions { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<ColumnSetting> ColumnSettings { get; set; }
        public virtual DbSet<ConnectDashboard> ConnectDashboards { get; set; }
        public virtual DbSet<ConnectVirtualWorker> ConnectVirtualWorkers { get; set; }
        public virtual DbSet<ConnectWidgetInfo> ConnectWidgetInfos { get; set; }
        public virtual DbSet<ConnectWidgetInstance> ConnectWidgetInstances { get; set; }
        public virtual DbSet<ConnectWorkQueue> ConnectWorkQueues { get; set; }
        public virtual DbSet<ConnectWorkerCategory> ConnectWorkerCategories { get; set; }
        public virtual DbSet<ConnectivityMethod> ConnectivityMethods { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DecisionChoice> DecisionChoices { get; set; }
        public virtual DbSet<DeployedService> DeployedServices { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Models.Environment> Environments { get; set; }
        public virtual DbSet<EnvironmentConnection> EnvironmentConnections { get; set; }
        public virtual DbSet<FormField> FormFields { get; set; }
        public virtual DbSet<FormPage> FormPages { get; set; }
        public virtual DbSet<FormVersion> FormVersions { get; set; }
        public virtual DbSet<GroupRoleMapping> GroupRoleMappings { get; set; }
        public virtual DbSet<Intent> Intents { get; set; }
        public virtual DbSet<LayoutSetting> LayoutSettings { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<ObjectBasedStep> ObjectBasedSteps { get; set; }
        public virtual DbSet<ObjectStepInputParam> ObjectStepInputParams { get; set; }
        public virtual DbSet<Plugin> Plugins { get; set; }
        public virtual DbSet<ProcessDefinition> ProcessDefinitions { get; set; }
        public virtual DbSet<ProcessDefinitionSection> ProcessDefinitionSections { get; set; }
        public virtual DbSet<ProcessDefinitionVersion> ProcessDefinitionVersions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleBusinessProcessForm> RoleBusinessProcessForms { get; set; }
        public virtual DbSet<RolePlugin> RolePlugins { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<SectionStep> SectionSteps { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<StepAction> StepActions { get; set; }
        public virtual DbSet<StepDecision> StepDecisions { get; set; }
        public virtual DbSet<StepEmail> StepEmails { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TableLayout> TableLayouts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Utterance> Utterances { get; set; }
        public virtual DbSet<VirtualWorkerAppAccess> VirtualWorkerAppAccesses { get; set; }
        public virtual DbSet<VirtualWorkerBusinessProcess> VirtualWorkerBusinessProcesses { get; set; }
        public virtual DbSet<Wireframe> Wireframes { get; set; }
        public virtual DbSet<WireframeAction> WireframeActions { get; set; }
        public virtual DbSet<WireframeObject> WireframeObjects { get; set; }
        public virtual DbSet<WorkQueueCategory> WorkQueueCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Hub;User ID=sa;Password=Pass1234Qq;Connection Timeout=90;TrustServerCertificate=True;Trusted_Connection=True;Integrated security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppAccess>(entity =>
            {
                entity.HasIndex(e => e.ApplicationId, "IX_AppAccesses_ApplicationId");

                entity.HasIndex(e => e.EnvironmentId, "IX_AppAccesses_EnvironmentId");

                entity.Property(e => e.Notes).HasMaxLength(512);

                entity.Property(e => e.UserName).HasMaxLength(128);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AppAccesses)
                    .HasForeignKey(d => d.ApplicationId);

                entity.HasOne(d => d.Environment)
                    .WithMany(p => p.AppAccesses)
                    .HasForeignKey(d => d.EnvironmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasIndex(e => e.ConnectivityMethodId, "IX_Applications_ConnectivityMethodId");

                entity.HasIndex(e => e.CustomId, "IX_Applications_CustomId")
                    .IsUnique()
                    .HasFilter("([CustomId] IS NOT NULL)");

                entity.HasIndex(e => e.OwnerId, "IX_Applications_OwnerId");

                entity.Property(e => e.Availability).HasMaxLength(64);

                entity.Property(e => e.CustomId).HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Version).HasMaxLength(32);

                entity.HasOne(d => d.ConnectivityMethod)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.ConnectivityMethodId);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.OwnerId);
            });

            modelBuilder.Entity<BusinessProcess>(entity =>
            {
                entity.HasIndex(e => e.CreatedById, "IX_BusinessProcesses_CreatedById");

                entity.HasIndex(e => e.StageId, "IX_BusinessProcesses_StageId");

                entity.Property(e => e.CustomId).HasMaxLength(16);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.BusinessProcesses)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.BusinessProcesses)
                    .HasForeignKey(d => d.StageId);
            });

            modelBuilder.Entity<BusinessProcessCategory>(entity =>
            {
                entity.ToTable("BusinessProcessCategory");

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<BusinessProcessForm>(entity =>
            {
                entity.ToTable("BusinessProcessForm");

                entity.HasIndex(e => e.ApproverId, "IX_BusinessProcessForm_ApproverId");

                entity.HasIndex(e => e.BusinessProcessCategoryId, "IX_BusinessProcessForm_BusinessProcessCategoryId");

                entity.HasIndex(e => e.BusinessProcessId, "IX_BusinessProcessForm_BusinessProcessId")
                    .IsUnique()
                    .HasFilter("([BusinessProcessId] IS NOT NULL)");

                entity.HasIndex(e => e.ConnectWorkQueueId, "IX_BusinessProcessForm_ConnectWorkQueueId");

                entity.HasIndex(e => e.EnvironmentId, "IX_BusinessProcessForm_EnvironmentId");

                entity.HasIndex(e => e.LockedByUserId, "IX_BusinessProcessForm_LockedByUserId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.BusinessProcessFormApprovers)
                    .HasForeignKey(d => d.ApproverId);

                entity.HasOne(d => d.BusinessProcessCategory)
                    .WithMany(p => p.BusinessProcessForms)
                    .HasForeignKey(d => d.BusinessProcessCategoryId);

                entity.HasOne(d => d.BusinessProcess)
                    .WithOne(p => p.BusinessProcessForm)
                    .HasForeignKey<BusinessProcessForm>(d => d.BusinessProcessId);

                entity.HasOne(d => d.ConnectWorkQueue)
                    .WithMany(p => p.BusinessProcessForms)
                    .HasForeignKey(d => d.ConnectWorkQueueId);

                entity.HasOne(d => d.Environment)
                    .WithMany(p => p.BusinessProcessForms)
                    .HasForeignKey(d => d.EnvironmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.LockedByUser)
                    .WithMany(p => p.BusinessProcessFormLockedByUsers)
                    .HasForeignKey(d => d.LockedByUserId);
            });

            modelBuilder.Entity<BusinessProcessUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Bpid });

                entity.ToTable("BusinessProcessUser");

                entity.HasIndex(e => e.Bpid, "IX_BusinessProcessUser_BPId");

                entity.Property(e => e.Bpid).HasColumnName("BPId");

                entity.Property(e => e.MemberRole).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.Bp)
                    .WithMany(p => p.BusinessProcessUsers)
                    .HasForeignKey(d => d.Bpid);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BusinessProcessUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ClassifierApplication>(entity =>
            {
                entity.ToTable("ClassifierApplication");

                entity.HasIndex(e => e.CreatorId, "IX_ClassifierApplication_CreatorId");

                entity.HasIndex(e => e.CultureId, "IX_ClassifierApplication_CultureId");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Domain).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.UsageScenario).HasMaxLength(128);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ClassifierApplications)
                    .HasForeignKey(d => d.CreatorId);

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.ClassifierApplications)
                    .HasForeignKey(d => d.CultureId);
            });

            modelBuilder.Entity<ClassifierCulture>(entity =>
            {
                entity.ToTable("ClassifierCulture");

                entity.Property(e => e.Code).HasMaxLength(16);

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<ClassifierEndpoint>(entity =>
            {
                entity.ToTable("ClassifierEndpoint");

                entity.HasIndex(e => e.ClassifierAppId, "IX_ClassifierEndpoint_ClassifierAppId");

                entity.Property(e => e.AssignedEndpointKey).HasMaxLength(512);

                entity.Property(e => e.EndpointRegion).HasMaxLength(64);

                entity.Property(e => e.EndpointUrl).HasMaxLength(2048);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.VersionId).HasMaxLength(128);

                entity.HasOne(d => d.ClassifierApp)
                    .WithMany(p => p.ClassifierEndpoints)
                    .HasForeignKey(d => d.ClassifierAppId);
            });

            modelBuilder.Entity<ClassifierVersion>(entity =>
            {
                entity.ToTable("ClassifierVersion");

                entity.HasIndex(e => e.ClassifierId, "IX_ClassifierVersion_ClassifierId");

                entity.Property(e => e.Version).HasMaxLength(128);

                entity.HasOne(d => d.Classifier)
                    .WithMany(p => p.ClassifierVersions)
                    .HasForeignKey(d => d.ClassifierId);
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("Column", "layouts");

                entity.HasIndex(e => e.Id, "IX_Column_Id");

                entity.HasIndex(e => e.TableId, "IX_Column_TableId");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ColumnSetting>(entity =>
            {
                entity.ToTable("ColumnSettings", "layouts");

                entity.HasIndex(e => e.ColumnId, "IX_ColumnSettings_ColumnId");

                entity.HasIndex(e => e.LayoutSettingsId, "IX_ColumnSettings_LayoutSettingsId");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.ColumnSettings)
                    .HasForeignKey(d => d.ColumnId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LayoutSettings)
                    .WithMany(p => p.ColumnSettings)
                    .HasForeignKey(d => d.LayoutSettingsId);
            });

            modelBuilder.Entity<ConnectDashboard>(entity =>
            {
                entity.ToTable("ConnectDashboard");

                entity.HasIndex(e => e.UserId, "IX_ConnectDashboard_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConnectDashboards)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ConnectVirtualWorker>(entity =>
            {
                entity.ToTable("ConnectVirtualWorker");

                entity.HasIndex(e => e.CategoryId, "IX_ConnectVirtualWorker_CategoryId");

                entity.HasIndex(e => e.EnvironmentId, "IX_ConnectVirtualWorker_EnvironmentId");

                entity.Property(e => e.Alias).HasMaxLength(256);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ConnectVirtualWorkers)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Environment)
                    .WithMany(p => p.ConnectVirtualWorkers)
                    .HasForeignKey(d => d.EnvironmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ConnectWidgetInfo>(entity =>
            {
                entity.ToTable("ConnectWidgetInfo");
            });

            modelBuilder.Entity<ConnectWidgetInstance>(entity =>
            {
                entity.ToTable("ConnectWidgetInstance");

                entity.HasIndex(e => e.DashboardId, "IX_ConnectWidgetInstance_DashboardId");

                entity.HasIndex(e => e.WidgetInfoId, "IX_ConnectWidgetInstance_WidgetInfoId");

                entity.Property(e => e.Xaxis).HasColumnName("XAxis");

                entity.Property(e => e.Yaxis).HasColumnName("YAxis");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.ConnectWidgetInstances)
                    .HasForeignKey(d => d.DashboardId);

                entity.HasOne(d => d.WidgetInfo)
                    .WithMany(p => p.ConnectWidgetInstances)
                    .HasForeignKey(d => d.WidgetInfoId);
            });

            modelBuilder.Entity<ConnectWorkQueue>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_ConnectWorkQueues_CategoryId");

                entity.HasIndex(e => e.EnvironmentId, "IX_ConnectWorkQueues_EnvironmentId");

                entity.HasIndex(e => e.RemoteId, "IX_ConnectWorkQueues_RemoteId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ConnectWorkQueues)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Environment)
                    .WithMany(p => p.ConnectWorkQueues)
                    .HasForeignKey(d => d.EnvironmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ConnectWorkerCategory>(entity =>
            {
                entity.ToTable("ConnectWorkerCategory");

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<ConnectivityMethod>(entity =>
            {
                entity.HasIndex(e => e.DefinedByUserId, "IX_ConnectivityMethods_DefinedByUserId");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.HasOne(d => d.DefinedByUser)
                    .WithMany(p => p.ConnectivityMethods)
                    .HasForeignKey(d => d.DefinedByUserId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.ClientId).HasMaxLength(512);

                entity.Property(e => e.ClientSecret).HasMaxLength(512);

                entity.Property(e => e.Code).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.SubscriptionId).HasMaxLength(256);

                entity.Property(e => e.SubscriptionName).HasMaxLength(512);
            });

            modelBuilder.Entity<DecisionChoice>(entity =>
            {
                entity.ToTable("DecisionChoice");

                entity.HasIndex(e => e.BusinessExceptionId, "IX_DecisionChoice_BusinessExceptionId");

                entity.HasIndex(e => e.DecisionId, "IX_DecisionChoice_DecisionId");

                entity.HasIndex(e => e.StepToId, "IX_DecisionChoice_StepToId");

                entity.HasOne(d => d.BusinessException)
                    .WithMany(p => p.DecisionChoices)
                    .HasForeignKey(d => d.BusinessExceptionId);

                entity.HasOne(d => d.Decision)
                    .WithMany(p => p.DecisionChoices)
                    .HasForeignKey(d => d.DecisionId);

                entity.HasOne(d => d.StepTo)
                    .WithMany(p => p.DecisionChoices)
                    .HasForeignKey(d => d.StepToId);
            });

            modelBuilder.Entity<DeployedService>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_DeployedServices_CustomerId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DeployedServices)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasIndex(e => e.ScreenId, "IX_Elements_ScreenId");

                entity.Property(e => e.Name).HasMaxLength(75);

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.Elements)
                    .HasForeignKey(d => d.ScreenId);
            });

            modelBuilder.Entity<Models.Environment>(entity =>
            {
                entity.ToTable("Environment");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<EnvironmentConnection>(entity =>
            {
                entity.ToTable("EnvironmentConnection");

                entity.HasIndex(e => e.EnvironmentId, "IX_EnvironmentConnection_EnvironmentId")
                    .IsUnique();

                entity.HasOne(d => d.Environment)
                    .WithOne(p => p.EnvironmentConnection)
                    .HasForeignKey<EnvironmentConnection>(d => d.EnvironmentId);
            });

            modelBuilder.Entity<FormField>(entity =>
            {
                entity.ToTable("FormField");

                entity.HasIndex(e => e.FormPageId, "IX_FormField_FormPageId");

                entity.Property(e => e.AutomationId).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.HasOne(d => d.FormPage)
                    .WithMany(p => p.FormFields)
                    .HasForeignKey(d => d.FormPageId);
            });

            modelBuilder.Entity<FormPage>(entity =>
            {
                entity.ToTable("FormPage");

                entity.HasIndex(e => e.FormVersionId, "IX_FormPage_FormVersionId");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.FormVersion)
                    .WithMany(p => p.FormPages)
                    .HasForeignKey(d => d.FormVersionId);
            });

            modelBuilder.Entity<FormVersion>(entity =>
            {
                entity.ToTable("FormVersion");

                entity.HasIndex(e => e.BusinessProcessFormId, "IX_FormVersion_BusinessProcessFormId");

                entity.HasIndex(e => e.UpdatedByUserId, "IX_FormVersion_UpdatedByUserId");

                entity.HasOne(d => d.BusinessProcessForm)
                    .WithMany(p => p.FormVersions)
                    .HasForeignKey(d => d.BusinessProcessFormId);

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.FormVersions)
                    .HasForeignKey(d => d.UpdatedByUserId);
            });

            modelBuilder.Entity<GroupRoleMapping>(entity =>
            {
                entity.ToTable("GroupRoleMapping");

                entity.HasIndex(e => e.ApplicationRoleId, "IX_GroupRoleMapping_ApplicationRoleId");

                entity.Property(e => e.DistinguishedName).IsRequired();

                entity.Property(e => e.Sid).IsRequired();

                entity.HasOne(d => d.ApplicationRole)
                    .WithMany(p => p.GroupRoleMappings)
                    .HasForeignKey(d => d.ApplicationRoleId);
            });

            modelBuilder.Entity<Intent>(entity =>
            {
                entity.ToTable("Intent");

                entity.HasIndex(e => e.ClassifierVersionId, "IX_Intent_ClassifierVersionId");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.InheritedDomainName).HasMaxLength(256);

                entity.Property(e => e.InheritedModelName).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.ReadableType).HasMaxLength(128);

                entity.HasOne(d => d.ClassifierVersion)
                    .WithMany(p => p.Intents)
                    .HasForeignKey(d => d.ClassifierVersionId);
            });

            modelBuilder.Entity<LayoutSetting>(entity =>
            {
                entity.ToTable("LayoutSetting", "layouts");

                entity.HasIndex(e => e.LayoutId, "IX_LayoutSetting_LayoutId");

                entity.HasIndex(e => e.UserId, "IX_LayoutSetting_UserId");

                entity.HasOne(d => d.Layout)
                    .WithMany(p => p.LayoutSettings)
                    .HasForeignKey(d => d.LayoutId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LayoutSettings)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ObjectBasedStep>(entity =>
            {
                entity.HasKey(e => e.PddSectionStepId);

                entity.ToTable("ObjectBasedStep");

                entity.HasIndex(e => e.EnvironmentId, "IX_ObjectBasedStep_EnvironmentId");

                entity.HasIndex(e => e.StepToId, "IX_ObjectBasedStep_StepToId");

                entity.Property(e => e.PddSectionStepId).ValueGeneratedNever();

                entity.HasOne(d => d.Environment)
                    .WithMany(p => p.ObjectBasedSteps)
                    .HasForeignKey(d => d.EnvironmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.PddSectionStep)
                    .WithOne(p => p.ObjectBasedStepPddSectionStep)
                    .HasForeignKey<ObjectBasedStep>(d => d.PddSectionStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StepTo)
                    .WithMany(p => p.ObjectBasedStepStepTos)
                    .HasForeignKey(d => d.StepToId);
            });

            modelBuilder.Entity<ObjectStepInputParam>(entity =>
            {
                entity.ToTable("ObjectStepInputParam");

                entity.HasIndex(e => e.ObjectBasedStepId, "IX_ObjectStepInputParam_ObjectBasedStepId");

                entity.HasOne(d => d.ObjectBasedStep)
                    .WithMany(p => p.ObjectStepInputParams)
                    .HasForeignKey(d => d.ObjectBasedStepId);
            });

            modelBuilder.Entity<ProcessDefinition>(entity =>
            {
                entity.ToTable("ProcessDefinition");

                entity.HasIndex(e => e.BusinessProcessId, "IX_ProcessDefinition_BusinessProcessId")
                    .IsUnique()
                    .HasFilter("([BusinessProcessId] IS NOT NULL)");

                entity.Property(e => e.Description).HasDefaultValueSql("(N'')");

                entity.Property(e => e.ExceptionCode).HasDefaultValueSql("(N'')");

                entity.Property(e => e.ExceptionSectionTemplateName)
                    .HasColumnName("ExceptionSectionTemplate_Name")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name).HasDefaultValueSql("(N'')");

                entity.Property(e => e.SectionTemplateDescription)
                    .HasColumnName("SectionTemplate_Description")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.SectionTemplateName)
                    .HasColumnName("SectionTemplate_Name")
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.BusinessProcess)
                    .WithOne(p => p.ProcessDefinition)
                    .HasForeignKey<ProcessDefinition>(d => d.BusinessProcessId);
            });

            modelBuilder.Entity<ProcessDefinitionSection>(entity =>
            {
                entity.ToTable("ProcessDefinitionSection");

                entity.HasIndex(e => e.CreatedFromSectionId, "IX_ProcessDefinitionSection_CreatedFromSectionId");

                entity.HasIndex(e => e.ProcessDefinitionVersionId, "IX_ProcessDefinitionSection_ProcessDefinitionVersionId");

                entity.HasOne(d => d.CreatedFromSection)
                    .WithMany(p => p.InverseCreatedFromSection)
                    .HasForeignKey(d => d.CreatedFromSectionId);

                entity.HasOne(d => d.ProcessDefinitionVersion)
                    .WithMany(p => p.ProcessDefinitionSections)
                    .HasForeignKey(d => d.ProcessDefinitionVersionId);
            });

            modelBuilder.Entity<ProcessDefinitionVersion>(entity =>
            {
                entity.ToTable("ProcessDefinitionVersion");

                entity.HasIndex(e => e.DefinitionId, "IX_ProcessDefinitionVersion_DefinitionId");

                entity.HasIndex(e => e.LockedByUserId, "IX_ProcessDefinitionVersion_LockedByUserId");

                entity.HasIndex(e => e.UpdatedByUserId, "IX_ProcessDefinitionVersion_UpdatedByUserId");

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.ProcessDefinitionVersions)
                    .HasForeignKey(d => d.DefinitionId);

                entity.HasOne(d => d.LockedByUser)
                    .WithMany(p => p.ProcessDefinitionVersionLockedByUsers)
                    .HasForeignKey(d => d.LockedByUserId);

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ProcessDefinitionVersionUpdatedByUsers)
                    .HasForeignKey(d => d.UpdatedByUserId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleBusinessProcessForm>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.BusinessProcessFormId });

                entity.ToTable("RoleBusinessProcessForm");

                entity.HasIndex(e => e.BusinessProcessFormId, "IX_RoleBusinessProcessForm_BusinessProcessFormId");

                entity.HasOne(d => d.BusinessProcessForm)
                    .WithMany(p => p.RoleBusinessProcessForms)
                    .HasForeignKey(d => d.BusinessProcessFormId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleBusinessProcessForms)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RolePlugin>(entity =>
            {
                entity.HasKey(e => new { e.PluginId, e.RoleId });

                entity.ToTable("RolePlugin");

                entity.HasIndex(e => e.RoleId, "IX_RolePlugin_RoleId");

                entity.HasOne(d => d.Plugin)
                    .WithMany(p => p.RolePlugins)
                    .HasForeignKey(d => d.PluginId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePlugins)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.HasIndex(e => e.ApplicationId, "IX_Screens_ApplicationId");

                entity.Property(e => e.Name).HasMaxLength(75);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Screens)
                    .HasForeignKey(d => d.ApplicationId);
            });

            modelBuilder.Entity<SectionStep>(entity =>
            {
                entity.ToTable("SectionStep");

                entity.HasIndex(e => e.SectionId, "IX_SectionStep_SectionId");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionSteps)
                    .HasForeignKey(d => d.SectionId);
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StepAction>(entity =>
            {
                entity.HasKey(e => e.PddSectionStepId);

                entity.ToTable("StepAction");

                entity.HasIndex(e => e.ApplicationId, "IX_StepAction_ApplicationId");

                entity.HasIndex(e => e.ElementId, "IX_StepAction_ElementId");

                entity.HasIndex(e => e.ScreenId, "IX_StepAction_ScreenId");

                entity.HasIndex(e => e.StepToId, "IX_StepAction_StepToId");

                entity.Property(e => e.PddSectionStepId).ValueGeneratedNever();

                entity.Property(e => e.CustomActionName).HasMaxLength(128);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.StepActions)
                    .HasForeignKey(d => d.ApplicationId);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.StepActions)
                    .HasForeignKey(d => d.ElementId);

                entity.HasOne(d => d.PddSectionStep)
                    .WithOne(p => p.StepActionPddSectionStep)
                    .HasForeignKey<StepAction>(d => d.PddSectionStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Screen)
                    .WithMany(p => p.StepActions)
                    .HasForeignKey(d => d.ScreenId);

                entity.HasOne(d => d.StepTo)
                    .WithMany(p => p.StepActionStepTos)
                    .HasForeignKey(d => d.StepToId);
            });

            modelBuilder.Entity<StepDecision>(entity =>
            {
                entity.HasKey(e => e.PddSectionStepId);

                entity.ToTable("StepDecision");

                entity.Property(e => e.PddSectionStepId).ValueGeneratedNever();

                entity.HasOne(d => d.PddSectionStep)
                    .WithOne(p => p.StepDecision)
                    .HasForeignKey<StepDecision>(d => d.PddSectionStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StepEmail>(entity =>
            {
                entity.HasKey(e => e.PddSectionStepId);

                entity.ToTable("StepEmail");

                entity.HasIndex(e => e.StepToId, "IX_StepEmail_StepToId");

                entity.Property(e => e.PddSectionStepId).ValueGeneratedNever();

                entity.HasOne(d => d.PddSectionStep)
                    .WithOne(p => p.StepEmailPddSectionStep)
                    .HasForeignKey<StepEmail>(d => d.PddSectionStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StepTo)
                    .WithMany(p => p.StepEmailStepTos)
                    .HasForeignKey(d => d.StepToId);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table", "layouts");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TableLayout>(entity =>
            {
                entity.ToTable("TableLayout", "layouts");

                entity.HasIndex(e => e.TableId, "IX_TableLayout_TableId");

                entity.Property(e => e.UniqueId).HasMaxLength(256);

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.TableLayouts)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TimeZoneId).HasMaxLength(512);
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

            modelBuilder.Entity<Utterance>(entity =>
            {
                entity.ToTable("Utterance");

                entity.HasIndex(e => e.IntentId, "IX_Utterance_IntentId");

                entity.HasOne(d => d.Intent)
                    .WithMany(p => p.Utterances)
                    .HasForeignKey(d => d.IntentId);
            });

            modelBuilder.Entity<VirtualWorkerAppAccess>(entity =>
            {
                entity.HasKey(e => new { e.Vwid, e.Aaid });

                entity.ToTable("VirtualWorkerAppAccess");

                entity.HasIndex(e => e.Aaid, "IX_VirtualWorkerAppAccess_AAId");

                entity.Property(e => e.Vwid).HasColumnName("VWId");

                entity.Property(e => e.Aaid).HasColumnName("AAId");

                entity.HasOne(d => d.Aa)
                    .WithMany(p => p.VirtualWorkerAppAccesses)
                    .HasForeignKey(d => d.Aaid);

                entity.HasOne(d => d.Vw)
                    .WithMany(p => p.VirtualWorkerAppAccesses)
                    .HasForeignKey(d => d.Vwid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<VirtualWorkerBusinessProcess>(entity =>
            {
                entity.HasKey(e => new { e.Vwid, e.Bpid });

                entity.ToTable("VirtualWorkerBusinessProcess");

                entity.HasIndex(e => e.Bpid, "IX_VirtualWorkerBusinessProcess_BPId");

                entity.Property(e => e.Vwid).HasColumnName("VWId");

                entity.Property(e => e.Bpid).HasColumnName("BPId");

                entity.HasOne(d => d.Bp)
                    .WithMany(p => p.VirtualWorkerBusinessProcesses)
                    .HasForeignKey(d => d.Bpid);

                entity.HasOne(d => d.Vw)
                    .WithMany(p => p.VirtualWorkerBusinessProcesses)
                    .HasForeignKey(d => d.Vwid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Wireframe>(entity =>
            {
                entity.HasIndex(e => e.CreatedByUserId, "IX_Wireframes_CreatedByUserId");

                entity.HasIndex(e => e.EnvironmentId, "IX_Wireframes_EnvironmentId");

                entity.HasIndex(e => e.LockedByUserId, "IX_Wireframes_LockedByUserId");

                entity.HasIndex(e => e.ModifiedByUserId, "IX_Wireframes_ModifiedByUserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.WireframeCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUserId);

                entity.HasOne(d => d.Environment)
                    .WithMany(p => p.Wireframes)
                    .HasForeignKey(d => d.EnvironmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.LockedByUser)
                    .WithMany(p => p.WireframeLockedByUsers)
                    .HasForeignKey(d => d.LockedByUserId);

                entity.HasOne(d => d.ModifiedByUser)
                    .WithMany(p => p.WireframeModifiedByUsers)
                    .HasForeignKey(d => d.ModifiedByUserId);
            });

            modelBuilder.Entity<WireframeAction>(entity =>
            {
                entity.HasIndex(e => e.WireframeObjectId, "IX_WireframeActions_WireframeObjectId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Type).HasMaxLength(256);

                entity.HasOne(d => d.WireframeObject)
                    .WithMany(p => p.WireframeActions)
                    .HasForeignKey(d => d.WireframeObjectId);
            });

            modelBuilder.Entity<WireframeObject>(entity =>
            {
                entity.HasIndex(e => e.WireframeId, "IX_WireframeObjects_WireframeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Type).HasMaxLength(256);

                entity.HasOne(d => d.Wireframe)
                    .WithMany(p => p.WireframeObjects)
                    .HasForeignKey(d => d.WireframeId);
            });

            modelBuilder.Entity<WorkQueueCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
