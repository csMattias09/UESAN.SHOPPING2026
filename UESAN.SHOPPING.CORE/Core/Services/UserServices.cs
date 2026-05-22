using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Repositories;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class UserServices : IUserServices
    {
        public readonly IUserRepository _userRepository;
        private readonly IJWTService _jWTService;

        public UserServices(IUserRepository userRepository, IJWTService jWTService)
        {
            _userRepository = userRepository;
            _jWTService = jWTService;
        }


        public async Task<UserDTO> SignIn(string email, string password)
        {
            var user = await _userRepository.SignIn(email, password);
            var token = _jWTService.GenerateJWToken(user);

            if (user == null) return null;
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token



            };
        }
        public async Task<int> SignUp(UserCreateDTO userCreateDTO)
        {
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                DateOfBirth = userCreateDTO.DateOfBirth,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password,
                Country = userCreateDTO.Country,
                Address = userCreateDTO.Address,
                Type = userCreateDTO.Type,
                IsActive = true

            };
            return await _userRepository.SignUp(user);

        }

    }

}

