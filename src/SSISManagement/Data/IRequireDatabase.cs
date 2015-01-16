using System.Data;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface IRequireDatabase : IDbAccessor
    {
    }

    public interface IDbAccessor
    {
        IDbConnection GetConnection();
    }
}