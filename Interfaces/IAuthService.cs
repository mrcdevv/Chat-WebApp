using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IAuthService
    {
        public Task<User?> GetUserAsync(int userId);
        public Task<bool> CreateUserAsync(User user);
        public string CreateToken(User user);
        public Task<bool> CheckCredentials(User user);
    }
}