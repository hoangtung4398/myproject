using AuthAPI.Repositorys.IRepository;
using BaseCourse.Models;
using BaseCourse.Repository;

namespace AuthAPI.Repositorys
{
	public class UserRepository : Repository<User>, IUserRepository 
	{
		private readonly CourseContext _courseContext;
		public UserRepository(CourseContext dbcontext) : base(dbcontext)
		{
			_courseContext = dbcontext;
		}
	}
}
