using BAL.IService;
using BAL.Service;
using Microsoft.AspNetCore.Mvc;
using MODEL.CommonConfig;

namespace RetailManagementAPI.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeEXTService _employeeEXTService;
        public EmployeeController(IEmployeeEXTService employeeEXTService)
        {
            _employeeEXTService = employeeEXTService;
        }



        [HttpGet("GetAllEmployeeEXTByCompanyID")]
        public async Task<IActionResult> GetAllEmployeeEXTByCompanyID(Guid Cid)
        {
            try
            {
                var returndata = await _employeeEXTService.GetAllEmployeeEXT(Cid);
                return Ok(new Response { Message = Messages.Result, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error }); ;
            }
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            try
            {
                // Call the service to upload the file and get the file path
                var filePath = await _employeeEXTService.UploadFile(formFile);

                // Check if the file path is returned
                if (filePath != null)
                {
                    return Ok(new Response
                    {
                        Message = Messages.UploadFileSuccess,
                        Status = APIStatus.Successful,
                        Data = filePath // Return the file path in the response
                    });
                }

                // In case of an upload failure without exception
                return BadRequest(new Response
                {
                    Message = "File upload failed.",
                    Status = APIStatus.Error
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response
                {
                    Message = ex.Message,
                    Status = APIStatus.Error
                });
            }
        }

    }
}
