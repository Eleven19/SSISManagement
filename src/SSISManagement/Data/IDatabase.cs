using System.Data;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface IDatabase
    {
        IDbConnection GetConnection();
    }
}