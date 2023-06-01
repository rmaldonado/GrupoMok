using System;
using System.Threading.Tasks;

namespace Infraestructure.Interface.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaracion de interfaces
        IRoleRepository Role { get; }
        IMessageRepository Message { get; }
        IUserRepository User { get; }
        ICompanyRepository Company { get; }
        IMenuRepository Menu { get; }

        //Declaracion de comandos

        void SaveChanges();
        Task TaskSaveChangesAsync();
    }
}
