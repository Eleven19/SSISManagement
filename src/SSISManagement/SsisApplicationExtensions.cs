using System;

namespace SqlServer.Management.IntegrationServices
{
    public static class SsisApplicationExtensions
    {
        public static ISsisCatalog GetCatalog(this ISsisApplication application, string connectionStringOrName)
        {
            //var connection = application.Configuration.ConnectionProvider(connectionStringOrName);
            //return application.GetCatalog(connection);
            throw new NotImplementedException();
        }
    }
}