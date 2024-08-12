using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }



        [HttpGet("{userId}")]
        public IActionResult User(int userId)
        {
            if (userId < 0)
            {
                return BadRequest(new { Error = "Error! Id invalida" });
            }

            // Lógica para obtener el perfil de un usuario
            var userInfo =

            return Ok();
        }

        [HttpPatch("{userId}")]
        public IActionResult User([FromBody] string userData, int userId)
        {
            // Lógica para actualizar el perfil de usuario
            return Ok();
        }
    }
}