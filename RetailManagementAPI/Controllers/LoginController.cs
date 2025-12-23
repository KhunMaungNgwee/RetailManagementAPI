using BAL.IService;
using BAL.Service;
using Microsoft.AspNetCore.Mvc;
using MODEL.CommonConfig;
using MODEL.DTO;
using REPOSITORY.UnitOfWork;

namespace RetailManagementAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginService _loginService;
        public LoginController(IUnitOfWork unitOfWork, ILoginService loginService)
        {
            _unitOfWork = unitOfWork;
            _loginService = loginService;
        }
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser(AddUserDTO inputModel)
        {
            try
            {
                var returndata = await _loginService.AddUser(inputModel);
                return Ok(new Response { Message = Messages.AddSuccess, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {
                return Ok(new Response { Message = ex.InnerException.Message, Status = APIStatus.Error });

            }
        }
        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(LoginRequestDTO inputModel)
        {
            try
            {
                var returndata=await _loginService.UserLogin(inputModel);
                return Ok(new Response { Message = Messages.Successfully, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {
                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });

            }
        }
    }
}
