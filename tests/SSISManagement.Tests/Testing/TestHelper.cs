using System.Configuration;
using System.Data.SqlClient;

namespace SqlServer.Management.IntegrationServices.Testing
{
    internal static class TestHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SSISDB"];
            return new SqlConnection(connectionStringSettings.ConnectionString);
        }
    }
}