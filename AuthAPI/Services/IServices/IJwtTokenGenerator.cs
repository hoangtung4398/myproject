using AuthAPI.Models;
using BaseCourse.Models;

namespace AuthAPI.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user,string roles);
    }
}
