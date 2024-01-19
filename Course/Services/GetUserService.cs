using AuthAPI.Repositorys.IRepository;
using BaseCourse.Models;
using CourseAPI.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace CourseAPI.Services
{
	public class GetUserService : IGetUserService
	{
		public User User { get; set; }
		private readonly IUserRepository _userRepository;

		public GetUserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
            User = new User();

        }

		public void SetUser(int userId)
		{
			var user =  _userRepository.Get(x => x.Id == userId).Include(x=>x.Roles).FirstOrDefault();
			User = user;
		}
		public User GetUser()
		{
            return User;
        }
	}
}
