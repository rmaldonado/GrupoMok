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
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository {

        private readonly ProdContext _context;
        public MenuRepository(ProdContext context) : base(context) {
            _context = context;
        }
                
        public async Task<BaseEntityResponse<Menu>> ListUsersFilters(BaseFiltersRequest filters) {
            var response = new BaseEntityResponse<Menu>();

            var menus = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter)) {
                switch (filters.NumFilter) {
                    case 1:
                        menus = menus.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        menus = menus.Where(x => x.Url!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.StateFilter is not null) {
                menus = menus.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate)) {
                menus = menus.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await menus.CountAsync();
            response.Items = await Ordering(filters, menus, !(bool)filters.Download!).ToListAsync();
            return response;
        }
    }
}
