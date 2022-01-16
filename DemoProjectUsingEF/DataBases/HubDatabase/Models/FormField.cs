using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class FormField
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }
        public bool IsKeyField { get; set; }
        public int FormPageId { get; set; }
        public int InitialState { get; set; }
        public string Label { get; set; }
        public string AutomationId { get; set; }
        public string Description { get; set; }
        public string Payload { get; set; }

        public virtual FormPage FormPage { get; set; }
    }
}
