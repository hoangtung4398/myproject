using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class FileUploadRepository : Repository<FileUpload>, IFileUploadRepository
    {
        private readonly CourseContext _db;

        public FileUploadRepository(CourseContext dbcontext) : base(dbcontext)
        {
        }

    }
}
