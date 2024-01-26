using Azure.Core;
using CourseAPI.Services.IService;
using System.IdentityModel.Tokens.Jwt;

namespace CourseAPI.Middleware
{
    public class GetTokenMiddleware : IMiddleware
    {
        private readonly IGetUserService _getUserService;

        public GetTokenMiddleware(IGetUserService getUserService)
        {
            _getUserService = getUserService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = "";
            if (context.Request.Headers["Authorization"].FirstOrDefault() != null)
            {
                token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var readToken = new JwtSecurityTokenHandler();
                var tokenData = readToken.ReadJwtToken(token);
                var userId = tokenData.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value;
                _getUserService.SetUser(int.Parse(userId));
            }
            else
            {
                await next(context);
            }
        }
    }
}
