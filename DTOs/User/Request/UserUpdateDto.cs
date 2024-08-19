using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.DTOs.User.Request
{
    public record UserUpdateDto(string? UserName, string? UserEmail);
}