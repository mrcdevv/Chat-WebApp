using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService roomService)
        {
            _service = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> Room([FromBody] CreateRoomDto roomDto)
        {
            if (roomDto == null || !ModelState.IsValid)
            {
                return BadRequest(new { Error = "Error! Se debe enviar un body completo" });
            }

            var room = new Room { RoomName = roomDto.RoomName };

            await _service.Create(room);

            return Ok(room);
        }



    }
}