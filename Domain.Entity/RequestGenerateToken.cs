
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class RequestGenerateToken
    {
        public string Username { get; set; }

        public string Password { get; set; }
        //[Required(ErrorMessage = "You must enter a publicKey to generate the token")]
        //[StringLength(400, MinimumLength = 16)]
        public string KeyPublic { get; set; }
       
    }
}
