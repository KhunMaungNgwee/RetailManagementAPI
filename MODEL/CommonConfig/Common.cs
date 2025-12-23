using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.CommonConfig
{
    public class Common
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;
        public bool ActiveFlag { get; set; } = true;
    }
}
