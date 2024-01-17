using BaseCourse.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        public IBaseService _BaseService;
        public AuthService(IBaseService baseService)
        {
            _BaseService = baseService;
        }
        public async Task<ResponseDto> AssignRole(RegisterationRequest registerationRequest)
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.POST,
                Data = registerationRequest,
                Url = SD.AuthAPIbase + "/AssginRole"

            });
        }

        public async Task<ResponseDto> LoginAsync(LoginRequest loginRequest)
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequest,
                Url = SD.AuthAPIbase + "/Login"

            });
        }

        public async Task<ResponseDto> RegisterAsync(RegisterationRequest registerationRequest)
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = registerationRequest,
                Url = SD.AuthAPIbase + "/Register"

            });
        }
    }
}
