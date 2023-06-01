using Application.DTO.Request;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public interface IEditCompanysValidationsAplications
    {
        Task<Validation> ValidateCompanysEdit(CompanyRequestEditDto request);
    }
}
