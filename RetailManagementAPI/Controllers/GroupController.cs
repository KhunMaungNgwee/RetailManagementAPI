using BAL.IService;
using Microsoft.AspNetCore.Mvc;
using MODEL.CommonConfig;
using MODEL.DTO;
using REPOSITORY.UnitOfWork;

namespace RetailManagementAPI.Controllers
{
    public class GroupController : ControllerBase
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupService _groupService;
        public GroupController(IUnitOfWork unitOfWork,IGroupService groupService)
        {
            _unitOfWork = unitOfWork;
            _groupService = groupService;
        }
        [HttpGet("GetAllGroup")]
        public async Task<IActionResult> GetAllGroup()
        {
            try
            {
                var returndata = await _groupService.GetAllGroup();
                return Ok(new Response { Message = Messages.Result, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error }); 
            }
            
        }
        [HttpGet("GetGroupByID")]
        public async Task<IActionResult> GetGroupByID(int id)
        {
            try
            {
                var returndata=await _groupService.GetGroupByID(id);
                return Ok(new Response { Message = Messages.Result, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message=ex.Message,Status=APIStatus.Error});
            }
        }
        [HttpPost("AddNewGroup")]
        public async Task<IActionResult> AddNewGroup([FromBody] AddGroupDTO inputModel)
        {
            try
            {
                var returndata = await _groupService.AddNewGroup(inputModel);
                return Ok(new Response { Message=Messages.AddSuccess, Status = APIStatus.Successful,Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
        }
        [HttpPost("DeleteGroup")]
        public async Task<IActionResult> DeleteGroup(int gid)
        {
            try
            {
                var returndata = await _groupService.DeleteGroup(gid);
                return Ok(new Response { Message = Messages.DeleteSuccess, Status = APIStatus.Successful, Data = returndata });
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message=ex.Message,Status=APIStatus.Error});
            }
            
        }
        [HttpPost("UpdateGroup")]
        public async Task<IActionResult> UpdateGroup( [FromBody] AddGroupDTO group)
        {
            try
            {
                var returndata = await _groupService.UpdateGroup(group);
                if (returndata)
                {
                    return Ok(new Response { Message = Messages.UpdateSuccess, Status = APIStatus.Successful, Data = returndata });
                  }
                else {
                    return BadRequest(new Response { Message = "Failed to update group", Status = APIStatus.Error }); 
                    }
            }
            catch (Exception ex)
            {

                return Ok(new Response { Message = ex.Message, Status = APIStatus.Error });
            }
            
        }
    }
}
