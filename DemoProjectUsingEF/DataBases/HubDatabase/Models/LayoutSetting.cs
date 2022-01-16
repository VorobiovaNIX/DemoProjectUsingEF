using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class LayoutSetting
    {
        public LayoutSetting()
        {
            ColumnSettings = new HashSet<ColumnSetting>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int LayoutId { get; set; }
        public bool IsCurrent { get; set; }
        public bool WithFilters { get; set; }

        public virtual TableLayout Layout { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ColumnSetting> ColumnSettings { get; set; }
    }
}
