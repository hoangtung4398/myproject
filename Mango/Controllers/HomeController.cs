using BaseCourse.Dto;
using BaseCourse.Models;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mango.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserCourseService _userCourseService;
        private readonly ICourseService _courseService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserCourseService userCourseService, ICourseService courseService)
        {
            _logger = logger;
            _userCourseService = userCourseService;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _courseService.GetCategoryCourse();
            var listCategory = new List<CategoryCourse>();
            if (response != null && response.Success)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryCourse>>(Convert.ToString(response.Result));
            }
            ViewBag.LisCate = listCategory;
            Dictionary<int, List<SearchListDto>> dicCateCourses = new Dictionary<int, List<SearchListDto>>();
            foreach (var item in listCategory)
            {
                var responseCourse = await _userCourseService.GetListCourse(item.Id, "");
                if (responseCourse != null && responseCourse.Success)
                {
                    var listCourse = JsonConvert.DeserializeObject<List<SearchListDto>>(Convert.ToString(responseCourse.Result));
                    dicCateCourses.Add(item.Id, listCourse);
                }
            }
            var popularCourse = new List<SearchListDto>();
            foreach (var item in dicCateCourses.Values)
            {
                popularCourse.AddRange(item);
            }
            popularCourse  = popularCourse.OrderBy(p=>p.EnrollmentsCount).Take(6).ToList();
            ViewBag.popularCourse = popularCourse;
            ViewBag.dicCateCourses = dicCateCourses;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}