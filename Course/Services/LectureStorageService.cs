using Azure.Storage;
using Azure.Storage.Blobs;
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
            BlobServiceClient blobServiceClient = new BlobServiceClient("BlobEndpoint=https://coursefileupload.blob.core.windows.net/;QueueEndpoint=https://coursefileupload.queue.core.windows.net/;FileEndpoint=https://coursefileupload.file.core.windows.net/;TableEndpoint=https://coursefileupload.table.core.windows.net/;SharedAccessSignature=sv=2022-11-02&ss=bfqt&srt=c&sp=rwdlacupiytfx&se=2024-01-11T19:23:35Z&st=2024-01-11T11:23:35Z&spr=https&sig=IuKwiQqnRoxfJgYTBa0xXxURvosTsAKbtgDp5nDOcSA%3D");
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var extension = Path.GetExtension(file.FileName).ToLower();
            var containerClient = new BlobContainerClient(new Uri(blobUri), credential);
            var blobClient = containerClient.GetBlobClient(_lecture.ContainerName);
            if (extension == ".mp4" || extension == ".avi" || extension == ".mkv")
            {
                var fileName = Guid.NewGuid().ToString() + extension;
                
               
                    
                   var response =  await blobClient.UploadAsync(file.OpenReadStream());

                return new ResponseDto { Success = true, Message = "123123" };
            }
            else
            {
                return new ResponseDto { Success = false, Message = "File extension not supported" };
            }
        }
    }
}