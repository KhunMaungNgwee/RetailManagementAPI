using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entity
{
    public class Users : CommonONe
    {
        [Key]
        public int? Id { get; set; }    
        public string? ProfileID { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; } = null;
        public string? Password { get; set; } = null;
        public string? Gender { get; set; } = null;
        public string? Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? ProfilePic { get; set; }=null;
        public string? Thumbnail {  get; set; } = null;
        public string? UserType { get; set; } = null;
        public string? Compare { get; set; } = null;
        public bool? Lock { get; set; }
        public bool? Noti   { get; set; }
        public string? EmailLanguage { get; set; }

        public byte[]? SaltHash { get; set; }
        public byte[]? SaltAes { get; set; } 
        public string?  PinCode { get; set; } = null;
        public int?   TotalSuccessful {  get; set; } = null;
        public int? DailyAverage { get; set; } = null;
        public DateTime? DailyAverageDate { get; set; }
        public string? Positions { get; set; } = null;
        public int? RoleID { get; set; } = null;
        public int? UserRole { get; set; } = null;
        public bool? ForceReset { get; set; } = null;
        public bool? LockStatus { get; set; } = null;
        public Guid? CompanyId { get; set; } = null;
        public Guid? MemberID { get; set; } = null;
        public DateTime? PasswordUpdateDate { get; set; }=null;
        public int? GoalMinutes { get; set; } = null;
        public bool? IsEnable { get; set; } = null;
        public string? DeviceID { get; set; } = null;
        public bool? PolicyTypeM { get; set; } = null;
        public bool? PolicyTypeW { get; set; } = null;
        public bool? EmailCheck { get; set; } = null;
        public bool? Finger_Face { get; set; } = null;
        public string? Language { get; set; } = null;
        public string? LanguageUserView { get; set; } = null;
        public int? DepartmentId { get; set; } = null;
        public string? LineUserID { get; set; } = null;
       
    }
}
