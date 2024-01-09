using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private readonly MangoAuthContext _dbcontext;

        public SectionRepository(MangoAuthContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
