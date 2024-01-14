using BaseCourse.Models;
using BaseCourse.Repository;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class CategoryCourseRepository : Repository<CategoryCourse>, ICategoryCourseRepository
    {
        private readonly CourseContext _dbcontext;
        public CategoryCourseRepository(CourseContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
