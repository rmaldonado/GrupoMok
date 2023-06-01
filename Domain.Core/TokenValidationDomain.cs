using Application.DTO;
using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Common;
using Domain.Entity;
using Domain.Interface.Controller;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TransversalCommon.Interfaces;

namespace Domain.Core.Controller
{
    public class TokenValidationDomain : ITokenValidationDomain
    {
        private readonly IRestClient _restClient;
        //private readonly IMessageRepository _messageRepository;
        private EndPointController _endPointController;

        private string _language = string.Empty;

        public TokenValidationDomain(
            IRestClient restClient,
            //IMessageRepository messageRepository,
            IOptionsSnapshot<EndPointController> endPointController)
        {
            _restClient = restClient;
            //_messageRepository = messageRepository;
            _endPointController = endPointController.Value;
        }

        public async Task<string> TokenValidate(List<DataItem> listHeader, string Name, string UserId)
        {
            string message = string.Empty;
            string token = string.Empty;

            token = listHeader.Find(delegate (DataItem item) { return item.Name == "token"; }).Value;

            if (string.IsNullOrEmpty(token))
            {
                message = "Token not found";
            }
            else
            {
                List<DataItem> listaItems = new List<DataItem>();

                RequestValidateTokenDto requestValidateToken = new RequestValidateTokenDto
                {
                    Token = token.Replace(Constants.Bearer, string.Empty),
                    Name = nameof(TokenValidate),
                };

                var resultTokenValidate = await _restClient.PostAsync(_endPointController.EndPointApiValidateToken, requestValidateToken, listaItems);
                string responseToken = resultTokenValidate.ResultContent;
                var responseTokenValidate = JsonConvert.DeserializeObject<BaseResponse<ResponseValidateTokenDto>>(responseToken);
                if (responseTokenValidate != null)
                {
                    message = responseTokenValidate.Message;
                }
            }
            return await Task.Run(() => message);
        }

        #region Validación de campos que integran el token
        public async Task<Validation> ValidateTokenField(List<DataItem> listHeader)
        {
            DataItem messageValidation = new DataItem();
            //_language = request.Language;
            Validation validation = new Validation
            {
                Validate = true,
                Message = Constants.OK
            };

            string token = string.Empty;
            string idTransaction = string.Empty;

            token = listHeader.Find(delegate (DataItem item) { return item.Name == "token"; }).Value;
            token = token.Replace(Constants.Bearer, string.Empty);
            idTransaction = listHeader.Find(delegate (DataItem item) { return item.Name == "transactionId"; }).Value;


            messageValidation = await ValidationIdTransaction(token, idTransaction);
            if (!messageValidation.Value.Equals(Constants.OK))
            {
                validation.Code = messageValidation.Name;
                validation.Validate = false;
                validation.Message = messageValidation.Value;
                return validation;
            }

            return await Task.Run(() => validation);
        }


        private async Task<DataItem> ValidationIdTransaction(string token, string IdTransaction)
        {
            DataItem lista = new DataItem();
            //string _IdTransaction = await GetClaimToken(token, "IdTransaction");
            string _IdTransaction = await GetClaimToken(token, "transactionId");
            //if (!_IdTransaction.Equals(_IdTransaction)) return await _messageRepository.MessagesBD("TA1", _language);
            lista = new DataItem { Name = "00", Value = Constants.OK };
            return await Task.Run(() => lista);
        }
        private async Task<string> GetClaimToken(string token, string nameClaim)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var valueClaim = tokenS.Claims.First(claim => claim.Type == nameClaim).Value;
            return await Task.Run(() => valueClaim);
        }
        #endregion

    }

}
