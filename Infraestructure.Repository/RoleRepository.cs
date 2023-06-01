using Domain.Entity.V1;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Data.Contexts;
using Infraestructure.Interface;
using Infraestructure.Repository.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ProdContext _context;
        public RoleRepository(ProdContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Role>> ListRolesFilters(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Role>();

            var roles = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        roles = roles.Where(x => x.Description!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.StateFilter is not null)
            {
                roles = roles.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                roles = roles.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await roles.CountAsync();
            response.Items = await Ordering(filters, roles, !(bool)filters.Download!).ToListAsync();
            return response;
        }

        public Task<bool> RoleExists(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
