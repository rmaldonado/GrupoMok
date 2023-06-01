using Application.DTO;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Extention
{
    public class Rest
    {
        public static async Task<ResponseToken<string>> PostToken(string uri, RequestGenerateTokenDto requestPublico)
        {
            var response = new ResponseToken<string>(); ;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonParameters = JsonConvert.SerializeObject(requestPublico);
                    var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                    var result = client.PostAsync($"{uri}", content).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        var resultData = JsonConvert.DeserializeObject<ResponseTokenRest>(resultContent);
                        response.Data = resultData.Data.Token;
                        response.Message = resultData.Message;
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
        public static async Task<string> _Post(string uri, dynamic requestGenerate)
        {
            string resultContent = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonParameters = JsonConvert.SerializeObject(requestGenerate);
                    var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                    var result = client.PostAsync($"{uri}", content).Result;

                    resultContent = result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                resultContent = e.Message;
            }
            return await Task.Run(() => resultContent);
        }
        public static async Task<ResponseEntity<string>> PostValidateEntity(string uri, RequestValidateEntity requestGenerate)
        {
            var response = new ResponseEntity<string>(); ;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonParameters = JsonConvert.SerializeObject(requestGenerate);
                    var content = new StringContent(jsonParameters, Encoding.UTF8, "application/json");
                    var result = client.PostAsync($"{uri}", content).Result;

                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    response.Data = resultContent;
                    response.IsSuccess = true;
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

        public class ResponseTokenRest
        {
            public Data Data { get; set; }
            public string Message { get; set; }
        }
        public class Data
        {
            public string Token { get; set; }
        }
    }
}
