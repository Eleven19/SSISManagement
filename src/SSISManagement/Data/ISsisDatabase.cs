using System.Collections.Generic;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;
using SqlServer.Management.IntegrationServices.Data.Dtos;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface ISsisDatabase : IDatabase
    {
        [Sql("startup", Schema = "catalog")]
        void Startup();

        long CreateFolder(CreateFolderParameters parameters);
        void DeleteFolder(DeleteFolderParameters parameters);

        [Sql("create_execution", Schema = "catalog")]
        long CreateExecution(CreateExecutionParameters parameters);
        long ExecutePackage(ProjectInfo project, string packageName, long? referenceId = null, bool use32BitRuntime = false);
        int StartExecution(long executionId);
        IList<CatalogProperty> GetCatalogProperties();
    }
}