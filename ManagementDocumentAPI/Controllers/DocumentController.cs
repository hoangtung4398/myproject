using BaseCourse.Dto;
using BaseCourse.Dto.Dto;
using BaseCourse.Models;
using ManagementDocumentAPI.Repository.IRepository;
using ManagementDocumentAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace ManagementDocumentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IGetUserService _getUserService;
        private readonly ResponseDto _response;
        public DocumentController(IDocumentRepository documentRepository, IGetUserService getUserService)
        {
            _getUserService = getUserService;
            _documentRepository = documentRepository;
            _response = new ResponseDto();
        }
        [HttpGet("GetList")]

        public IActionResult GetList()
        {
            var user = _getUserService.GetUser();
            var list = _documentRepository.Get(x => x.CreatedBy == user.Id && x.Lecture == null).Select(x => new DocumentDto
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                NameAzure = x.NameAzure,
                CreatedBy = x.CreatedBy,
            }).ToList();
            list = list.OrderByDescending(x => x.Id).ToList();
            _response.Result = list;
            return Ok(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _documentRepository.Get(x => x.Id == id).FirstOrDefault();
            if (obj == null)
            {
                _response.Success = false;
                _response.Message = "Error while deleting";
                return NotFound(_response);
            }
            _documentRepository.Delete(obj.Id);
            _response.Success = true;
            _response.Message = "Delete successful";
            return Ok(_response);
        }
        [HttpPost("Create")]
        public IActionResult Create(DocumentDto documentDto)
        {
            var user = _getUserService.GetUser();
            if (!ModelState.IsValid)
            {
                _response.Success = false;
                _response.Message = "Error while creating";
                return BadRequest(_response);
            }
            var obj = new Document
            {
                Name = documentDto.Name,
                Url = documentDto.Url,
                NameAzure = documentDto.NameAzure,
                CreatedBy = user.Id,
            };
            _documentRepository.Add(obj);
            _response.Success = true;
            _response.Message = "Create successful";
            return Ok(_response);
        }
        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var user = _getUserService.GetUser();
            var list = _documentRepository.Get(x=>1==1).Select(x => new DocumentDto
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                NameAzure = x.NameAzure,
                CreatedBy = x.CreatedBy,
            }).ToList();
            list = list.OrderByDescending(x => x.Id).ToList();
            _response.Result = list;
            return Ok(_response);
        }
    }
}
