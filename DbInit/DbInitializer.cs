using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;
using ChatWebApp.Models;

namespace ChatWebApp.DbInit
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ChatContext _context;

        public DbInitializer(ChatContext context)
        {
            _context = context;
        }

        public void Initilize()
        {
            // Look for any users already in the database.
            if (_context.Users.Any() || _context.Rooms.Any() || _context.Messages.Any() || _context.RoomUsers.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Users with hashed passwords
            var users = new[]
            {
                    new User { UserName = "Alice", Password = BCrypt.Net.BCrypt.HashPassword("password1") },
                    new User { UserName = "Bob", Password = BCrypt.Net.BCrypt.HashPassword("password2") },
                    new User { UserName = "Charlie", Password = BCrypt.Net.BCrypt.HashPassword("password3") }
                };
            _context.Users.AddRange(users);
            _context.SaveChanges();

            // Seed Rooms
            var rooms = new[]
            {
                    new Room { RoomName = "General" },
                    new Room { RoomName = "Random" }
                };
            _context.Rooms.AddRange(rooms);
            _context.SaveChanges();

            // Seed Messages
            var messages = new[]
            {
                    new Message { Content = "Hello, world!", SentAt = DateTime.Now, UserId = users[0].Id, RoomId = rooms[0].Id },
                    new Message { Content = "Hi, Alice!", SentAt = DateTime.Now, UserId = users[1].Id, RoomId = rooms[0].Id }
                };
            _context.Messages.AddRange(messages);
            _context.SaveChanges();

            // Seed RoomUsers
            var roomUsers = new[]
            {
                    new RoomUser { UserId = users[0].Id, RoomId = rooms[0].Id, JoinedAt = DateTime.Now },
                    new RoomUser { UserId = users[1].Id, RoomId = rooms[0].Id, JoinedAt = DateTime.Now },
                    new RoomUser { UserId = users[2].Id, RoomId = rooms[1].Id, JoinedAt = DateTime.Now }
                };
            _context.RoomUsers.AddRange(roomUsers);
            _context.SaveChanges();
        }
    }
}