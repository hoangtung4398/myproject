using AuthAPI.Models;

namespace AuthAPI.Services.IServices
{
    public interface IJwtTokenGenerator 
    {
        string GenerateToken(ApplicationUser user);
    }
}
