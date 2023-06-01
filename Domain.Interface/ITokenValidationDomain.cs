
using Application.DTO;
using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Controller
{
    public interface ITokenValidationDomain
    {
        Task<string> TokenValidate(List<DataItem> listHeader, string Name, string UserId);
        
        Task<Validation> ValidateTokenField(List<DataItem> listHeader);
      
    }
}
