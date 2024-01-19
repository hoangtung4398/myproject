using Mango.Controllers;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BaseCourse.Dto;

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
		[HttpPost]
		public async Task<IActionResult> Login(LoginRequest loginRequest)
		{
			if (ModelState.IsValid)
			{
				ResponseDto response = _authService.LoginAsync(loginRequest).Result;
				if (response != null && response.Success)
				{
					LoginResponse loginResponseDto =
					JsonConvert.DeserializeObject<LoginResponse>(Convert.ToString(response.Result));
					await SignInUser(loginResponseDto);
					_tokenProvider.SetToken(loginResponseDto.Token);
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
			}
			return View(loginRequest);
		}
		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterationRequest registerationRequest)
		{
			ResponseDto response = await _authService.RegisterAsync(registerationRequest);
			if (response != null && response.Success)
			{
				LoginRequest loginRequestDto =
					JsonConvert.DeserializeObject<LoginRequest>(Convert.ToString(response.Result));
				RedirectToAction(nameof(Login));
			}
			return View();
		}
		private async Task SignInUser(LoginResponse model)
		{
			var handler = new JwtSecurityTokenHandler();

			var jwt = handler.ReadJwtToken(model.Token);

			var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
			identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
			identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
			identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
				jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));
			identity.AddClaim(new Claim("role",
				jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));



			var principal = new ClaimsPrincipal(identity);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			_tokenProvider.ClearToken();
			return RedirectToAction("Index","Home");
		}
	}
}
