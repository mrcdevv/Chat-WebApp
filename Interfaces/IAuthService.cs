using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> IsRegistered(int userId);
        public Task<bool> SignUp(User user);
        public string GetToken(User user);
    }
}