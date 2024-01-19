using AuthAPI.Models;
using AuthAPI.Services.IServices;
using BaseCourse.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _AuthService;
        private ResponseDto _responseDto;
        public AuthController(IAuthService authService)
        {
            _AuthService = authService;
            _responseDto = new ResponseDto();
        }
        [HttpPost("/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequest request)
        {
            var result = await _AuthService.Register(request);
            Boolean assignRoleisSuccess = await _AuthService.AssignRole(request.Email, request.RoleName);
            if (!string.IsNullOrEmpty(result))
            {
                _responseDto.Success = false;
                _responseDto.Message = result;
                return BadRequest(_responseDto);
            }
            var loginRequest = new LoginRequest()
            {
                Email = request.Email,
                Password = request.Password,
            };
            return Ok(_responseDto);
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginResponse = await _AuthService.Login(request);
            if (loginResponse.User == null)
            {
                _responseDto.Success = false;
                _responseDto.Message = "User or password is incorrect";
                return BadRequest(_responseDto);
            }
            _responseDto.Result = loginResponse;
            return Ok(_responseDto);
        }
        [HttpPost]
        [Route("/AssginRole")]
        public async Task<IActionResult> AssginRole([FromBody] RegisterationRequest request)
        {
            var assignRoleisSuccess = await _AuthService.AssignRole(request.Email, request.RoleName.ToUpper());

            if (!assignRoleisSuccess)
            {
                _responseDto.Success = false;
                _responseDto.Message = "Error encountered";
                return BadRequest(_responseDto);
            }
            return Ok(_responseDto);
        }
    }
}

