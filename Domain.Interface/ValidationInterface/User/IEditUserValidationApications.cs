using Application.DTO.Request;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public interface IEditUserValidationApications
    {
        Task<Validation> ValidateUserCreate(UserRequestEdit request);

    }
}
