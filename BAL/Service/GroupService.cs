using BAL.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class GroupService:IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public GroupService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
           
            _configuration = configuration;
        }
        public async Task<IEnumerable<Group>> GetAllGroup()
        {
            var allGroup = await _unitOfWork.GroupRepository.GetAll();
            return allGroup;
        }
        public async Task<IEnumerable<Group>> GetGroupByID(int gid)
        {
            var group = await _unitOfWork.GroupRepository.GetByCondition(x=>x.GroupID==gid);
            return group;
        }
        public async Task<bool> AddNewGroup(AddGroupDTO inputModel)
        {
            var newGroup = new Group()
            {
                GroupID = new int(),
                UGroupID = inputModel.UGroupID,
                GroupName = inputModel.GroupName,
                CreateBy = "Admin",
                CreateDate = DateTime.UtcNow
            };
            await _unitOfWork.GroupRepository.Add(newGroup);
            int save=await _unitOfWork.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }
            else {
                return false;
            }
            
        }
        public async Task<bool> DeleteGroup(int groupID)
        {
            var gp = (await _unitOfWork.GroupRepository.GetByCondition(x => x.GroupID == groupID)).FirstOrDefault();
            if (gp != null) 
            {
                gp.ActiveFlag = false;
               _unitOfWork.GroupRepository.Update(gp) ;
                var i = await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
        public async Task<bool> UpdateGroup(AddGroupDTO gpDTO)
        {
            var gp=(await _unitOfWork.GroupRepository.GetByCondition(x=>x.GroupID == gpDTO.GroupID)).FirstOrDefault();
            if (gp != null)
            {

                gp.GroupName = gpDTO.GroupName;
                gp.UGroupID = gpDTO.UGroupID;
                gp.UpdateBy = "admin";
                gp.UpdateDate = DateTime.UtcNow;
                _unitOfWork.GroupRepository.Update(gp);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
    }
}
