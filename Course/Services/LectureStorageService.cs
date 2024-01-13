using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BaseCourse.Dto;
using BaseCourse.Models;
using CouponAPI.Models.Dto;
using CourseAPI.Models;
using CourseAPI.Models.AzureConfig;
using CourseAPI.Repository.IRepository;
using CourseAPI.Services.IService;
using Microsoft.Extensions.Options;

namespace CourseAPI.Services
{
    public class LectureStorageService : ILectureStorageService
    {
        private readonly StorageLecture _lecture;
        private readonly ILectureRepository _lectureRepository;

        public LectureStorageService(IOptions<StorageLecture> lecture)
        {
            _lecture = lecture.Value;
        }

        public Task<ResponseDto> DeleteLectureAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UploadLectureAsync(IFormFile file)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_lecture.ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_lecture.ContainerName);
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension == ".mp4" || extension == ".avi" || extension == ".mkv")
            {
                var fileName = Guid.NewGuid().ToString() + extension;
				var blobClient = containerClient.GetBlobClient(fileName);

                var blobHttpHeader = new BlobHttpHeaders { ContentType = $"video/{extension.Substring(1)}" };
				await blobClient.UploadAsync(file.OpenReadStream(), new BlobUploadOptions { HttpHeaders = blobHttpHeader });
                var lecture = new ResultUpload
                {
                    Name = fileName,
                    Url = blobClient.Uri.AbsoluteUri
                };

                return new ResponseDto { Success = true, Result = lecture, Message = "" };
            }
            else
            {
                return new ResponseDto { Success = false, Message = "File extension not supported" };
            }
        }
    }
}