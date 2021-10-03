using System.Data;

namespace QASupporter.Application.Configuration.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();

        IDbConnection GetNewConnection();
    }
}