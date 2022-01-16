using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Table
    {
        public Table()
        {
            Columns = new HashSet<Column>();
            TableLayouts = new HashSet<TableLayout>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<TableLayout> TableLayouts { get; set; }
    }
}
