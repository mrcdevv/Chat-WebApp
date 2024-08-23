using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatWebApp.DTOs;
using ChatWebApp.DTOs.User.Request;
using ChatWebApp.Interfaces;
using ChatWebApp.Models;
using ChatWebApp.Utility;

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
                    throw new Exceptions.UserNotFoundException("Usuario no encontrado");
                }

                return new UserInfoDto(user.Id, user.UserName, user.Email);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserInfoDto> UpdateUserAsync(UserUpdateDto body, int id)
        {
            try
            {
                var user = await _repository.FindUserAsync(id);

                if (user == null)
                {
                    throw new Exceptions.UserNotFoundException("Usuario no encontrado");
                }

                var newDataUser = _mapper.Map<User>(body);
                user = await _repository.FindUserAsync(id);

                return _mapper.Map<UserInfoDto>(user);

            }
            catch (Exceptions.UserNotFoundException ex)
            {
                throw new Exceptions.UserNotFoundException("Error con el usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}