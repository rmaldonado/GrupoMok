using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
    public class LoginRequestDto
    {
       
        public string Username { get; set; }  
        public string Password { get; set; }
    }
}
