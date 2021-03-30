using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using HRM.ERP.Common.Models;
using HRM.ERP.WebAPI.JWTConfig;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HRM.ERP.WebAPI.Helpers
{
    public class AuthService: IAuthService
    {
        private readonly Config _config;

        public AuthService(IOptions<Config> config)
        {
            _config = config.Value;
        }

        private readonly List<UserLogin> users = new List<UserLogin>()
        {
            new UserLogin
            {
                Email = "suyash@hrm.com",
                Password = "asdf123@"
            }
        };

        public UserLogin Authenticate(string email, string password)
        {
            var user = users.SingleOrDefault(u => u.Email.ToLower() == email && u.Password == password);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Password = null;
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
