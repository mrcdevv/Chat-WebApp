using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _service = roomService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Room([FromBody] CreateRoomDto roomDto)
        {
            if (roomDto == null || !ModelState.IsValid)
            {
                return BadRequest(new { Error = "Error! Se debe enviar un body completo" });
            }

            try
            {
                var room = _mapper.Map<Room>(roomDto);

                await _service.Create(room);

                return Ok(room);
            }
            catch (Exception)
            {
                return new Microsoft.AspNetCore.Mvc.StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
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

            return BadRequest(new { Error = "Se produjo un error desconocido" });
        }
    }
}