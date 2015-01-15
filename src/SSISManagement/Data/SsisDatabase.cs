using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Core;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface ISsisDatabase : IDatabase
    {
        [Sql("startup", Schema = "catalog")]
        void Startup();

        long CreateFolder(CreateFolderParameters parameters);
        void DeleteFolder(DeleteFolderParameters parameters);
        long CreateExecution(CreateExecutionParameters parameters);
        long ExecutePackage(ProjectInfo project, string packageName);
        IList<CatalogProperty> GetCatalogProperties();
    }

    public abstract class SsisDatabase : ISsisDatabase
    {
        private static readonly Type ThisType = typeof (SsisDatabase);
        public abstract IDbConnection GetConnection();

        [Sql("startup", Schema = "catalog")]
        public abstract void Startup();

        public abstract long CreateExecution(CreateExecutionParameters parameters);
        public abstract int StartExecution(long executionId);

        [Sql("delete_folder", Schema = "catalog")]
        public abstract void DeleteFolder(DeleteFolderParameters parameters);

        public long CreateFolder(CreateFolderParameters parameters)
        {
            var connection = GetConnection();
            connection.Execute("catalog.create_folder", parameters);
            return parameters.FolderId;
        }

        public long ExecutePackage(ProjectInfo project, string packageName)
        {
            var connection = GetConnection();
            throw new NotImplementedException();
        }

        public virtual IList<CatalogProperty> GetCatalogProperties()
        {
            var sql = GetSqlText("GetCatalogProperties.sql");
            return GetConnection().Query<CatalogProperty>(sql, commandType: CommandType.Text);
        }

        private string GetSqlText(string filename)
        {
            var resourceName = string.Format("{0}.Sql.{1}",ThisType.Namespace, filename);
            return ThisType.Assembly.GetEmbeddedTextResource(resourceName);
        }
    }    
}
