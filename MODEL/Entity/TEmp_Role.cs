using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class TEmp_Role : CommonONe
    {
        [Key]
        public int? TEmp_Role_ID { get; set; } 
        public int? EmployeeID { get; set; } 
        public int? RoleID { get; set; } = null;
       
    }
}
