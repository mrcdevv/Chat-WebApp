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

        public async Task<Room> Create(Room room)
        {
            return await _repository.CreateRoomAsync(room);
        }

        public async Task AddUserToRoom(Guid roomId, int userId)
        {

        }
    }
}