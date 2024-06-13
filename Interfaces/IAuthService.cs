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
        public Task<User?> GetUserAsync(string userName);
        public Task<bool> UserExistAsync(string userName);
        public string CreateToken(User user);
        public Task<bool> CreateUserAsync(CreateUserDto user);
        public Task<bool> CheckCredentials(CreateUserDto user);
    }
}