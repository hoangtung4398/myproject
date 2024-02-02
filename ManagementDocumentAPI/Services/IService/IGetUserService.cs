using BaseCourse.Models;

namespace ManagementDocumentAPI.Services.IService
{
    public interface IGetUserService
    {
        User GetUser();
        void SetUser(int userId);
    }
}
