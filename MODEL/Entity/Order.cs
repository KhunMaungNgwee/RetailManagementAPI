using Azure;
using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class Order:Common
    {
        [Key]
        public Guid OrderID { get; set; }

        public Guid ProductID { get; set; }
        public int? Quantity { get; set; }
      
    }
}
