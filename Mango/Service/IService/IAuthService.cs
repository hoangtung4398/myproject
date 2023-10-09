using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequest loginRequest);
        Task<ResponseDto> RegisterAsync(RegisterationRequest registerationRequest);
        Task<ResponseDto> AssignRole(RegisterationRequest registerationRequest);
    }
}
