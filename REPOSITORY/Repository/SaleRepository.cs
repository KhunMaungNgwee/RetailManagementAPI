using MODEL;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repository
{
    public class SalesRepo : ISalesRepo
    {
        private readonly DataContext _context;
        

        public SalesRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetSalesByConditionWithPagination(Func<Order, bool> condition, int page, int pageSize, Func<Order, object> orderBy)
        {
            return await Task.Run(() =>
            {
                var query = _context.Order.Where(condition).OrderBy(orderBy);
                return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            });
        }

        public async Task<int> CountSalesAsync(Func<Order, bool> condition)
        {
            return await Task.Run(() => _context.Order.Count(condition));
        }
    }
}
