using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService ;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequest loginRequest = new LoginRequest();
            return View(loginRequest);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem(){Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem(){Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };
            ViewBag.Roles = roleList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequest registerationRequest)
        {
            ResponseDto response = await _authService.RegisterAsync(registerationRequest);
            ResponseDto assingRole;
            if (response != null && response.Success)
            {

            }
            return View();
        }
    }
}
