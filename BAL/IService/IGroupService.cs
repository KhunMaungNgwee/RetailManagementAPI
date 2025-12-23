using MODEL.DTO;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public  interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroup();
        Task<IEnumerable<Group>> GetGroupByID(int gid);
        Task<bool> AddNewGroup(AddGroupDTO gp);
        Task<bool> DeleteGroup(int groupID);
        Task<bool> UpdateGroup(AddGroupDTO gpDTO);
    }
}
