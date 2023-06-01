using Domain.Entity.V1;
using Infraestructure.Data.Contexts;
using Infraestructure.Interface;
using Infraestructure.Repository.Helpers;

namespace Infraestructure.Repository 
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly ProdContext _context;
        public CompanyRepository(ProdContext context) : base(context)
        {
            _context = context;
        }
    }
}
