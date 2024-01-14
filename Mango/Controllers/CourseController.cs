using BaseCourse.Dto;
using BaseCourse.Models;
using CourseAPI.Services.IService;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ILectureStorageService _lectureStorageService;

        public CourseController(ICourseService courseService, ILectureStorageService lectureStorageService)
        {
            _courseService = courseService;
            _lectureStorageService = lectureStorageService;
        }



        // GET: Course
        public async Task <ActionResult> Index()
        {
            var response = await _courseService.GetlistCourse();
            var listCourse = new List<ListCourseDto>();
			if (response != null && response.Success)
			{
				 listCourse =JsonConvert.DeserializeObject<List<ListCourseDto>>(Convert.ToString(response.Result));
			}
			return View(listCourse);
        }

        // GET: Course/Details/5
        public ActionResult Sections(int id)
        {
            return RedirectToAction("Index", "Section", new {id});
        }

        // GET: Course/Create
        public async Task<ActionResult> Create()
        {
            var response = await _courseService.GetCategoryCourse();
            var listCategory = new List<CategoryCourse>();
            if (response != null && response.Success)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryCourse>>(Convert.ToString(response.Result));
            }
            ViewBag.LisCate = listCategory;
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]InsertCourseDto insertCourseDto)
         {
            try
            {
                var responseUpload = await _lectureStorageService.UploadLectureAsync(insertCourseDto.File, (int)SD.TypeUpload.Image);
                if (responseUpload.Success == false)
                {
                    return View();
                }
                var urlAzure = (ResultUpload)responseUpload.Result;
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
