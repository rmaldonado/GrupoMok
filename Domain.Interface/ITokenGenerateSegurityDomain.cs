using Application.DTO;
using Application.DTO.Response;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ITokenGenerateSegurityDomain
    {

        Task<BaseResponseDto<ResponseTokenDto, BaseRequestDto>> GenerateToken(RequestGenerateToken requestPublic);        
        
    }
}
