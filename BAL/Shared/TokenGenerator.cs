using Microsoft.IdentityModel.Tokens;
using MODEL.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BAL.Shared
{
    public class TokenGenerator
    {
        private static readonly SymmetricSecurityKey Key = new(Encoding.UTF8.GetBytes("^6L@QAWsW>eUk/q|X38fHu?#=6YTWWZWXw[0T/C^O84R48NC@9p{1,~)M?2s{so"));
        private static readonly SigningCredentials Credentials = new(Key, SecurityAlgorithms.HmacSha256);

        public static string GenerateCustomerToken(User user)
        {
            
            var claims = new List<Claim>
     {
         new Claim("Email", user.Email.ToString()),
         new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
         new Claim(ClaimTypes.Role,user.Role),
         
     };
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Fusion",
                Audience = "Fusion", 
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = Credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
