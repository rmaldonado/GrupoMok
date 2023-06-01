using Application.DTO.Request;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public interface IMenuValidationAplications
    {

        Task<Validation> ValidateMenu(MenuRequestCreateDto request);

        

    }
}
