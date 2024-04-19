using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration config)
        {
            _configuration = config;
        }


        [HttpPost]
        public async Task Login([FromBody] User user)
        {

        }

        [HttpPost]
        public ActionResult<string> SignUp([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // check if exist in db



        }
    }
}