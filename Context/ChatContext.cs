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
            builder.Entity<Room>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.RoomName)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.UserName)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(x => x.Password)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            builder.Entity<RoomUser>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.RoomId });

                entity.HasOne(x => x.User)
                    .WithMany(x => x.RoomUsers)
                    .HasForeignKey(x => x.UserId);

                entity.HasOne(x => x.Room)
                    .WithMany(x => x.RoomUsers)
                    .HasForeignKey(x => x.RoomId);
            });

            builder.Entity<Message>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.SentAt)
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(x => x.Room)
                    .WithMany(x => x.Messages)
                    .HasForeignKey(x => x.RoomId);

                entity.HasOne(x => x.User)
                    .WithMany(x => x.Messages)
                    .HasForeignKey(x => x.UserId);
            });
        }
    }
}