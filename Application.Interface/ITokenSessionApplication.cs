using Application.DTO;
using Application.DTO.Request;
using Application.DTO.Response;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ITokenSessionApplication
    {
        //Task<BaseResponseDto<ResponseTokenDto, BaseRequestDto>> GenerateToken(RequestGenerateToken request, string urlApiValidateEntity, string urlAuthentication);

        Task<BaseResponseDto<ResponseValidateToken, BaseRequestDto>> ValidateToken(RequestValidateDto requestValidateDto, string urlAuthentication, string urlApiValidateEntity);
    }
}
