using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            LoginRequest loginRequest = new();
            return View(loginRequest);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            
            return View();
        }
        public async Task<IActionResult> Logout()
        {

            return View();
        }
    }
}
