using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using ChatWebApp.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ChatWebApp.Services
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _repository;

        public AuthService(IConfiguration config, IAuthRepository repository)
        {
            _configuration = config;
            _repository = repository;
        }

        public string CreateToken(User user)
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

        public async Task<bool> CreateUserAsync(CreateUserDto userDto)
        {
            var newUser = new User
            {
                UserName = userDto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };

            var userId = await _repository.CreateUserAsync(newUser);

            return userId != null;
        }

        public async Task<bool> CheckCredentials(CreateUserDto userDto)
        {
            var user = await _repository.GetUserAsync(userDto.UserName);

            if (user == null)
            {
                return false;
            }

            if (userDto.UserName == user.UserName)
            {
                return BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password);
            }

            return false;
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            var user = await _repository.GetUserAsync(userName);
            return user;
        }

        public async Task<bool> UserExistAsync(string userName)
        {
            var user = await _repository.GetUserAsync(userName);
            return user != null;
        }
    }
}