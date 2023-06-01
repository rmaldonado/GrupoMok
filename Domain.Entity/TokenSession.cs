using System;

namespace Domain.Entity
{
    public class TokenSession
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string TransactionId { get; set; }
        public string OrderNumber { get; set; }
        public string EntryData { get; set; }
        public string Token { get; set; }
        public string TokenId { get; set; }
        public string TokenIdReference { get; set; }
        public int Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public string NewTokenId { get; set; }
    }
}
