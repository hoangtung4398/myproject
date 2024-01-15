using BaseCourse.Dto;
using BaseCourse.Models;
using CourseAPI.Services.IService;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
	public class CourseService : ICourseService
	{
		private readonly IBaseService _baseService;

        public CourseService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto> GetlistCourse()
		{
			return await _baseService.SendAsync(new Requestmsg()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CourseAPIbase + "/api/Course/GetCourseUser"
			});
		}

		public async Task<ResponseDto> GetListLecture(int id)
		{
			return await _baseService.SendAsync(new Requestmsg()
			{
				ApiType = SD.ApiType.GET,
				Url = $"{SD.CourseAPIbase}/api/Course/GetListLectures/{id}"
			});
		}

		public async Task<ResponseDto> GetListSection(int id)
		{
			return await _baseService.SendAsync(new Requestmsg()
			{
				ApiType = SD.ApiType.GET,
				Url = $"{SD.CourseAPIbase}/api/Course/GetListSection/{id}"
			});
		}
		public async Task<ResponseDto> CreateLecture(Lecture insertLectureDto)
		{
			return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.POST,
				Data = insertLectureDto,
                Url = $"{SD.CourseAPIbase}/api/Course/CreatLecture"
            });
        }

        public async Task<ResponseDto> GetDetailLecture(int id)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CourseAPIbase}/api/Course/DetailLecture/{id}"
            });
        }
        public async Task<ResponseDto> GetCategoryCourse()
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CourseAPIbase + "/api/Course/GetCategory"
            });
        }

        public async Task<ResponseDto> CreateCourse(RequestCourseDto course)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.POST,
                Data = course,
                Url = $"{SD.CourseAPIbase}/api/Course/CreateCourse"
            });
        }

        public async Task<ResponseDto> UpdateCourse(RequestCourseDto course)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.PUT,
                Data = course,
                Url = $"{SD.CourseAPIbase}/api/Course/UpdateCourse"
            });
        }

        public async Task<ResponseDto> GetCourseById(int id)
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CourseAPIbase}/api/Course/GetCourseById/{id}"
            });
        }
    }
}
