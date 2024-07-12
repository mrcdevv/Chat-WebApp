using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IAuthRepository
    {
        public Task<User?> GetUserAsync(string userName);

        public Task<User> CreateUserAsync(User user);

        public Task<bool> CheckCredentials(User user);

    }
}