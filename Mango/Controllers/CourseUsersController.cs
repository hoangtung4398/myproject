using BaseCourse.Dto;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CourseUsersController : Controller
    {
        private readonly IUserCourseService _userCourseService;

        public CourseUsersController(IUserCourseService userCourseService)
        {
            _userCourseService = userCourseService;
        }

        public async Task<IActionResult> CourseDetail(int id)
        {
            var response = await _userCourseService.ViewCourseDetail(id);
            var courseDetail = new CourseDetailDto();
            if (response != null && response.Success)
            {
                courseDetail = JsonConvert.DeserializeObject<CourseDetailDto>(Convert.ToString(response.Result));
            }
            return View(courseDetail);
        }
    }
}
