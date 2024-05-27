using Employee.Web.Models;
using Employee.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Employee.Web.Utility.SD;

namespace Employee.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
                
        }
        public async Task<ServiceResponse?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("EmployeeAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/jason");
                message.RequestUri = new Uri(requestDto.Url);
                if(requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");

                }
                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { success = false, message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { success = false, message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { success = false, message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { success = false, message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ServiceResponse>(apiContent);
                        return apiResponseDto;

                }
            }
            catch (Exception ex)
            {
                var dto = new ServiceResponse
                {
                    message = ex.Message.ToString(),
                    success = false
                };
                return dto;
            }
        }
    }
}
