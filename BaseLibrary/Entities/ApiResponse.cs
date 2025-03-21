using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class ApiResponse : BaseEntity
    {
        public string GroupNo { get; set; }
        public string GroupName { get; set; }
        public string LineNo { get; set; }
        public string Caption { get; set; }
        public string Value { get; set; }
    }
}
