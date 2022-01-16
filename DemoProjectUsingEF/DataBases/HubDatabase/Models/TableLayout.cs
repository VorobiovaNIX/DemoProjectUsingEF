using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class TableLayout
    {
        public TableLayout()
        {
            LayoutSettings = new HashSet<LayoutSetting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string TableId { get; set; }

        public virtual Table Table { get; set; }
        public virtual ICollection<LayoutSetting> LayoutSettings { get; set; }
    }
}
