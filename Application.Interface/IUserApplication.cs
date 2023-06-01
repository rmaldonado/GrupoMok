using Application.DTO;
using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Commons.Base.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserApplication
    {
       
       Task<BaseResponse<IEnumerable<UserResponseDto>>> ListSelectUsers(
           RequestGenerateTokenDto request,
           List<DataItem> listHeader
           );

        Task<BaseResponse<BaseEntityResponse<UserResponseDto>>> ListUsersFilters(BaseFiltersRequest filters,
           List<DataItem> listHeader//viaja el token con cabecera Bearer
                                   );
        Task<BaseResponse<UserResponseDto>> UserById(int id);
        Task<BaseResponse<ResponseTokenDto>> AccountByUserName(LoginRequestDto request);
        //Task<BaseResponse<UserResponseDto>> ValidateUsersAsync(LoginRequestDto requestDto);
        Task<BaseResponse<bool>> Register(UserRequestCreate requestDto);
        Task<BaseResponse<bool>> Edit(int id, UserRequestEdit requestDto);
        Task<BaseResponse<bool>> Remove(int id);
        Task<BaseResponseDto<ResponseTokenDto, BaseRequestDto>> GenerateToken(RequestGenerateTokenDto requestPublico);
        Task<BaseResponseDto<ResponseValidateToken, BaseRequestDto>> ValidateToken(RequestValidateDto requestValidateDto);
    }
}
