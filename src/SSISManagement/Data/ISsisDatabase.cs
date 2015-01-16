using Insight.Database;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface ISsisDatabase : IFolderRepository, ICatalogRepository, IExecutionRepository
    {
    }
}