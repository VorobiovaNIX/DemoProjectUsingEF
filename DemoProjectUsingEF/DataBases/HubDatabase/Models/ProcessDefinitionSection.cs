using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ProcessDefinitionSection
    {
        public ProcessDefinitionSection()
        {
            InverseCreatedFromSection = new HashSet<ProcessDefinitionSection>();
            SectionSteps = new HashSet<SectionStep>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public int ProcessDefinitionVersionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatedFromSectionId { get; set; }

        public virtual ProcessDefinitionSection CreatedFromSection { get; set; }
        public virtual ProcessDefinitionVersion ProcessDefinitionVersion { get; set; }
        public virtual ICollection<ProcessDefinitionSection> InverseCreatedFromSection { get; set; }
        public virtual ICollection<SectionStep> SectionSteps { get; set; }
    }
}
