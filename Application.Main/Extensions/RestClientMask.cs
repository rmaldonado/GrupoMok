using Application.DTO;
using Application.DTO.Request;
using Application.DTO.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Application.Main.Extention.Rest;

namespace Application.Main.Extention
{
    public class RestClientMask
    {
        public static async Task<Response<string>> Post(string uri, RequestGenTokenDto request)
        {
            var response = new Response<string>(); ;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonParameters = JsonConvert.SerializeObject(request);
                    var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                    var result = client.PostAsync($"{uri}", content).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        var resultData = JsonConvert.DeserializeObject<ResponseTokenRest>(resultContent);
                        response.Data = resultData.Data.Token;
                        response.IsSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return await Task.Run(() => response);
        }

      

        public static async Task<BaseResponseDto<ResponseValidateToken, BaseRequestDto>> PostValidate(string uri, RequestValidateDto request)
        {
            BaseResponseDto<ResponseValidateToken, BaseRequestDto> response = new BaseResponseDto<ResponseValidateToken, BaseRequestDto>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonParameters = JsonConvert.SerializeObject(request);
                    var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                    var result = client.PostAsync($"{uri}", content).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        var resultData = JsonConvert.DeserializeObject<BaseResponseDto<ResponseValidateToken, BaseRequestDto>>(resultContent);
                        response = resultData;
                    }
                    else
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        var resultData = JsonConvert.DeserializeObject<BaseResponseDto<ResponseValidateToken, BaseRequestDto>>(resultContent);
                        response = resultData;
                    }
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return await Task.Run(() => response);
        }
        public class Response<T>
        {
            public T Data { get; set; }
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }
    }
}
