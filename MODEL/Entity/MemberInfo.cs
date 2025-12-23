using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public  class MemberInfo : CommonONe
    {
        [Key]
        public Guid? MemberID { get; set; }
        public Guid? CompanyId { get; set; }
        public long? IDCard { get; set; }
        public string? Prefix { get; set; } 
        public string? FirstName { get; set; } 
        public string? FullName { get; set; } 
        public string? LastName { get; set; } 
        public string? Mobile { get; set; } 
        public string? EMail { get; set; } 
        public string? Department { get; set; } 
        public string? Levels { get; set; } 
        public string? PathImage { get; set; } 
        public string? Gender { get; set; } 
        public string? ContactName { get; set; } 
       
    }
}
