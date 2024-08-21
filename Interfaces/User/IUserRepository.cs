using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;


namespace ChatWebApp.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> FindUserAsync(int id);

        public Task<User?> UpdateUserAsync(User newData, int id);
    }
}