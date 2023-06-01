using Domain.Entity.V1;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Data.Contexts;
using Infraestructure.Interface;
using Infraestructure.Repository.Helpers;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository {

        private readonly ProdContext _context;
        public MessageRepository(ProdContext context) : base(context) {
            _context = context;
        }

        public async Task<BaseEntityResponse<Message>> ListarMessage() {
            var response = new BaseEntityResponse<Message>();

            return response;
        }
    }
}
