using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.DTOs;
using ChatWebApp.Interfaces;
using ChatWebApp.Interfaces;

namespace ChatWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserInfoDto> GetUserAsync(int id)
        {
            try
            {
                var user = await _repository.FindUserAsync(id);

                if (user == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                return new UserInfoDto(user.Id, user.UserName, user.Email);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}