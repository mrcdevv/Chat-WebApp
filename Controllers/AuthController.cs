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
        public async Task<IActionResult> Login([FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var userExist = await _service.GetUserAsync(user.UserName);

            if (userExist == null)
            {
                return NotFound("User doesn't exist!");
            }

            var credentials = await _service.CheckCredentials(user);

            if (!credentials)
            {
                return BadRequest("Username or password wrong!");
            }

            return Ok(_service.CreateToken(userExist));
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<string>> SignUp([FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var userAlreadyExist = await _service.GetUserAsync(user.UserName);

            if (userAlreadyExist == null)
            {
                var userCreated = await _service.CreateUserAsync(user);

                if (userCreated)
                {
                    var token = _service.CreateToken(user);

                    return Ok(token);
                }

                return BadRequest("An error ocurred while creating the user");

            }

            return Conflict("Username already exist!");
        }
    }
}