using Insight.Database;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface ISsisDatabase : IFolderRepository, ICatalogRepository, IExecutionRepository
    {        
        long ExecutePackage(ProjectInfo project, string packageName, long? referenceId = null, bool use32BitRuntime = false);
    }
}