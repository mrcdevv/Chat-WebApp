using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Room([FromBody] CreateRoomDto roomDto)
        {
            if (roomDto == null || !ModelState.IsValid)
            {
                return BadRequest(new { Error = "Error! Se debe enviar un body completo" });
            }

            var room = new Room { RoomName = roomDto.RoomName };

            await _repository.CreateRoomAsync(room);

            return Ok(room);


        }


    }
}