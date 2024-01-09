using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class UserCourseRepository : Repository<UserCourse>, IUserCourseRepository
    {
        private readonly MangoAuthContext _db;

        public UserCourseRepository(MangoAuthContext dbcontext) : base(dbcontext)
        {
            _db = dbcontext;
        }
    }
}
