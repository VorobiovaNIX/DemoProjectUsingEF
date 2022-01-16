using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Column
    {
        public Column()
        {
            ColumnSettings = new HashSet<ColumnSetting>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
        public string UniqueId { get; set; }
        public string TableId { get; set; }

        public virtual Table Table { get; set; }
        public virtual ICollection<ColumnSetting> ColumnSettings { get; set; }
    }
}
