using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ColumnSetting
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
        public bool IsShown { get; set; }
        public int ColumnId { get; set; }
        public int LayoutSettingsId { get; set; }

        public virtual Column Column { get; set; }
        public virtual LayoutSetting LayoutSettings { get; set; }
    }
}
