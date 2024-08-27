using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;

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
                room.RoomUsers.Add(user);
            }

        }
    }
}