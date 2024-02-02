using BaseCourse.Models;
using BaseCourse.Repository;
using ManagementDocumentAPI.Repository.IRepository;

namespace ManagementDocumentAPI.Repository
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly CourseContext _dbcontext;
        public DocumentRepository(CourseContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
