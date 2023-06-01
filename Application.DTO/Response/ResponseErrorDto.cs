using System.Collections.Generic;

namespace Application.DTO
{
    public class ResponseErrorDto<T> 
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public T Request { get; set; }
        public IList<ErrorDto> Errors { get; set; }
        public string MerchantId { get; set; }
        public string MerchantType { get; set; }
        public bool Status { get; set; }
    }
}