using Domain.Entity.V1;
using System.Threading.Tasks;

namespace Domain.Interface {
    public interface IMessageDomain
    {
        Task<Message> GetByCode(string code);
    }
}
