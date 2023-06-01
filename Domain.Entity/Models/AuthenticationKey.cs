using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Models
{
    public class AuthenticationKey
    {
        [Key]
        public int AuthenticationKeyId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string KeyPublic { get; set; }
        public bool KeyStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
