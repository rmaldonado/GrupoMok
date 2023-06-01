 
using System.Data;
 

namespace Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }

        IDbConnection GetConnectionAppsSettings { get; }

        IDbConnection GetConnectionLocal { get; }
    }
}
