using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.CommonConfig
{
    public class CommonONe
    {
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; } = DateTime.UtcNow;
        public bool? ActiveFlag { get; set; } = true;
    }
}
