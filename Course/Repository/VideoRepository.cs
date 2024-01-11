using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        private readonly CourseContext _db;

        public VideoRepository(CourseContext dbcontext) : base(dbcontext)
        {
        }
    }
}
