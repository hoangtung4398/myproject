using BaseCourse.Dto;
using BaseCourse.Service.IService;
using Learnify.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Learnify.Web.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly ILectureStorageService _lectureStorageService;
        public DocumentController(IDocumentService documentService, ILectureStorageService lectureStorageService)
        {
            _documentService = documentService;
            _lectureStorageService = lectureStorageService;
        }

        public async Task<IActionResult> ListDocument(int? page)
        {
            var response = await _documentService.GetList();
            var listDocument = new List<DocumentDto>();
            if (response != null && response.Success)
            {
                listDocument = JsonConvert.DeserializeObject<List<DocumentDto>>(Convert.ToString(response.Result));
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(listDocument.ToPagedList(pageNumber, pageSize));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _documentService.DeleteDocument(id);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(ListDocument));
            }
            return NotFound();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertDocumentDto insertDocumentDto)
        {
            var responseUpload = await _lectureStorageService.UploadLectureAsync(insertDocumentDto.File, (int)SD.TypeUpload.Doc);
            if (responseUpload.Success == false)
            {
                return View();
            }
            var urlAzure = (ResultUpload)responseUpload.Result;
            var documentDto = new DocumentDto
            {
                Name = insertDocumentDto.Name,
                Url = urlAzure.Url,
                NameAzure = urlAzure.Name,
            };
            var response = await _documentService.UploadDocument(documentDto);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(ListDocument));
                }
            
            return View(documentDto);
        }
        public async Task<IActionResult> ListAllDocument(int? page)
        {
            var response = await _documentService.GetAll();
            var listDocument = new List<DocumentDto>();
            if (response != null && response.Success)
            {
                listDocument = JsonConvert.DeserializeObject<List<DocumentDto>>(Convert.ToString(response.Result));
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(listDocument.ToPagedList(pageNumber, pageSize));
        }
    }
}
