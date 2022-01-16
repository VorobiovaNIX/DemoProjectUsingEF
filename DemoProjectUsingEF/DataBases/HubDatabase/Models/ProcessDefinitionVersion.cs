using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ProcessDefinitionVersion
    {
        public ProcessDefinitionVersion()
        {
            ProcessDefinitionSections = new HashSet<ProcessDefinitionSection>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int DefinitionId { get; set; }
        public int? LockedByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
        public bool IsLatest { get; set; }
        public bool IsDraft { get; set; }
        public string Version { get; set; }
        public string UpdatedNote { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ProcessDefinition Definition { get; set; }
        public virtual User LockedByUser { get; set; }
        public virtual User UpdatedByUser { get; set; }
        public virtual ICollection<ProcessDefinitionSection> ProcessDefinitionSections { get; set; }
    }
}
