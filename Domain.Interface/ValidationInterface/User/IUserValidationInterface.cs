
using Domain.Entity;
using Application.DTO.Request;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public interface IUserValidationInterface
    {      
        Task<Validation> ValidateUserCreate(UserRequestCreate requestDto);
    }
}
