using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ChatWebApp.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ChatContext _context;

        public AuthRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
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

        public async Task<bool> CheckCredentials(User user)
        {
            var userInDb = await GetUserAsync(user.UserName);

            if (userInDb == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(user.Password, userInDb.Password);
        }
    }
}