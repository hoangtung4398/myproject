using CourseAPI.Services.IService;

namespace CourseAPI.Middleware
{
    public class GetTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public GetTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IGetUserService GetUserService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = 1;
        }
    }
}
