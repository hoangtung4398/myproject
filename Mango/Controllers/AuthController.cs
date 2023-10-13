using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;
        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequest loginRequest = new();
            return View(loginRequest);
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            ResponseDto responseDTO;
            responseDTO = await _authService.LoginAsync(loginRequest);
            if (responseDTO != null && responseDTO.Success)
            {
                LoginResponse? loginResponse = JsonConvert.DeserializeObject<LoginResponse>(Convert.ToString(responseDTO.Result));
                await SignInUser(loginResponse);
                _tokenProvider.SetToken(loginResponse.Token);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", responseDTO.Message);
                return View(loginRequest);
            }
        }
        private async Task SignInUser(LoginResponse loginResponse)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(loginResponse.Token);
            var idenity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            idenity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, jsonToken.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            idenity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, jsonToken.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            idenity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, jsonToken.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
            idenity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, jsonToken.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));


            var principal = new ClaimsPrincipal(new[] { idenity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

    }
}
