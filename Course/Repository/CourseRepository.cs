using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class CourseRepository : Repository<Models.Course>, ICourseRepository
    {
        private readonly CourseContext _dbcontext;
        public CourseRepository(CourseContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
