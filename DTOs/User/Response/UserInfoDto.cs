using System.ComponentModel.DataAnnotations;

namespace ChatWebApp.DTOs
{
  public record UserInfoDto(int UserId, string UserName, string? UserEmail);
}