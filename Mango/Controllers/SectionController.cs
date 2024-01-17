using BaseCourse.Dto;
using BaseCourse.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly ICourseService _courseService;
        public SectionController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: SectionController
        public async Task<ActionResult> Index(int id)
        {
            var response = await _courseService.GetListSection(id);
            var listSection = new List<ListSectionDto>();
            if (response.Success == true && response != null)
            {
                listSection = JsonConvert.DeserializeObject<List<ListSectionDto>>(Convert.ToString(response.Result));
            }
            ViewBag.Id = id;
            return View(listSection);
        }

        // GET: SectionController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "Lecture", new { id });
        }

        // GET: SectionController/Create
        public ActionResult Create(int id)
        {
            var section = new DataItem { Id = id };
            return View(section);
        }

        // POST: SectionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DataItem section)
        {
            var response = await _courseService.CreateSection(section);
            if (response.Success == true)
            {
                return RedirectToAction(nameof(Index), new { id = section.Id });
            }
            return View();
        }

        // GET: SectionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _courseService.GetSectionById(id);
            var section = new Section();
            if (response.Success == true)
            {
                section = JsonConvert.DeserializeObject<Section>(Convert.ToString(response.Result));
            }
            return View(section);
        }

        // POST: SectionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Section section)
        {
            var response = await _courseService.UpdateSection(id, section);
            if (response.Success == true)
            {
                return RedirectToAction(nameof(Index), new { id = section.CourseId });

            }
            return View(section);


        }

        // GET: SectionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _courseService.GetSectionById(id);
            var section = new Section();
            if (response.Success == true)
            {
                section = JsonConvert.DeserializeObject<Section>(Convert.ToString(response.Result));
            }
            return View(section);
        }

        // POST: SectionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var courseId = collection["CourseId"];
            var response = await _courseService.DeleteSection(id);
            if (response.Success == true)
            {
                return RedirectToAction(nameof(Index), new { id = courseId });
            }
            return View();
        }
    }
}
