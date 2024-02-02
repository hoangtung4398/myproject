using BaseCourse.Dto;
using Learnify.Web.Service.IService;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Learnify.Web.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IBaseService _baseService;

        public DocumentService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto> DeleteDocument(int documentId)
        {
            return _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{SD.DocumentAPIbase}/api/Document/Delete/{documentId}"
            });
        }

        public Task<ResponseDto> GetAll()
        {
            return _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.DocumentAPIbase}/api/Document/GetAll"
            });
        }

        public async Task<ResponseDto> GetList()
        {
            return await _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.DocumentAPIbase}/api/Document/GetList"
            });
        }

        public Task<ResponseDto> UploadDocument(DocumentDto documentDto)
        {
            return _baseService.SendAsync(new Requestmsg()
            {
                ApiType = SD.ApiType.POST,
                Data = documentDto,
                Url = $"{SD.DocumentAPIbase}/api/Document/Create"
            });
        }
    }
}
