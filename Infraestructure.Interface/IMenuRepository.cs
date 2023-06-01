using Domain.Entity.V1;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Interface.Helpers;
using System.Threading.Tasks;

namespace Infraestructure.Interface
{
    public interface IMenuRepository : IGenericRepository<Menu> {
        Task<BaseEntityResponse<Menu>> ListUsersFilters(BaseFiltersRequest filters);
    }
}
