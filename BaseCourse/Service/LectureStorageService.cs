using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BaseCourse.AzureConfig;
using BaseCourse.Dto;
using BaseCourse.Dto.Dto;
using BaseCourse.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace CourseAPI.Services
{
    public class LectureStorageService : ILectureStorageService
    {
        private readonly StorageLecture _lecture;

        public LectureStorageService(IOptions<StorageLecture> lecture)
        {
            _lecture = lecture.Value;
        }

        public Task<ResponseDto> DeleteLectureAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UploadLectureAsync(IFormFile file,int type)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_lecture.ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_lecture.ContainerName);
            var extension = Path.GetExtension(file.FileName).ToLower();
           
                var fileName = Guid.NewGuid().ToString() + extension;
				var blobClient = containerClient.GetBlobClient(fileName);
                var blobHttpHeader = new BlobHttpHeaders();
                if (type == 0)
                {
                    blobHttpHeader = new BlobHttpHeaders { ContentType = $"video/{extension.Substring(1)}" };
                }
                else if (type == 1)
                {
                    
                }
                else if(type == 2)
                {
                    blobHttpHeader = new BlobHttpHeaders { ContentType = $"image/{extension.Substring(1)}" };
                }
				await blobClient.UploadAsync(file.OpenReadStream(), new BlobUploadOptions { HttpHeaders = blobHttpHeader });
                var lecture = new ResultUpload
                {
                    Name = fileName,
                    Url = blobClient.Uri.AbsoluteUri
                };

                return new ResponseDto { Success = true, Result = lecture, Message = "" };
            
            
        }
    }
}