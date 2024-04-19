using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IAuthService
    {
        public bool IsRegistered(User user);
        public bool SignUp(User user);
        public string GetToken();
    }
}