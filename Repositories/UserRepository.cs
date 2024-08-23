using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;

namespace ChatWebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatContext _context;

        public UserRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task<User?> FindUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateUserAsync(User newData, int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.UserName = newData.UserName ?? user.UserName;
                user.Email = newData.Email ?? user.Email;

                await _context.SaveChangesAsync();
            }

            return user;
        }
    }
}