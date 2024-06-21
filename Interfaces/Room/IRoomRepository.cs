using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Models;

namespace ChatWebApp.Interfaces
{
    public interface IRoomRepository
    {
        public Task<Guid> CreateRoomAsync(Room room);
    }
}