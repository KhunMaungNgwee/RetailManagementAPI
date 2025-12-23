using BAL.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        
        public OrderService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var returndata = await _unitOfWork.IOrderRepo.GetByCondition(x => x.ActiveFlag == true);
            return returndata;
        }
        public async Task<IEnumerable<Order>> GetOrdertById(Guid oid)
        {
            var order = await _unitOfWork.IOrderRepo.GetByCondition(x => x.OrderID == oid);
            return order;
        }
        public async Task<OrderResponse> CalculateCost(Guid pid,int quantity)
        {
            
            var product=await _unitOfWork.IProductRepo.GetByGuid(pid);
            if (product == null || !product.ActiveFlag)
            {
                throw new KeyNotFoundException("Product Not Found Or Inactive");
            }
            else if(quantity>product.Stock)

            {
                throw new KeyNotFoundException("Not Enought stock available");
            }
            else
            {
                var total=product.SellingPrice* quantity;
                //var orderData = new Order()
                //{
                //    OrderID = new Guid(),
                //    Quantity = quantity,
                //    CreatedTime = DateTime.UtcNow,
                //    CreatedBy = "Casher",
                //};
                //await _unitOfWork.IOrderRepo.Add(orderData);
                //int save =await _unitOfWork.SaveChangesAsync();

              
                var orderRes = new OrderResponse()
                {
                    ProductID = pid,
                    ProductName = product.ProductName,
                    Quantity = quantity,
                    Total = total,
                };
                return orderRes;
            }
        }

        public async Task<IEnumerable<Order>> GetOrderByProductId(Guid pid)
        {
            var orderRes= new List<Order>();
            //var product = (await _unitOfWork.IProductRepo.GetByCondition(x => x.ProductID == pid)).FirstOrDefault();
            var orders = await _unitOfWork.IOrderRepo.GetAll();
            foreach(var o in orders)
            {
                if(o.ProductID == pid)
                {
                    orderRes.Add(o);
                }
            }
            return orderRes;

        }
        public async Task<bool> PurchaseProduct(List<OrderRequest> orderRequests)
        {
                if (orderRequests ==null)
                {
                    return false;
                }
                foreach (var orderRequest in orderRequests)
                {
                    var product = (await _unitOfWork.IProductRepo.GetByCondition(x=>x.ProductID==orderRequest.ProductID)).FirstOrDefault();
                    if(product == null|| product.ActiveFlag==false)
                    {
                        return false;
                    }
                    if (product.Stock < orderRequest.Quantity || orderRequest.Quantity == 0)
                    {
                        return false;
                    }
                    var order = new Order()
                    {
                        OrderID = new Guid(),
                        ProductID = product.ProductID,
                        Quantity = orderRequest.Quantity,
                        CreatedTime = DateTime.UtcNow,
                        CreatedBy = "Casher",
                    };
                    await _unitOfWork.IOrderRepo.Add(order);
                    int save=await _unitOfWork.SaveChangesAsync();

                

                if (order == null)
                {
                    throw new InvalidOperationException("Order not found.");
                }

                if (product == null)
                {
                    throw new InvalidOperationException("Product not found.");
                }

               


                product.Stock -= order.Quantity;
                    _unitOfWork.IProductRepo.Update(product);
                    
                }
                return true; 
            }
           
    }
}
