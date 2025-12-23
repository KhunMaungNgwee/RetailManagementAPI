using Microsoft.EntityFrameworkCore;
using MODEL;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repository
{
    public class EmployeeEXTRepository : GenericRepository<EmployeeEXT>, IEmployeeEXTRepository
    {
        private readonly DataContext _dbContext;
        public EmployeeEXTRepository(DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
        public async Task<IEnumerable<object>> GetAllEmployeeEXT(Guid cid)
        {

            var employees = (from employee in _dbContext.EmployeeEXT
                             where employee.CompanyId == cid && employee.ActiveFlag == true

                             join member in _dbContext.MemberInfo on employee.MemberID equals member.MemberID
                             where member.ActiveFlag == true

                             join user in _dbContext.Users on employee.UserID equals user.Id
                             where user.ActiveFlag == true

                             join tg in _dbContext.TEmp_Group on user.Id equals tg.EmployeeID
                             where tg.ActiveFlag == true

                             join g in _dbContext.Group on tg.GroupID equals g.GroupID into groupDetails
                             from groupDetail in groupDetails
                             where groupDetail.ActiveFlag == true

                             join tr in _dbContext.TEmp_Role on user.Id equals tr.EmployeeID
                             where tr.ActiveFlag == true

                             join ur in _dbContext.UserRole on tr.RoleID equals ur.UserRoleID into roleDetails
                             from roleDetail in roleDetails
                             where roleDetail.ActiveFlag == true

                             select new
                             {
                                 employee,
                                 member,
                                 user,
                                 tg,
                                 tr,
                                 groupDetail,
                                 roleDetail
                             }).ToList();

            var filteredEmployees = employees
            .GroupBy(e => e.employee.EmployeeID)
            .Select(grouped => new EmployeeResponseDTO
            {
                EmployeeID = grouped.Key,
                SalaryID = grouped.First().employee.SalaryID,
                UserID = grouped.First().employee.UserID,
                MemberID = grouped.First().member.MemberID,
                UserName = grouped.First().user.UserName,
                FirstName = grouped.First().member.FirstName,
                Prefix = grouped.First().member.Prefix,
                LastName = grouped.First().member.LastName,
                Email = grouped.First().user.Email,
                Password = grouped.First().user.Password,
                UserType = grouped.First().user.UserType,
                RoleID = grouped.First().user.RoleID,
                Mobile = grouped.First().member.Mobile,
                Department = grouped.First().member.Department,
                DepartmentId = grouped.First().user.DepartmentId,
                SupervisorID = grouped.First().employee.SupervisorID,
                StartWorkDate = grouped.First().employee.StartWorkDate,
                UserRole = grouped.First().user.UserRole,
                FullName = $"{grouped.First().member.FirstName} {grouped.First().member.LastName}",
                Positions = grouped.First().user.Positions,

                EmpID = grouped.First().employee.EmpID,
                LockStatus = grouped.First().user.LockStatus,
                CompanyId = grouped.First().employee.CompanyId,

                EmployeeGroup = grouped.Select(g => new EmployeeGroupResponse
                {
                    TEmp_Group_ID = g.tg.TEmp_Group_ID,
                    EmployeeID = g.tg.EmployeeID,
                    GroupID = g.groupDetail.GroupID,
                    GroupName = g.groupDetail.GroupName
                }).ToList(),

                EmployeeRoles = grouped.Select(r => new EmployeeRoleResponse
                {
                    TEmp_Role_ID = r.tr.TEmp_Role_ID,
                    EmployeeID = r.tr.EmployeeID,
                    UserRoleID = r.roleDetail.UserRoleID,
                    RoleName = r.roleDetail.RoleName
                }).ToList(),

                ProfileID = grouped.First().user.ProfileID,
                JoinDate = grouped.First().user.JoinDate,
                Gender = grouped.First().user.Gender,
                IsEnable = grouped.First().user.IsEnable,
                Lock = grouped.First().user.LockStatus,
                ContentCount = grouped.First().member.ContactName,               
                DepartmentName = grouped.First().member.Department,
                LineID = grouped.First().user.LineUserID,
                EmailLanguage = grouped.First().user.EmailLanguage,
                EmailCheck = grouped.First().user.EmailCheck,
                CreateBy = grouped.First().user.CreateBy,
                CreateDate = grouped.First().user.CreateDate,
                UpdateBy = grouped.First().user.UpdateBy,
                UpdateDate = grouped.First().user.UpdateDate,
                ActiveFlag = grouped.First().user.ActiveFlag,
            }).ToList();

            return filteredEmployees;


        }
    }
}
