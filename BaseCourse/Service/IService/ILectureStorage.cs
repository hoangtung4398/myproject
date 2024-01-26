
using BaseCourse.Dto.Dto;
using Microsoft.AspNetCore.Http;

namespace BaseCourse.Service.IService
{
    public interface ILectureStorageService
    {
        Task<ResponseDto> UploadLectureAsync(IFormFile file, int x);
        Task<ResponseDto> DeleteLectureAsync();
    }
}
