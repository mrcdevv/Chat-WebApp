using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;
using ChatWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatWebApp.Repositories
{
    public class AuthRepository
    {
        private readonly ChatContext _context;

        public AuthRepository()
        {
            _context = new ChatContext();
        }

        public async Task<bool> IsRegistered(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CreateUser(User user)
        {
            if (user == null)
            {
                return false;
            }

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }




    }
}