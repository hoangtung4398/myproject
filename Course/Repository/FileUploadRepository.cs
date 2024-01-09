using CouponAPI.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class FileUploadRepository : Repository<FileUpload>, IFileUploadRepository
    {
        private readonly MangoAuthContext _db;

        public FileUploadRepository(MangoAuthContext dbcontext) : base(dbcontext)
        {
        }

    }
}
