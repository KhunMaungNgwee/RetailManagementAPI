using BAL.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODEL.CommonConfig;
using MODEL.DTO;
using REPOSITORY.UnitOfWork;

namespace RetailManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        public ProductController(IUnitOfWork unitOfWork, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var returndata = await _productService.GetAllProduct();
                return Ok(new Response { Message = Messages.Successfully, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }

        }
        //[Authorize]
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var returndata = await _productService.GetProductById(id);
                return Ok(new Response { Message = Messages.Successfully, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
        }
        //[Authorize]
        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewUser(AddProductDTO inputModel)
        {
            try
            {
                var returndata = await _productService.AddProduct(inputModel);
                return Ok(new Response { Message = Messages.AddSuccess, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {
                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });

            }
        }
        //[Authorize]
        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var returndata = await _productService.DeleteProduct(id);
                return Ok(new Response { Message = Messages.DeleteSuccess, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
        }
        //[Authorize]
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateProductDTO inputModel)
        {
            try
            {
                var result = await _productService.UpdateProduct(inputModel);
                if (result)
                {
                    return Ok(new Response { Message = Messages.UpdateSuccess, Status = APIStatus.Successful });
                }
                return BadRequest(new Response { Message = "Failed to update product.", Status = APIStatus.Error });
            }
            catch (Exception ex)
            {
                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
        }
        [HttpGet("GetAllProductsWithPagination")]
        public async Task<IActionResult> GetAllProductsWithPagination(int page = 1, int pageSize = 10)
        {
            try
            {
                var returnData = await _productService.GetAllProductsWithPagination(page, pageSize);
                if (returnData != null)
                {
                    return Ok(new Response { Message = Messages.Successfully, Status = APIStatus.Successful, Data = returnData });
                }
                return Ok(new Response { Message = Messages.ErrorWhileFetchingData, Status = APIStatus.Error });
            }
            catch (Exception ex)
            {
                return Ok(new Response { Message = ex.Message, Status = APIStatus.SystemError });
            }
        }
        //[HttpGet("GetAllOrderWithProduct")]
        //public async Task<IActionResult> GetAllOrderWithProduct()
        //{
        //    try
        //    {
        //        var returndata=await _productService.GetAllOrderWithProduct();
        //        return Ok(new Response {Message= Messages.Result, Status=APIStatus.Successful, Data = returndata });
        //    }
        //    catch (Exception ex)
        //    {

        //        return Ok(new Response { Message=ex.Message,Status=APIStatus.Error});
        //    }
        //}
        [HttpGet("GetProductOrderWithPagination")]
        public async Task<IActionResult> GetProductOrderWithPagination(
     int page = 1,
     int pageSize = 10,
     DateTime? startDate = null,
     DateTime? endDate = null)
        {
            try
            {
                // Call the service method with the new parameters
                var returndata = await _productService.GetAllProductOrdersWithPaginationAsync(page, pageSize, startDate, endDate);

                // Return a successful response
                return Ok(new Response
                {
                    Message = Messages.Result,
                    Status = APIStatus.Successful,
                    Data = returndata
                });
            }
            catch (Exception ex)
            {
                // Return an error response
                return Ok(new Response
                {
                    Message = ex.Message,
                    Status = APIStatus.Error
                });
            }
        }

    }

}
