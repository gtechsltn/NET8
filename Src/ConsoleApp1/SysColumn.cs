using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public record SysColumn
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public short MaxLength { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public bool? IsNullable { get; set; }
        public bool PrimaryKey { get; set; }
    }
}
