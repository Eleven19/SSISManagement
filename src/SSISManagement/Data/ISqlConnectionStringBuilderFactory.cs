using System.Data.SqlClient;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface ISqlConnectionStringBuilderFactory
    {
        SqlConnectionStringBuilder CreateDefault();
        SqlConnectionStringBuilder CreateFromConnectionString(string connectionString);
        SqlConnectionStringBuilder CreateFromConnectionName(string connectionName);
    }
}
