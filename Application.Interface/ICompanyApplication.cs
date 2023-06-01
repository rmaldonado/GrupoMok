using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICompanyApplication
    {
        Task<BaseResponse<IEnumerable<CompanyResponseDto>>> ListSelectCompany();
        Task<BaseResponse<CompanyResponseDto>> CompanyById(int id);
        Task<BaseResponse<bool>> Register(CompanyRequestCreateDto requestDto);
        Task<BaseResponse<bool>> Edit(int id, CompanyRequestEditDto requestDto);
        Task<BaseResponse<bool>> Remove(int id);
    }
}
