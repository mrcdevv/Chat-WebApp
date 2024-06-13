using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChatWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            if (!await _service.UserExistAsync(userDto.UserName))
            {
                return NotFound("User doesn't exist!");
            }

            var credentials = await _service.CheckCredentials(userDto);

            if (!credentials)
            {
                return BadRequest("Username or password wrong!");
            }

            var user = new User { UserName = userDto.UserName };
            var token = _service.CreateToken(user);

            return Ok(token);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<string>> SignUp([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            if (await _service.UserExistAsync(userDto.UserName))
            {
                return Conflict("Username already exist!");
            }

            var newUser = await _service.CreateUserAsync(userDto);

            if (newUser)
            {
                return NoContent();
            }

            return BadRequest("An error ocurred while creating the user");
        }
    }
}