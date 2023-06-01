using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Infraestructure.Commons.Base.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRolesApplication
    {
        Task<BaseResponse<IEnumerable<RolesResponseDto>>> ListSelectRoles();
        Task<BaseResponse<IEnumerable<RolesResponseDto>>> ListSelectRolesFilter(BaseFiltersRequest filters);
        Task<BaseResponse<RolesResponseDto>> RolesById(int id);
        Task<BaseResponse<bool>> Register(RolesRequestCreateDto requestDto);
        Task<BaseResponse<bool>> Edit(int id, RolesRequestEditDto requestDto);
        Task<BaseResponse<bool>> Remove(int id);
    }
}
