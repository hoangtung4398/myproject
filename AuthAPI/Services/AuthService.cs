﻿using AuthAPI.Models;
using AuthAPI.Repositorys.IRepository;
using AuthAPI.Services.IServices;
using BaseCourse.Dto;
using BaseCourse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRoleRepository _roleRepository;
        private readonly CourseContext _context;

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IRoleRepository roleRepository, CourseContext context)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleRepository = roleRepository;
            _context = context;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _userRepository.Get(u => u.Email == email).Include(x=>x.Roles).FirstOrDefault();
            var role = _roleRepository.Get(x => x.Name == roleName).FirstOrDefault();
            if (user != null)
            {
                if (user.Roles.Any(x=>x.Name == roleName))
                {
                    return false;
                }
                
                if (role == null)
                {
                    return false;
                }
                user.Roles.Add(role);
                _context.SaveChanges();
                return true;
            }
            return false;




        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {

            var user = 
                _userRepository.Get(x => x.Email == request.Email && x.Password == request.Password).Include(x=>x.Roles).FirstOrDefault();
            if (user == null)
            {
                return new LoginResponse() { User = null, Token = "" };
            }
            var user1 = _context.Users.Include(x=>x.Roles).Where(u => u.Email == request.Email).FirstOrDefault();
            var role = user.Roles.FirstOrDefault()?.Name;
            var token = _jwtTokenGenerator.GenerateToken(user, role);
            UserDTO UserDTO = new UserDTO()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.FullName,
            };

            return new LoginResponse() { User = UserDTO, Token = token };
        }

        public async Task<string> Register(RegisterationRequest request)
        {
            User user = new()
            {
                UserName = request.Name,
                Email = request.Email,
                Password = request.Password
            };
            try
            {
                var id = _userRepository.Add(user);
                if (id != 0)
                {
                    var result = _userRepository.Get(u => u.Email == request.Email).FirstOrDefault();
                    UserDTO info = new UserDTO()
                    {
                        Email = result.Email,
                        Id = result.Id,
                        Name = result.UserName,
                    };
                    return "";
                }
                else
                {
                    return "Register failed";
                }
            }
            catch (Exception ex)
            {

            }
            return "Error Encouter";
        }
    }
}
