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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>()
                .HasKey(x => x.Id);

            builder.Entity<Room>()
                .Property(x => x.RoomName)
                    .HasMaxLength(255)
                    .IsRequired();

            builder.Entity<Message>()
                .HasKey(x => x.Id);

            builder.Entity<Message>()
                .Property(x => x.SentAt).HasDefaultValueSql("getdate()");


            builder.Entity<RoomUser>()
                .HasKey(x => new { x.UserId, x.RoomId });

        }
    }
}