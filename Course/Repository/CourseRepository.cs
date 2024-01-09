using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class CourseRepository : Repository<Models.Course>, ICourseRepository
    {
        private readonly MangoAuthContext _dbcontext;
        public CourseRepository(MangoAuthContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
