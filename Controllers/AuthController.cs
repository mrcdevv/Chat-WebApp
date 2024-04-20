using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        public async Task Login([FromBody] User user)
        {

        }

        [HttpPost]
        public async ActionResult<string> SignUp([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // check if exist in db
            var alreadyExist = _service.IsRegistered(user.Id);

            if (!alreadyExist)
            {
                var created = _service.SignUp(user);

                if (created)
                {
                    // logearlo

                    var token = _service.GetToken(user);

                    return Ok(token);
                }

                return BadRequest("An error ocurred while creating the user");

            }
            else
            {
                return BadRequest("Username already exist!"); // buscar uno mejor a un bad request 
            }





        }
    }
}