using Infraestructure.Data.Contexts;
using Infraestructure.Interface;
using Infraestructure.Interface.Patterns;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProdContext _context;
        public IUserRepository User { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IMessageRepository Message { get; private set; }
        public IMenuRepository Menu { get; private set; }
        public ICompanyRepository Company { get; private set; }


        public UnitOfWork(ProdContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Message = new MessageRepository(_context);
            Role = new RoleRepository(_context);
            Company = new CompanyRepository(_context);
            Menu = new MenuRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task TaskSaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
