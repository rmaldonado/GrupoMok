using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Application.Main.Extention
{
    public class ValidateJWT
    {
        public string Validate(string token)
        {
            string MessageValidateStructure = string.Empty;
            string MessageExpiration = string.Empty;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            MessageValidateStructure = ValidateStructure(tokenS);
            if (!MessageValidateStructure.Equals("OK")) return MessageValidateStructure;

            MessageExpiration = ValidateExpiration(tokenS);
            if (!MessageExpiration.Equals("OK")) return MessageExpiration;

            return "OK";
        }
        private string ValidateExpiration(JwtSecurityToken tokenS)
        {
            var Expiration = tokenS.Claims.First(claim => claim.Type == "exp").Value;
            var Iat = tokenS.Claims.First(claim => claim.Type == "iat").Value;

            long init = Convert.ToInt32(Iat);
            long end = Convert.ToInt32(Expiration);

            long timeExpireJwt = end - init;

            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

            long timeExpireLocal = unixTime - init;

            if (timeExpireLocal > timeExpireJwt) return "Token expired.";

            return "OK";
        }
        private string ValidateStructure(JwtSecurityToken tokenS)
        {
            var UserName = tokenS.Claims.First(claim => claim.Type == "UserName").Value;
            var UserId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            var TokenId = tokenS.Claims.First(claim => claim.Type == "TokenId").Value;
            var Expiration = tokenS.Claims.First(claim => claim.Type == "exp").Value;
            var iat = tokenS.Claims.First(claim => claim.Type == "iat").Value;

            if (string.IsNullOrEmpty(UserName)) return "UserName is not valid.";
            if (string.IsNullOrEmpty(UserId)) return "UserId is not valid.";
            if (string.IsNullOrEmpty(TokenId)) return "TokenId is not valid.";
            if (string.IsNullOrEmpty(Expiration)) return "Expiration is not valid.";

            return "OK";
        }
        public string GetClaimToken(string token, string nameClaim)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var valueClaim = tokenS.Claims.First(claim => claim.Type == nameClaim).Value;
            return valueClaim;
        }
    }
}
