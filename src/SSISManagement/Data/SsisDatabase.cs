using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Core;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;
using SqlServer.Management.IntegrationServices.Data.Dtos;

namespace SqlServer.Management.IntegrationServices.Data
{
    public abstract class SsisDatabase : ISsisDatabase
    {
        private static readonly Type ThisType = typeof (SsisDatabase);
        public abstract IDbConnection GetConnection();

        [Sql("startup", Schema = "catalog")]
        public abstract void Startup();

        [Sql("create_execution", Schema = "catalog")]
        public abstract long CreateExecution(CreateExecutionParameters parameters);

        [Sql("start_execution", Schema = "catalog")]
        public abstract int StartExecution(long executionId);

        [Sql("delete_folder", Schema = "catalog")]
        public abstract void DeleteFolder(DeleteFolderParameters parameters);

        public long CreateFolder(CreateFolderParameters parameters)
        {
            var connection = GetConnection();
            connection.Execute("catalog.create_folder", parameters);
            return parameters.FolderId;
        }

        public long ExecutePackage(ProjectInfo project, string packageName, long? referenceId = null, bool use32BitRuntime = false)
        {
            try
            {
                var connection = GetConnection();
                var createExecParams = new CreateExecutionParameters(project.Folder, project.Name, packageName,
                    referenceId, use32BitRuntime);
                var executionId = CreateExecution(createExecParams);
                return executionId;
            }
            catch (SqlException ex)
            {
                throw ex.WrapSqlException();
            }
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
