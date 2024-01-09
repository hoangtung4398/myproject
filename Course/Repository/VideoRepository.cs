using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        private readonly MangoAuthContext _db;

        public VideoRepository(MangoAuthContext dbcontext) : base(dbcontext)
        {
        }
    }
}
