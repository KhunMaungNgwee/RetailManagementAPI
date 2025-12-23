using MODEL.DTO;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IOrderService
    {
        Task<OrderResponse> CalculateCost(Guid pid, int quantity);
        Task<IEnumerable<Order>> GetAllOrder();
        Task<IEnumerable<Order>> GetOrdertById(Guid oid);

        Task<bool> PurchaseProduct(List<OrderRequest> orderRequests);
        Task<IEnumerable<Order>> GetOrderByProductId(Guid pid);
    }
}
