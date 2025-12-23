using MODEL.DTO;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface ILoginService
    {
        Task<bool> AddUser(AddUserDTO inputUser);
        Task<string> UserLogin(LoginRequestDTO inputUser);
    }
}
