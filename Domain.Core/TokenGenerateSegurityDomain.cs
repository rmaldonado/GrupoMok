using Application.DTO;
using Application.DTO.Request;
using Application.DTO.Response;
using Domain.Entity;
using Domain.Entity.Models;
using Domain.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransversalCommon.Interfaces;
using static TransversalCommon.RestClient;

namespace Domain.Core
{
    public class TokenGenerateSegurityDomain : ITokenGenerateSegurityDomain
    {
        private readonly IRestClient _restClient;
        private EndPointController _endPoint;

        public TokenGenerateSegurityDomain(
            IRestClient restClient,
            IOptionsSnapshot<EndPointController> endPoint)
        {
            _restClient = restClient;
            _endPoint = endPoint.Value;
        }

        public async Task<BaseResponseDto<ResponseTokenDto, BaseRequestDto>> GenerateToken(RequestGenerateToken requestPublic)
        {

            List<HeaderRest> headers = new List<HeaderRest>
            {
                new HeaderRest { Name = "keyPublic", Value = "VErethUtraQuxas57wuMuquprADrAHAb"},
            };

            BaseResponseDto<ResponseTokenDto, BaseRequestDto> response = new BaseResponseDto<ResponseTokenDto, BaseRequestDto>();
            var responseTokenGenerate = new ResponseToken<string>();

            var RequestValidateEntity = new RequestValidateEntity();
            RequestValidateEntity.Username = requestPublic.Username;

            RequestGenerateTokenDto requestToken = new RequestGenerateTokenDto();

            var resultApitoken = await _restClient
                .PostAsyncWithHeaders($"{_endPoint.EndPointApiGenerateToken}https://localhost:7108/v1/Token/Generate", headers, requestToken);

            string responseBusinessPost = resultApitoken.ResultContent;
            var ResponseTokenDto = JsonConvert.DeserializeObject<ResponseTokenDto>(responseBusinessPost);

            return response;

        }
    }
}
