using BaseCourse.Models;
using BaseCourse.Repository;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly CourseContext _dbcontext;
        public CourseRepository(CourseContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
