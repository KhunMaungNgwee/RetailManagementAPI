using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class UserRole : CommonONe
    {
        [Key]
        public int? UserRoleID { get; set; }
        public string? RoleCode { get; set; } = null;
        public string? RoleName { get; set; } = null;
        public Guid? CompanyID { get; set; } = null;
  

    }
}
