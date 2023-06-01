using System.Data;

namespace Infraestructure.Interface.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }

    }
}