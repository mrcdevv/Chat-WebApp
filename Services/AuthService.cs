using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using ChatWebApp.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ChatWebApp.Services
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;
        private readonly AuthRepository _repository;

        public AuthService(IConfiguration config)
        {
            _configuration = config;
            _repository = new AuthRepository();
        }

        public string GetToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var privateKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddHours(1), signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<bool> IsRegistered(int userId)
        {
            return await _repository.IsRegistered(userId);
        }

        public Task<bool> SignUp(User user)
        {
            throw new NotImplementedException();
        }
    }
}