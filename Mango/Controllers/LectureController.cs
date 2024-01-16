using BaseCourse.Dto;
using BaseCourse.Models;
using CourseAPI.Services.IService;
using Mango.Web.Service.IService;

using Mango.Web.Utility;
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
        public async Task<ActionResult> Details(int id)
        {
            var response = await _courseService.GetDetailLecture(id);
            var detailLecture = new DetailLectureDto();
            if (response.Success == true && response != null)
            {
                detailLecture = JsonConvert.DeserializeObject<DetailLectureDto>(Convert.ToString(response.Result));
            }
            ViewBag.SectionId = id;
            return View(detailLecture);
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
            var uploadResponse = await _lectureStorageService.UploadLectureAsync(insertLecture.File,(int)SD.TypeUpload.Video);
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
            if (response.Success == true)
            {
                return RedirectToAction(nameof(Index), new { id = insertLecture.SectionId });

            }
            return View();



        }

        // GET: LectureController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _courseService.GetDetailLecture(id);
            var detailLecture = new DetailLectureDto();
            if (response.Success == true && response != null)
            {
                detailLecture = JsonConvert.DeserializeObject<DetailLectureDto>(Convert.ToString(response.Result));
            }
            ViewBag.Lecture = detailLecture;
            return View();
        }

        // POST: LectureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm]InsertLectureDto insertLecture)
        {
            var urlAzure = new ResultUpload();

			if (insertLecture.File != null)
            {
                var uploadResponse = await _lectureStorageService.UploadLectureAsync(insertLecture.File, (int)SD.TypeUpload.Video);
                if (uploadResponse.Success == false)
                {
                    return View();
                }

                urlAzure = (ResultUpload)uploadResponse.Result;
            }
            var lecture = new Lecture()
            {
                Name = insertLecture.Name,
                Url = urlAzure.Url,
                NameFileAzure = urlAzure.Name,
                SectionId = insertLecture.SectionId,
            };

            var response = await _courseService.UpdateLecture((int)insertLecture.Id, lecture);

            return RedirectToAction(nameof(Index), new { id = insertLecture.SectionId });
        }

        // GET: LectureController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _courseService.GetDetailLecture(id);
            var detailLecture = new DetailLectureDto();
            if (response.Success == true && response != null)
            {
                detailLecture = JsonConvert.DeserializeObject<DetailLectureDto>(Convert.ToString(response.Result));
            }
            ViewBag.SectionId = id;
            return View(detailLecture);
            return View();
        }

        // POST: LectureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var sectionId = collection["SectionId"];
            var response = await _courseService.DeleteLecture(id);
            if(response.Success == true)
            {
                return RedirectToAction(nameof(Index), new {id = sectionId });

            }
            return View();

        }
    }
}
