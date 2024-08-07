using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{userId}")]
        public IActionResult User(int userId)
        {
            // Lógica para obtener el perfil de un usuario
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