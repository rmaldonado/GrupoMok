namespace Application.DTO.Base
{
    public class BaseResponse<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string MessageUser { get; set; }
        public string MessageUserEng { get; set; }
        public HeaderResponseDto Header { get; set; }
        public T Response { get; set; }
        public int StatusCode { get; set; }

        public class HeaderResponseDto
        {
            public string TransactionStartDatetime { get; set; }
            public string TransactionEndDatetime { get; set; }
            public string Millis { get; set; }
        }
    }
}

