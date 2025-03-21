using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class TransactionHistory : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public string ? Status { get; set; }
        public string? Waktu { get; set; }
    }
}
