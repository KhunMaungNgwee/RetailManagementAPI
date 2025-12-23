using BAL.IService;
using BAL.Service;
using Microsoft.AspNetCore.Mvc;
using MODEL.CommonConfig;
using MODEL.DTO;
using REPOSITORY.UnitOfWork;
using System.Runtime.InteropServices;

namespace RetailManagementAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]    
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        public OrderController(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }
        [HttpPost("CalculateCost")]
        public async Task<IActionResult> CalculateCost(Guid productid,int quantity)
        {
            try
            {
                var returndata = await _orderService.CalculateCost(productid,quantity);
                return Ok(new Response { Message = Messages.CalculateCostSuccess, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });

            }
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var returndata=  await _orderService.GetAllOrder();
                return Ok(new Response { Message = Messages.Result, Status=APIStatus.Successful,Data=returndata});
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message=ex.Message,Status=APIStatus.Error});
            }
        }
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(Guid oid)
        {
            try
            {
                var returndata = await _orderService.GetOrdertById(oid);
                return Ok(new Response { Message = Messages.Result, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
        }
        [HttpPost("PurchaseProduct")]
        public async Task<IActionResult> PurchaseProduct(List<OrderRequest> orderRequests)
        {
            try
            {
                var returndata = await _orderService.PurchaseProduct(orderRequests);
                 return Ok(new Response { Message = Messages.PurchaseSuccess, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error }); 
            }
        }
        [HttpGet("GetOrderByProductID")]
        public async Task<IActionResult> GetOrderByProductId(Guid pid)
        {
            try
            {
                var returndata = await _orderService.GetOrderByProductId(pid);
                return Ok(new Response { Message = Messages.Result, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
        }
    }
}
