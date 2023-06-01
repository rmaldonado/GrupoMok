using Application.DTO.Response;
using System.Threading.Tasks;

namespace Transversal.Common.Helpers
{
    public interface IHelpful
    {
        Task WriteToken(string token, string transactionId, string method);
        Task<string> Mask(string cardNumber);
        Task<string> ValidateTokenExist(string token);
        Task<string> GetClaimToken(string token, string nameClaim);
        Task<bool> JwtIsValid(string token);     

    }
}
