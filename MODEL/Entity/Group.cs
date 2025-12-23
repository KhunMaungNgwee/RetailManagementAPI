using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class Group : CommonONe
    {
        [Key]
        public int? GroupID { get; set; } 
        public string? UGroupID { get; set; } 
        public string? GroupName { get; set; } 
        public int? RoleID { get; set; }
        public Guid? CompanyId { get; set; }
        

    }
}
