using Azure.Core;
using CourseAPI.Services.IService;
using System.IdentityModel.Tokens.Jwt;

namespace UserCourseAPI.Middleware
{
    public class GetTokenMiddleware2 : IMiddleware
    {
        private readonly IGetUserService _getUserService;

        public GetTokenMiddleware2(IGetUserService getUserService)
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
                await next(context);
            }
            else
            {
                await next(context);
            }
        }
    }
}
