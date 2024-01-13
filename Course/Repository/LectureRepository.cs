using BaseCourse.Models;
using BaseCourse.Repository;
using CourseAPI.Models;
using CourseAPI.Repository.IRepository;

namespace CourseAPI.Repository
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        private readonly CourseContext _db;

        public LectureRepository(CourseContext dbcontext) : base(dbcontext)
        {
        }
    }
}
