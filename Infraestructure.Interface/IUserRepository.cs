using Domain.Entity.V1;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Interface.Helpers;
using System.Threading.Tasks;

namespace Infraestructure.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<BaseEntityResponse<User>> ListUsersFilters(BaseFiltersRequest filters);

        Task<User> AccountByUserName(string userName);
    }
}
