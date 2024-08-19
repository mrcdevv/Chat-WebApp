using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatWebApp.DTOs;
using ChatWebApp.DTOs.User.Request;
using ChatWebApp.Interfaces;
using ChatWebApp.Interfaces;

namespace ChatWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public async Task<UserInfoDto> UpdateUserAsync(UserUpdateDto newData, int id)
        {
            try
            {
                var user = await _repository.FindUserAsync(id);

                if (user == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                //TODO: terminar el metodo en el repo y aca la implementacion



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}