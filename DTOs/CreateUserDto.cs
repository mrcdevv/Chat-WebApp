using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.DTOs
{
    public record CreateUserDto(string UserName, string Password)
    {
    }
}