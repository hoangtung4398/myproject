using AuthAPI.Repositorys.IRepository;
using BaseCourse.Models;
using BaseCourse.Repository;

namespace AuthAPI.Repositorys
{
	public class RoleRepository : Repository<Role>, IRoleRepository
	{
		private readonly CourseContext _courseContext;
		public RoleRepository(CourseContext dbcontext) : base(dbcontext)
		{
			_courseContext = dbcontext;
		}
	}
}
