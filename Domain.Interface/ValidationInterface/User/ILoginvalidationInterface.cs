using Application.DTO.Request;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.ValidationInterface.User
{
    public interface ILoginvalidationAplications
    {
        Task<Validation> ValidationLoguin(LoginRequestDto request);
    }
}
