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

        public async Task<Guid> CreateRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            return room.Id;
        }
    }
}