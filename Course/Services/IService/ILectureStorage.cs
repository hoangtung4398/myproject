using CouponAPI.Models.Dto;

namespace CourseAPI.Services.IService
{
    public interface ILectureStorageService
    {
        Task<ResponseDto> UploadLectureAsync(IFormFile file);
        Task<ResponseDto> DeleteLectureAsync();
    }
}
