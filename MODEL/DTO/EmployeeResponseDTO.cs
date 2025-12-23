using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    public class EmployeeResponseDTO
    {
        public string ProfileID { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; } = null;
        public string? Password { get; set; } = null;
        public string? Gender { get; set; } = null;
        public string? Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? ProfilePic { get; set; } = null;
        public string? Thumbnail { get; set; } = null;
        public string? UserType { get; set; } = null;
        public string? Compare { get; set; } = null;
        public bool? Lock { get; set; }
        public bool? Noti { get; set; }
        public string? Department { get; set; }
        public string? EmailLanguage { get; set; }
        public byte? SaltHash { get; set; } = null;
        public byte? SaltAes { get; set; } = null;
        public string? PinCode { get; set; } = null;
        public int? TotalSuccessful { get; set; } = null;
        public int? DailyAverage { get; set; } = null;
        public DateTime? DailyAverageDate { get; set; }
        public string? Positions { get; set; } = null;
        public int? RoleID { get; set; } = null;
        public int? UserRole { get; set; } = null;
        public bool? ForceReset { get; set; } = null;
        public List<EmployeeGroupResponse>? EmployeeGroup { get; set; }
        public List<EmployeeRoleResponse>? EmployeeRoles { get; set; }
        public bool? LockStatus { get; set; } = null;
        public Guid? CompanyId { get; set; } = null;
        public Guid? MemberID { get; set; } = null;
        public DateTime? PasswordUpdateDate { get; set; } = null;
        public int? GoalMinutes { get; set; } = null;
        public bool? IsEnable { get; set; } = null;
        public string? DeviceID { get; set; } = null;
        public bool? PolicyTypeM { get; set; } = null;
        public bool? PolicyTypeW { get; set; } = null;
        public bool? EmailCheck { get; set; } = null;
        public bool? Finger_Face { get; set; } = null;
        public string? Language { get; set; } = null;
        public string? LanguageUserView { get; set; } = null;
        public int? DepartmentId { get; set; } 
        public string? LineUserID { get; set; } = null;
        public string? EmpID { get; set; } = null;  

        
        public Guid? EmployeeID { get; set; }
        public int? SalaryID { get; set; } = null;
        public int? UserID { get; set; } = null;
        public int? SupervisorID { get; set; } = null;
        public DateTime? StartWorkDate { get; set; } = null;
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }

       
        public string? ContentCount { get; set; } = null;
    
        public string? DepartmentName { get; set; }
        public string? LineID { get; set; }

        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? ActiveFlag { get; set; }
    }

    public class EmployeeGroupResponse
    {
        public int? TEmp_Group_ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? GroupID { get; set; }
        public string? GroupName { get; set; }
    }

    public class EmployeeRoleResponse
    {
        public int? TEmp_Role_ID { get; set; }
        public int? UserRoleID { get; set; }
        public int? EmployeeID { get; set; }
        public string? RoleName { get; set; }
    }


}
