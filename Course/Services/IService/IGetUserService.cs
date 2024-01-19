using BaseCourse.Models;

namespace CourseAPI.Services.IService
{
    public interface IGetUserService
    {
        User GetUser();
        void SetUser(int userId);
    }
}
