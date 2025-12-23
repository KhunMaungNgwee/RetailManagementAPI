using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    internal class AddOrderDTO
    {
        public string? ProductID { get; set; }
        public int? Quantity { get; set; }
    }

    public class OrderResponse
    {
        public Guid? ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

    }
    public class OrderRequest
    {
        public Guid ProductID { get; set; }
        public int? Quantity { get; set; }
    }
}
