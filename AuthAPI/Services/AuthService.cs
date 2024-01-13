using AuthAPI.Models;
using AuthAPI.Repositorys.IRepository;
using AuthAPI.Services.IServices;
using BaseCourse.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IRoleRepository _roleRepository;

		public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IRoleRepository roleRepository)
		{
			_userRepository = userRepository;
			_jwtTokenGenerator = jwtTokenGenerator;
			_roleRepository = roleRepository;
		}

		public async Task<bool> AssignRole(string email, string roleName)
		{
			var user = _userRepository.Get(u => u.Email == email).FirstOrDefault();
			if (user != null)
			{
				if (user.Roles.Any(x => x.Name == roleName))
				{
					return false;
				}
				var role = _roleRepository.Get(x=>x.Name == roleName).FirstOrDefault();
				if (role != null)
				{
					return false;
				}
				user.Roles.Add(role);
				return true;
			}
			return false;




		}

		public async Task<LoginResponse> Login(LoginRequest request)
		{

			var user = _userRepository.Get(x=>x.Email == request.Email && x.Password == request.Password).FirstOrDefault();

			if (user == null )
			{
				return new LoginResponse() { User = null, Token = "" };
			}

			var token = _jwtTokenGenerator.GenerateToken(user, user.Roles.Select(x=>x.Name).ToList());
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
