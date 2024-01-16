using Azure;
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
        public async Task<ActionResult> Index()
        {
            var response = await _courseService.GetlistCourse();
            var listCourse = new List<ListCourseDto>();
            if (response != null && response.Success)
            {
                listCourse = JsonConvert.DeserializeObject<List<ListCourseDto>>(Convert.ToString(response.Result));
            }
            return View(listCourse);
        }

        // GET: Course/Details/5
        public ActionResult Sections(int id)
        {
            return RedirectToAction("Index", "Section", new { id });
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
        public async Task<IActionResult> CreateAsync([FromForm] InsertCourseDto insertCourseDto)
        {
            try
            {
                var responseUpload = await _lectureStorageService.UploadLectureAsync(insertCourseDto.File, (int)SD.TypeUpload.Image);
                if (responseUpload.Success == false)
                {
                    return View();
                }
                var urlAzure = (ResultUpload)responseUpload.Result;
                var course = new RequestCourseDto
                {
                    Name = insertCourseDto.Name,
                    Description = insertCourseDto.Description,
                    Knowledge = insertCourseDto.Knowledge,
                    Requirments = insertCourseDto.Requirments,
                    ImageUrl = urlAzure.Url,
                    CategoryId = insertCourseDto.CategoryId,
                    Target = insertCourseDto.Target,
                };
                var respone = await _courseService.CreateCourse(course);
                if (respone.Success == true)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _courseService.GetCourseById(id);
            var course = new RequestCourseDto();
            if (response != null && response.Success)
            {
                course = JsonConvert.DeserializeObject<RequestCourseDto>(Convert.ToString(response.Result));
            }
            ViewBag.Course = course;
            var responseCate = await _courseService.GetCategoryCourse();
            var listCategory = new List<CategoryCourse>();
            if (responseCate != null && responseCate.Success)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryCourse>>(Convert.ToString(responseCate.Result));
            }
            ViewBag.LisCate = listCategory;
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([FromForm] InsertCourseDto insertCourseDto)
        {
            var urlAzure = new ResultUpload();
            if (insertCourseDto.File != null)
            {
                var responseUpload = await _lectureStorageService.UploadLectureAsync(insertCourseDto.File, (int)SD.TypeUpload.Image);
                if (responseUpload.Success == false)
                {
                    return View();
                }
                urlAzure = (ResultUpload)responseUpload.Result;
            }
            else
            {
                urlAzure.Url = "";
            }
            var course = new RequestCourseDto
            {
                Id = insertCourseDto.Id,
                Name = insertCourseDto.Name,
                Description = insertCourseDto.Description,
                Knowledge = insertCourseDto.Knowledge,
                Requirments = insertCourseDto.Requirments,
                ImageUrl = urlAzure.Url,
                CategoryId = insertCourseDto.CategoryId,
                Target = insertCourseDto.Target,
            };
            var respone = await _courseService.UpdateCourse(course);
            if (respone.Success == true)
                return RedirectToAction(nameof(Index));
            return View();

        }

        // GET: CourseController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _courseService.GetCourseById(id);
            var course = new RequestCourseDto();
            if (response != null && response.Success)
            {
                course = JsonConvert.DeserializeObject<RequestCourseDto>(Convert.ToString(response.Result));
            }
            ViewBag.Course = course;
            var responseCate = await _courseService.GetCategoryCourse();
            var listCategory = new List<CategoryCourse>();
            if (responseCate != null && responseCate.Success)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryCourse>>(Convert.ToString(responseCate.Result));
            }
            ViewBag.LisCate = listCategory;
            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var response = await _courseService.DeleteCourse(id);
            if (response.Success == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
