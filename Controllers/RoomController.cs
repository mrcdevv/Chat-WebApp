using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using static ChatWebApp.Utility.Exceptions;

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

        [HttpPost("{roomId}/user/{userId}")]
        public async Task<IActionResult> JoinRoom(Guid roomId, int userId)
        {
            try
            {
                if (roomId == Guid.Empty)
                    return BadRequest(new { Error = "Se debe enviar una id de sala valida" });

                if (userId <= 0)
                    return BadRequest(new { Error = "Se debe enviar una id de usuario valida" });

                if (await _service.AddUserToRoom(roomId, userId))
                {
                    return NoContent();
                }
            }
            catch (UserAlreadyExistException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception)
            {
                return new Microsoft.AspNetCore.Mvc.StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
            return Ok();
        }



    }
}