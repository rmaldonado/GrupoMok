using Application.DTO.AppSettings;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransversalCommon.Interfaces;

namespace Transversal.Common.Helpers
{

    public class Helpful : IHelpful
    {
        private readonly IAppLogger _Logger;
        private ConfigController _config;
        public Helpful(IAppLogger logger, IOptionsSnapshot<ConfigController> configController)
        {
            _Logger = logger;
            _config = configController.Value;
        }

        public async Task WriteToken(string token, string transactionId, string method)
        {
            if (_config.Flag_WriteToken)
                await Task.Run(() => _Logger.LogInfo($"{transactionId}|{method}|Token|{JsonConvert.SerializeObject(token)}"));
        }

        public async Task<string> Mask(string cardNumber)
        {
            var firstDigits = cardNumber.Substring(0, 6);
            var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);
            var requiredMask = new String('*', cardNumber.Length - firstDigits.Length - lastDigits.Length);

            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0");

            return await Task.Run(() => maskedCardNumberWithSpaces);
        }

        public async Task<string> ValidateTokenExist(string token)
        {
            string message = Constants.OK;
            if (token == null) return "P01";
            if (token == null) return "P01";
            if (string.IsNullOrWhiteSpace(token)) return "P01";
            if (!token.Contains("Bearer ")) return "P02";
            return await Task.Run(() => message);
        }

        public async Task<string> GetClaimToken(string token, string nameClaim)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var valueClaim = tokenS.Claims.First(claim => claim.Type.ToString().ToUpper() == nameClaim.ToUpper()).Value;
            return await Task.Run(() => valueClaim);
        }

        public async Task<bool> JwtIsValid(string token)
        {
            try
            {
                string _token = token.Replace(Constants.Bearer, string.Empty);
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(_token);
                var tokenS = jsonToken as JwtSecurityToken;
                var valueClaim = tokenS.Claims.First(claim => claim.Type.ToString().ToUpper() == "AMOUNT").Value;
                return await Task.Run(() => true);
            }
            catch (Exception)
            {
                return await Task.Run(() => false);
            }

        }
    }
}
