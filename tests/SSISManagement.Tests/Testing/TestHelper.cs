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
    }
}