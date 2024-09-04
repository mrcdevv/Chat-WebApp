using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using ChatWebApp.Repositories;
using ChatWebApp.Utility;
using Microsoft.AspNetCore.Mvc;
using static ChatWebApp.Utility.Exceptions;

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

        public async Task<bool> AddUserToRoom(Guid roomId, int userId)
        {
            if (await _repository.GetUserAsync(roomId, userId) != null)
                throw new UserAlreadyExistException("El usuario ya existe en esta sala.");

            return await _repository.AddUserToRoom(roomId, userId);
        }
    }
}