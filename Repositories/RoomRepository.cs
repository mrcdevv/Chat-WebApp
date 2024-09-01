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
    public class RoomRepository : IRoomRepository
    {
        private readonly ChatContext _context;

        public RoomRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> GetRoomAsync(Guid roomId)
        {
            return await _context.Rooms.FindAsync(roomId);
        }

        public async Task<bool> AddUserToRoom(Guid roomId, int userId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            var user = await _context.Users.FindAsync(userId);

            if (room != null && user != null)
            {
                room.RoomUsers.Add(new RoomUser { RoomId = roomId, UserId = userId, JoinedAt = DateTime.UtcNow });

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<RoomUser?> GetUserAsync(Guid roomId, int userId)
        {
            return await _context.RoomUsers.FindAsync(roomId, userId);
        }
    }
}