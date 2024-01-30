﻿using BaseCourse.Dto;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
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
    }
}
