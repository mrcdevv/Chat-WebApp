using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using ChatWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repo)
        {
            _repository = repo;
        }

        // TODO: Aplicar correctamente el patron repository. O buscar la manera de implementar las operaciones generales con un generic y que todas la hereden

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRoomDto roomDto)
        {
            var room = new Room { RoomName = roomDto.roomName };
            return await _repository.CreateRoomAsync(room);
        }
    }
}