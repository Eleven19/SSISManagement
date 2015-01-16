using System.Configuration;
using System.Data.SqlClient;

namespace SqlServer.Management.IntegrationServices.Testing
{
    public abstract class TestRequiringConnectionStrings
    {
        protected TestRequiringConnectionStrings()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["SSISDB"];
            ConnectionString = SsisdbConnectionString = connectionStringSettings.ConnectionString;
        }

        public string ConnectionString { get; protected set; }
        public string SsisdbConnectionString { get; protected set; }

        public SqlConnectionStringBuilder GetSsisDbConnectionStringBuilder()
        {
            return new SqlConnectionStringBuilder(SsisdbConnectionString);
        }
    }
}