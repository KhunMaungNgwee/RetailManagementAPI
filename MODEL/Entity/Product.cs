using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class Product:Common
    {
        [Key]
        public Guid ProductID { get; set; }
        public string? ProductName { get; set; }
        public  int? Stock {  get; set; }
        public Decimal? SellingPrice { get; set; }
        public Decimal? ProfitPerItem { get; set; }
        
    }
}
