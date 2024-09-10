using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IRoomService
    {
        public Task<Room> Create(Room room);
        public Task<bool> AddUserToRoom(Guid roomId, int userId);
    }
}