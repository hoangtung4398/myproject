using AuthAPI.Models;

namespace AuthAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<string> Register (RegisterationRequest request);
        Task<LoginResponse> Login (LoginRequest request);
        Task<bool> AssignRole(string email,string roleName);
    }
}
