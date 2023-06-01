using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface {
    public interface IMenuApplication {
        Task<BaseResponse<IEnumerable<MenuResponseDto>>> ListSelectMenu();
        Task<BaseResponse<MenuResponseDto>> MenuById(int id);
        Task<BaseResponse<bool>> Register(MenuRequestCreateDto requestDto);
        Task<BaseResponse<bool>> Edit(int id, MenuRequestEditDto requestDto);
        Task<BaseResponse<bool>> Remove(int id);
    }
}
