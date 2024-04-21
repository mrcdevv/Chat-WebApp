using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatWebApp.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ChatContext _context;

        public AuthRepository()
        {
            _context = new ChatContext();
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return user;
            }

            return null;
        }

        public async Task<int?> CreateUserAsync(User user)
        {
            if (user == null)
            {
                return null;
            }

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user.Id;
            }
            catch (Exception)
            {
                return null;
            }

        }




    }
}