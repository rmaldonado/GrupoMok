using Application.DTO.Request;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.Extention
{
    public class GenerateJWT
    {
        public async Task<string> GenerateAccessToken(RequestGenerateTokenDto requestGenerateTokenDto, Guid tokenId, int timeToExpiration)
        {
            var keyBytes = Encoding.ASCII.GetBytes(requestGenerateTokenDto.KeyPublic);
            var claims = new ClaimsIdentity();
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var validate = tokenId != Guid.Empty;
           
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("UserName", requestGenerateTokenDto.Username),
                        new Claim("UserId", requestGenerateTokenDto.UserId.ToString()),
                        new Claim("TokenId", tokenId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(timeToExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string tokencreado = tokenHandler.WriteToken(tokenConfig);
            return await Task.Run(() => tokencreado);
        }
      }
    }
