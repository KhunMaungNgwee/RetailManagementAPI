using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.IRepository
{
    public interface ISalesRepo
    {
        Task<IEnumerable<Order>> GetSalesByConditionWithPagination(Func<Order, bool> condition, int page, int pageSize, Func<Order, object> orderBy);
        Task<int> CountSalesAsync(Func<Order, bool> condition);
    }
}
