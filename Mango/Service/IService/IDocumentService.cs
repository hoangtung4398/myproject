using BaseCourse.Dto;
using Mango.Web.Models;

namespace Learnify.Web.Service.IService
{
    public interface IDocumentService
    {
        Task<ResponseDto> UploadDocument(DocumentDto documentDt);
        Task<ResponseDto> GetList();
        Task<ResponseDto> GetAll();
        Task<ResponseDto> DeleteDocument(int documentId);
    }
}
