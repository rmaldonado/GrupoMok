using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class RequestValidateEntity
    {
        [Required(ErrorMessage = "You must enter a value ")]
        public string Username { get; set; }         
    }
}
