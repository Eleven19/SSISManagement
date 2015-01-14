using System.Data;
using SqlServer.Management.IntegrationServices.Data;

namespace SqlServer.Management.IntegrationServices
{
    public interface ISsisCatalog
    {
        IDbConnection GetConnectionByConnectionStringOrName(string connectionStringOrName);
        IDeployedProject GetProject(string folderName, string projectName);

        SsisDatabase Database { get; }
    }
}