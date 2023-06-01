using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Request
{
    public class RequestValidateEntityDto
    {
        //[Required(ErrorMessage = "You must enter a value ")]
        public string UserId { get; set; }

        //[Required(ErrorMessage = "You must enter an Token")]
        public string Token { get; set; }
    }
}
