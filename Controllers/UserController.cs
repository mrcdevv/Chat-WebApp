using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs.User.Request;
using ChatWebApp.Services;
using ChatWebApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService userService)
        {
            _service = userService;
        }



        [HttpGet("{userId}")]
        public async Task<IActionResult> Users(int userId)
        {
            if (userId < 0)
            {
                return BadRequest(new { Error = "Error! Id invalida" });
            }

            var userInfo = await _service.GetUserAsync(userId);

            return Ok(userInfo);
        }

        [HttpPatch("{userId}")]
        public async Task<IActionResult> Users([FromBody] UserUpdateDto body, int userId)
        {
            if (string.IsNullOrWhiteSpace(body.UserName) && string.IsNullOrWhiteSpace(body.UserEmail))
            {
                return BadRequest(new { Error = "Error! No se mando nada para actualizar" });
            }

            try
            {
                var user = await _service.UpdateUserAsync(body, userId);

                return Ok(user);
            }
            catch (Exceptions.UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Se produjo un error intentado actualizar", Detalles = ex.Message });
            }
        }
    }
}