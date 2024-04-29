using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatWebApp.Context
{
    public class ChatContext : DbContext
    {

        public ChatContext()
        {
        }

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomUser> RoomUsers { get; set; }
    }
}