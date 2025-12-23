using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public  class User:Common
    {
        [Key]
        public Guid UserID { get; set; }
        public string? Email { get; set; }   
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
