using BaseCourse.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public async Task<ResponseDto> SendAsync(Requestmsg request)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage msg = new();
                msg.Headers.Add("Accept", "application/json");
                //token
                if (_tokenProvider.GetToken() != null)
                {
                    msg.Headers.Add("Authorization", _tokenProvider.GetToken());
                }

                msg.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    msg.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }

                switch (request.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        msg.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.PUT:
                        msg.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        msg.Method = HttpMethod.Delete;
                        break;
                    default:
                        msg.Method = HttpMethod.Get;
                        break;



                }
                HttpResponseMessage? responseMessage = await client.SendAsync(msg);
                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Success = false, Message = "Not Found" };
                    case HttpStatusCode.Unauthorized: return new() { Success = false, Message = "Unauthorized" };
                    case HttpStatusCode.Forbidden: return new() { Success = false, Message = "Access Denied" };
                    case HttpStatusCode.InternalServerError: return new() { Success = false, Message = "InternalServerError" };
                    default:
                        var content = await responseMessage.Content.ReadAsStringAsync();
                        var Result = JsonConvert.DeserializeObject<ResponseDto>(content);
                        return Result;
                }
            }
            catch (Exception ex)
            {
                var response = new ResponseDto
                {
                    Success = false,
                    Message = ex.Message,
                };
                return response;
            }


        }

    }


}
