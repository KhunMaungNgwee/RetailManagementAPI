using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class EmployeeEXT:CommonONe
    {
        [Key]
        public Guid? EmployeeID { get; set; }
        public string? EmpID { get; set; }
        public int? SalaryID { get; set; } 
        public int? UserID { get; set; } 
        public Guid? MemberID { get; set; } 
        public Guid? CompanyId { get; set; } 
        public int? SupervisorID { get; set; } 
        public DateTime? StartWorkDate { get; set; } 
        
    }
}
