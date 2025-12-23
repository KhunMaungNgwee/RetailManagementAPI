using BAL.IService;
using BAL.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.IRepository;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public LoginService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> UserLogin(LoginRequestDTO inputUser)
        {
            var user = (await _unitOfWork.LoginRepository.GetByCondition(u => u.Email == inputUser.Email)).FirstOrDefault();
            if (user == null)
            { return "User Not Found "; }
            var hasher = new PasswordHasher<User>();
            var result=hasher.VerifyHashedPassword(user,user.Password,inputUser.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return "Invalid Password";
            }
            //var tokenProvider = new TokenGenerator();
            var token = TokenGenerator.GenerateCustomerToken(user);
            return token;

        }
        public async Task<bool> AddUser(AddUserDTO inputUser)
        {
            var user = new User()
            {
                UserID =  Guid.NewGuid(),
                Email = inputUser.Email,
               Password = new PasswordHasher<User>().HashPassword(null, inputUser.Password),
                Role = inputUser.Role,
                CreatedBy = "admin",
                CreatedTime = DateTime.UtcNow,
            };
            await _unitOfWork.LoginRepository.Add(user);
            int save= await _unitOfWork.SaveChangesAsync();
            if (save > 0) {
                return true;
            }
            else { return false; }
        }
    }
}
