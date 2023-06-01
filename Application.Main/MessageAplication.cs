using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interface;
using AutoMapper;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Interface.Patterns;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Main
{
    public class MessageAplication : IMessageAplication {
        private readonly MemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageAplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<BaseResponse<bool>> Edit(int id, MessageRequestDto requestDto) {
            throw new System.NotImplementedException();
        }
        public async Task<BaseResponse<IEnumerable<MessageResponseDto>>> ListSelectMessage() {
            throw new System.NotImplementedException();
        }
        public Task<BaseResponse<IEnumerable<MessageResponseDto>>> ListSelectMessageFilter(BaseFiltersRequest filters) {
            throw new System.NotImplementedException();
        }
        public Task<BaseResponse<MessageResponseDto>> MessageById(int id) {
            throw new System.NotImplementedException();
        }
        public Task<BaseResponse<bool>> Register(MessageRequestDto requestDto) {
            throw new System.NotImplementedException();
        }
        public Task<BaseResponse<bool>> Remove(int id) {
            throw new System.NotImplementedException();
        }

        
    }
}
