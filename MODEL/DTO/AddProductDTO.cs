using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    public class AddProductDTO
    {
        public string? ProductName { get; set; }
        public int? Stock { get; set; }
        public Decimal? SellingPrice { get; set; }
        public Decimal? ProfitPerItem { get; set; }
    }
    public class AddGroupDTO
    {
        public int? GroupID { get; set; }
        public string? UGroupID { get; set; }
        public string? GroupName { get; set; }
        public int? RoleID { get; set; }
    }
    public class ProductWithPaginationResDTO<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class ProductOrderWithPaginationResDTO<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllOrderWithProductModel
    {
        public Guid ProductID { get; set; }
        public Guid OrderID { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? ProfitPerItem { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalProfit { get; set; }
        public DateTime? OrderCreatedTime { get; set; }
    }
    public class ProductOrderWithPaginationResDTO
    {
        public List<GetAllOrderWithProductModel> Items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalProfit { get; set; }
    }

}
