using System.ComponentModel.DataAnnotations;

namespace ChatWebApp.DTOs
{
  public record UserInfoDto(int Id, string UserName, string Email);
}