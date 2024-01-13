using BaseCourse.Models;
using BaseCourse.Repository;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class UserCourseRepository : Repository<UserCourse>, IUserCourseRepository
    {
        private readonly CourseContext _db;

        public UserCourseRepository(CourseContext dbcontext) : base(dbcontext)
        {
            _db = dbcontext;
        }
    }
}
