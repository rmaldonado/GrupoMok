using Infraestructure.Commons.Base.Request;
using Infraestructure.Data.Contexts;
using Infraestructure.Data.Helpers;
using Infraestructure.Interface.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Helpers
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        private readonly ProdContext _context;
        private readonly DbSet<T> _entity;

        public BaseRepository(ProdContext context) {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() {

            var getAll = await _entity.AsNoTracking().ToListAsync();

            return getAll;
        }
        public async Task<T> GetByIdAsync(int id) {

            var getById = await _entity.FindAsync(id);

            return getById!;
        }
        public async Task<bool> RegisterAsync(T entity) {

            await _context.AddAsync(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> EditAsync(T entity) {

            _context.Update(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> RemoveAsync(int id) {

            T entity = await GetByIdAsync(id);

            _context.Update(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>> filter = null) {
            IQueryable<T> query = _entity;

            if (filter != null) query = query.Where(filter);

            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        }

        
    }
}
