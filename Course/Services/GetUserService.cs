using AuthAPI.Repositorys.IRepository;
using BaseCourse.Models;
using CourseAPI.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace CourseAPI.Services
{
	public class GetUserService : IGetUserService
	{
		private readonly IUserRepository _userRepository;

		public GetUserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User GetUser(int userId)
		{
			var user =  _userRepository.Get(x => x.Id == userId).Include(x=>x.Roles).FirstOrDefault();
			return user;
		}
	}
}
