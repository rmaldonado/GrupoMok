using Domain.Entity.V1;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Interface.Helpers;
using System.Threading.Tasks;

namespace Infraestructure.Interface
{
    public interface IMessageRepository : IBaseRepository<Message> 
    {
        Task<BaseEntityResponse<Message>> ListarMessage();
    }
}