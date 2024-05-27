using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IAuthService
    {
        public Task<User?> GetUserAsync(int userId);
        public Task<bool> UserExist(string userName);
        public Task<bool> CreateUserAsync(CreateUserDto user);
        public string CreateToken(User user);
        public string CreateToken(CreateUserDto user);
        public Task<bool> CheckCredentials(CreateUserDto user);
    }
}