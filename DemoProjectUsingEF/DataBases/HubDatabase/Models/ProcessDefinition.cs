using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ProcessDefinition
    {
        public ProcessDefinition()
        {
            DecisionChoices = new HashSet<DecisionChoice>();
            ProcessDefinitionVersions = new HashSet<ProcessDefinitionVersion>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public byte DefinitionType { get; set; }
        public string ExceptionCode { get; set; }
        public string Name { get; set; }
        public string ExceptionSectionTemplateName { get; set; }
        public string Description { get; set; }
        public byte? SignedOffState { get; set; }
        public int? BusinessProcessId { get; set; }
        public string SectionTemplateName { get; set; }
        public string SectionTemplateDescription { get; set; }

        public virtual BusinessProcess BusinessProcess { get; set; }
        public virtual ICollection<DecisionChoice> DecisionChoices { get; set; }
        public virtual ICollection<ProcessDefinitionVersion> ProcessDefinitionVersions { get; set; }
    }
}
