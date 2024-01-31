
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IUserCourseService
    {
        Task<ResponseDto> ViewCourseDetail(int id);
        Task<ResponseDto> EnrollInCourse(int courseId);
        Task<ResponseDto> WatchCourse(int id);
        Task<ResponseDto> MyLearning();
        Task<ResponseDto> RemoveCourse(int id);
        Task<ResponseDto> GetListCourse(int categoryId,string name);
    }
}
