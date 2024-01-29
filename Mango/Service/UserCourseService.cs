using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IBaseService _baseService;

        public UserCourseService(IBaseService baseService)
        {
            _baseService = baseService;
        }

		public Task<ResponseDto> EnrollInCourse(int courseId)
		{
			return _baseService.SendAsync(new Requestmsg()
            {
				ApiType = SD.ApiType.POST,
				Data = courseId,
				Url = $"{SD.CourseAPIbase}/api/UserCourse/EnrollCourse"
			});
		}

		public async Task<ResponseDto> ViewCourseDetail(int id)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CourseAPIbase}/api/UserCourse/ViewCourseDetail/{id}"
            });
        }

        public async Task<ResponseDto> WatchCourse(int id)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CourseAPIbase}/api/UserCourse/WatchCourse/{id}"
            });
        }
    }
}
