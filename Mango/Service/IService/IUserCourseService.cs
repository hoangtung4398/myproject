
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IUserCourseService
    {
        Task<ResponseDto> ViewCourseDetail(int id);
        Task<ResponseDto> EnrollInCourse(int courseId);
        Task<ResponseDto> WatchCourse(int id);
    }
}
