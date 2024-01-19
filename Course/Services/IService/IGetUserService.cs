using BaseCourse.Models;

namespace CourseAPI.Services.IService
{
    public interface IGetUserService
    {
        User GetUser(int userId);
    }
}
