using Microsoft.EntityFrameworkCore;
using MODEL;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repository
{

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }

        // Existing method to get paginated product orders
        public async Task<(IEnumerable<GetAllOrderWithProductModel> items, int totalCount)> GetAllOrdersWithProductsAsync(
int page,
int pageSize,
DateTime? startDate,
DateTime? endDate)
        {
            // Base query
            var query = from order in _dbContext.Order
                        join product in _dbContext.Product
                        on order.ProductID equals product.ProductID
                        where order.ActiveFlag && product.ActiveFlag
                        select new GetAllOrderWithProductModel
                        {
                            OrderID = order.OrderID,
                            ProductID = product.ProductID,
                            ProductName = product.ProductName,
                            Quantity = order.Quantity,
                            SellingPrice = product.SellingPrice,
                            ProfitPerItem = product.ProfitPerItem,
                            TotalRevenue = order.Quantity * product.SellingPrice,
                            TotalProfit = order.Quantity * product.ProfitPerItem,
                            OrderCreatedTime = order.CreatedTime,
                        };

            // Apply date filters if provided
            if (startDate.HasValue)
            {
                query = query.Where(x => x.OrderCreatedTime >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(x => x.OrderCreatedTime <= endDate.Value);
            }

            // Get total count for pagination
            var totalCount = await query.CountAsync();

            // Get paginated items
            var items = await query
                .OrderByDescending(x => x.OrderCreatedTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount); // Return items and total count as a tuple
        }
        // New method to get total revenue across all orders
        public async Task<decimal?> GetOrdersTotalRevenueAsync()
        {
            return await _dbContext.Order
                .Where(order => order.ActiveFlag)
                .Join(_dbContext.Product, order => order.ProductID, product => product.ProductID,
                    (order, product) => new { order.Quantity, product.SellingPrice })
                .SumAsync(entry => entry.Quantity * entry.SellingPrice);
        }

        // New method to get total profit across all orders
        public async Task<decimal?> GetOrdersTotalProfitAsync()
        {
            return await _dbContext.Order
                .Where(order => order.ActiveFlag)
                .Join(_dbContext.Product, order => order.ProductID, product => product.ProductID,
                    (order, product) => new { order.Quantity, product.ProfitPerItem })
                .SumAsync(entry => entry.Quantity * entry.ProfitPerItem);
        }

    }
}








