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
				Url = $"{SD.UserCourseAPIbase}/api/UserCourse/EnrollCourse"
			});
		}

		public async Task<ResponseDto> ViewCourseDetail(int id)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.UserCourseAPIbase}/api/UserCourse/ViewCourseDetail/{id}"
            });
        }

        public async Task<ResponseDto> WatchCourse(int id)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.UserCourseAPIbase}/api/UserCourse/WatchCourse/{id}"
            });
        }
        public async Task<ResponseDto> MyLearning()
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.UserCourseAPIbase}/api/UserCourse/MyLearning"
            });
        }

        public Task<ResponseDto> RemoveCourse(int id)
        {
            return _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = $"{SD.UserCourseAPIbase}/api/UserCourse/RemoveCourse/{id}"
            });
        }

        public Task<ResponseDto> GetListCourse(int categoryId, string name)
        {
            return _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.UserCourseAPIbase}/api/UserCourse/SearchList?categoryId={categoryId}&name={name}"
            });
        }
    }
}
