using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
    public  class RequestGenerateTokenDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }     
        public string Password { get; set; }
        public string KeyPublic { get; set; }

    }
}
