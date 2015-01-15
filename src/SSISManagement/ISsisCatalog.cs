using System.Data;
using SqlServer.Management.IntegrationServices.Data;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices
{
    public interface ISsisCatalog
    {
        //IDbConnection GetConnectionByConnectionStringOrName(string connectionStringOrName);
        IDeployedProject GetProject(string folderName, string projectName);
        long CreateFolder(string folderName);
        void DeleteFolder(string folderName);

        SsisDatabase Database { get; }
    }
}