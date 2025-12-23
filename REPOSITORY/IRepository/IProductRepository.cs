using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //Task<(IEnumerable<GetAllOrderWithProductModel> items, int totalCount)> GetAllOrdersWithProductsAsync(int page, int pageSize);
        Task<decimal?> GetOrdersTotalRevenueAsync();
        Task<decimal?> GetOrdersTotalProfitAsync();
        Task<(IEnumerable<GetAllOrderWithProductModel> items, int totalCount)> GetAllOrdersWithProductsAsync(
int page,
int pageSize,
DateTime? startDate,
DateTime? endDate);
    }
}
