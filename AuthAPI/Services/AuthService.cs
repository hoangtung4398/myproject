﻿using AuthAPI.Models;
using AuthAPI.Models.Data;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbcontext _db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> roleManager;
        public AuthService(AppDbcontext dbcontext, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = dbcontext;
            userManager = user;
            roleManager = role;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.users.FirstOrDefault(u => u.Email == email);
            if (user != null) {
                if(!roleManager.RoleExistsAsync(roleName).Result)
                {
                roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

            
            

        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {

            var user = _db.users.FirstOrDefault(u => u.UserName == request.Username);
            bool isVaild = await userManager.CheckPasswordAsync(user, request.Password);

            if (user == null || isVaild == false)
            {
                return new LoginResponse() { User = null, Token = "" };
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            UserInfo userInfo = new UserInfo()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.FullName,
                PhoneNumber = user.PhoneNumber
            };

            return new LoginResponse() { User = userInfo, Token = token };
        }

        public async Task<string> Register(RegisterationRequest request)
        {
            ApplicationUser user = new()
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.Name,
                PhoneNumber = request.PhoneNumber
            };
            try
            {
                var Register = await userManager.CreateAsync(user, request.Password);
                if (Register.Succeeded)
                {
                    var result = _db.users.First(u => u.UserName == request.Email);
                    UserInfo info = new UserInfo()
                    {
                        Email = result.Email,
                        Id = result.Id,
                        Name = result.UserName,
                        PhoneNumber = result.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return Register.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

            }
            return "Error Encouter";
        }
    }
}
