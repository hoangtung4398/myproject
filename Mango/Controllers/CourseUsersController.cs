using BaseCourse.Dto;
using BaseCourse.Models;
using Mango.Web.Service;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CourseUsersController : Controller
    {
        private readonly IUserCourseService _userCourseService;
        private readonly ICourseService _courseService;

        public CourseUsersController(IUserCourseService userCourseService, ICourseService courseService)
        {
            _userCourseService = userCourseService;
            _courseService = courseService;
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
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Enroll(int courseId)
        {
            var response = await _userCourseService.EnrollInCourse(courseId);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(CourseDetail), new { id = courseId });
            }

            return View();
        }
        [Authorize]
        public async Task<IActionResult> WatchCourse(int id)
        {
            var response = await _userCourseService.WatchCourse(id);
            var courseDetail = new CourseDetailDto();
            if (response != null && response.Success)
            {
                courseDetail = JsonConvert.DeserializeObject<CourseDetailDto>(Convert.ToString(response.Result));
            }
            return View(courseDetail);
        }

        public IActionResult SearchList(int id)
        {
            return View();
        }
        public async Task<IActionResult> MyLearning()
        {
            var response = await _userCourseService.MyLearning();
            var courseLearnDto = new List<CourseLearnDto>();
            if (response != null && response.Success)
            {
                courseLearnDto = JsonConvert.DeserializeObject<List<CourseLearnDto>>(Convert.ToString(response.Result));
            }
            return View(courseLearnDto);
        }

        public async Task<IActionResult> RemoveCourse(int id)
        {
            var response = await _userCourseService.RemoveCourse(id);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(MyLearning));
            }
            return View();
        }
        public async Task<IActionResult> CourseSearch(int categoryId, string name)
        {
            var response = await _courseService.GetCategoryCourse();
            var listCategory = new List<CategoryCourse>();
            if (response != null && response.Success)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryCourse>>(Convert.ToString(response.Result));
            }
            ViewBag.LisCate = listCategory;
            var responseCourse = await _userCourseService.GetListCourse(categoryId, name);
            var listCourse = new List<SearchListDto>();
            if (responseCourse != null && responseCourse.Success)
            {
                listCourse = JsonConvert.DeserializeObject<List<SearchListDto>>(Convert.ToString(responseCourse.Result));
            }
            
            return View(listCourse);
        }
    }
}
