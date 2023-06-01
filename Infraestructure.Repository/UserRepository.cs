
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ProdContext _context;
        public UserRepository(ProdContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> AccountByUserName(string userName)
        {
            var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName!.Equals(userName));

            return account ?? throw new InvalidOperationException();
        }

        public async Task<BaseEntityResponse<User>> ListUsersFilters(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<User>();

            var users = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null)
                .AsNoTracking();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        users = users.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        users = users.Where(x => x.Email!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.StateFilter is not null)
            {
                users = users.Where(x => x.State.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                users = users.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await users.CountAsync();
            response.Items = await Ordering(filters, users, !(bool)filters.Download!).ToListAsync();
            return response;
        }
    }
}
