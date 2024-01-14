using CouponAPI.Models.Dto;

namespace CourseAPI.Services.IService
{
    public interface ILectureStorageService
    {
        Task<ResponseDto> UploadLectureAsync(IFormFile file,int x);
        Task<ResponseDto> DeleteLectureAsync();
    }
}
