using Domain.Entity.V1;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Interface.Helpers;
using System.Threading.Tasks;

namespace Infraestructure.Interface
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<bool> RoleExists(Role role);
        Task<BaseEntityResponse<Role>> ListRolesFilters(BaseFiltersRequest filters);

    }
}
