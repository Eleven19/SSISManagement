using System.Data;

namespace SqlServer.Management.IntegrationServices
{
    public interface ISsisApplication
    {
        SsisConfiguration Configuration { get; }
        ISsisCatalog GetCatalog(IDbConnection connection);
    }
}