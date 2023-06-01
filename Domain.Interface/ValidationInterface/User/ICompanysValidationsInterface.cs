using Application.DTO.Request;
using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public interface ICompanysValidationsAplications
    {
       Task<Validation> ValidateCompanys(CompanyRequestCreateDto request);
       


    }
}
