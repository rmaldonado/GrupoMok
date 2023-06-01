using System;

namespace Domain.Entity.Models
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string RefreshTokenValue { get; set; }
        public bool Active { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
        public string UserId { get; set; }
    }
}
