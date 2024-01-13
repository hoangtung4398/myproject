using BaseCourse.Dto;
using BaseCourse.Models;
using CourseAPI.Services.IService;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class LectureController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ILectureStorageService _lectureStorageService;

        public LectureController(ICourseService courseService, ILectureStorageService lectureStorageService)
        {
            _courseService = courseService;
            _lectureStorageService = lectureStorageService;
        }



        // GET: LectureController
        public async Task<ActionResult> Index(int id)
        {
            var response = await _courseService.GetListLecture(id);
            var listLecture = new List<ListLectureDto>();
            if (response.Success == true && response != null)
            {
                listLecture = JsonConvert.DeserializeObject<List<ListLectureDto>>(Convert.ToString(response.Result));
            }
            ViewBag.SectionId = id;
            return View(listLecture);
        }

        // GET: LectureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LectureController/Create
        public ActionResult Create(int id)
        {
            ViewBag.SectionId = id;
            return View();
        }

        // POST: LectureController/Create
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] InsertLectureDto insertLecture)
        {
            var uploadResponse = await _lectureStorageService.UploadLectureAsync(insertLecture.File);
            if(uploadResponse.Success == false)
            {
                return View();
            }

            var urlAzure =  (ResultUpload)uploadResponse.Result;
            var lecture = new Lecture()
            {
                Name = insertLecture.Name,
                Url = urlAzure.Url,
                NameFileAzure = urlAzure.Name,
                SectionId = insertLecture.SectionId,
            };

            var response = await _courseService.CreateLecture(lecture);

            return RedirectToAction(nameof(Index), new {id = insertLecture.SectionId });

            

        }

        // GET: LectureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LectureController/Edit/5
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

        // GET: LectureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LectureController/Delete/5
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
