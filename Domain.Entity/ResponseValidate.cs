using System;

namespace Domain.Entity
{
    public  class ResponseValidate<T>
    {
        public int Id { get; set; }
        public int TradeId { get; set; }
        public string TradeType { get; set; }
        public string MessageResponse { get; set; }
        public string KeyPublic { get; set; }
        public string Token { get; set; }
        public string Secret { get; set; }
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    
    public class ResponsComercio
    {
        public int Id { get; set; }
       
        public string? KeyPublic { get; set; }

        public string? Token { get; set; }
        public string? Secret { get; set; }
        public string? LlaveSRC { get; set; }
        public DateTime exp { get; set; }
    }
}
