using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Infraestructure.Commons.Base.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMessageAplication {
        Task<BaseResponse<IEnumerable<MessageResponseDto>>> ListSelectMessage();
        Task<BaseResponse<IEnumerable<MessageResponseDto>>> ListSelectMessageFilter(BaseFiltersRequest filters);
        Task<BaseResponse<MessageResponseDto>> MessageById(int id);
        Task<BaseResponse<bool>> Register(MessageRequestDto requestDto);
        Task<BaseResponse<bool>> Edit(int id, MessageRequestDto requestDto);
        Task<BaseResponse<bool>> Remove(int id);
    }
}
