using BaseCourse.Models;
using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private readonly CourseContext _dbcontext;

        public SectionRepository(CourseContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
