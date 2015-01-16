using System.Configuration;
using System.Data.SqlClient;
using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Testing
{
    internal static class TestHelper
    {
        static TestHelper()
        {
            SqlInsightDbProvider.RegisterProvider();
        }
        public static SqlConnection GetSqlConnection()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SSISDB"];
            return new SqlConnection(connectionStringSettings.ConnectionString);
        }

        public static string GetConnectionString()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SSISDB"];
            return connectionStringSettings.ConnectionString;
        }

        public static SqlConnectionStringBuilder GetConnectionStringBuilder()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SSISDB"];
            return new SqlConnectionStringBuilder(connectionStringSettings.ConnectionString);
        }
    }
}