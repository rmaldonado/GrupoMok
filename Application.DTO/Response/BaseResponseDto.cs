using Application.DTO.Response;
using System;

namespace Application.DTO
{
    public class BaseResponseDto<T,R> 
    {
        public ResponseHeaderDto Header { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string MessageUser { get; set; }

        public ResponseErrorDto<R> Error { get; set; }

        public static implicit operator BaseResponseDto<T, R>(BaseResponseDto<string, BaseRequestDto> v)
        {
            throw new NotImplementedException();
        }
    }
}