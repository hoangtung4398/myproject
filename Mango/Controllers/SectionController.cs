using BaseCourse.Dto;
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
		public ActionResult Create()
		{
			return View();
		}

		// POST: SectionController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
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

		// GET: SectionController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SectionController/Edit/5
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

		// GET: SectionController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SectionController/Delete/5
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
