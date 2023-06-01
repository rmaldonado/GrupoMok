using Application.DTO.Base;
using Application.DTO.Response;

using Domain.Entity.V1;
using System.Threading.Tasks;

namespace Transversal.Common.Helpers
{
    public interface IHelpful
    {
        Task WriteToken(string token, string transactionId, string method);
        Task<string> Mask(string cardNumber);
        Task<string> ValidateTokenExist(string token);
        Task<string> GetClaimToken(string token, string nameClaim);
        Task<BaseResponse<UserResponseDto>> BuildResponseList(string messageCode, Message message, int statusCode);
        Task<int> GetAmoutInt(string amount);
        Task<bool> JwtIsValid(string token);
    }
}
