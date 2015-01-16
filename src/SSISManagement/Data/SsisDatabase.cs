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

        public long CreateExecution(string folderName, string projectName,
            string packageName, long? referenceId = null, bool use32BitRuntime = false, int? commandTimeout=null)
        {
            return this.WithConnection(conn =>
            {
                dynamic parameters = new FastExpando();
                parameters.folder_name = folderName;
                parameters.project_name = projectName;
                parameters.package_name = packageName;
                parameters.reference_id = referenceId;
                parameters.use32bitruntime = use32BitRuntime;
                parameters.execution_id = default(long?);
                conn.Execute("catalog.create_execution", (FastExpando)parameters, commandTimeout: commandTimeout);
                return parameters.execution_id;
            });
        }

        public long CreateExecution(CreateExecutionParameters parameters)
        {
            var connection = GetConnection();
            connection.Execute("catalog.create_execution", parameters);
            return parameters.ExecutionId;
        }

        [Sql("start_execution", Schema = "catalog")]
        public abstract int StartExecution(long executionId);

        /// <summary>
        /// Creates a folder in the Integration Services catalog.
        /// </summary>
        /// <param name="folderName">The name of the new folder.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>The folder identifier is returned.</returns>
        /// <exception cref="ArgumentNullException">The value of 'database' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public long CreateFolder(string folderName, int? commandTimeout = null)
        {
            return this.WithConnection(conn =>
            {
                dynamic parameters = new FastExpando();
                parameters.folder_name = folderName;
                parameters.folder_id = default(int);
                conn.Execute("catalog.create_folder", (object)parameters, commandTimeout: commandTimeout);
                return parameters.folder_id;
            });
        }

        /// <summary>
        /// Deletes a folder from the Integration Services catalog.
        /// </summary>
        /// <param name="folderName">The name of the folder that is to be deleted.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        public void DeleteFolder(string folderName, int? commandTimeout = null)
        {
            this.WithConnection(conn =>
            {
                conn.Execute("catalog.create_folder"
                    , new { folder_name = folderName }
                    , commandTimeout: commandTimeout);
            });
        }

        public long ExecutePackage(ProjectInfo project, string packageName, long? referenceId = null, bool use32BitRuntime = false)
        {
            try
            {
                var executionId = CreateExecution(project.Folder, project.Name, packageName,
                    referenceId, use32BitRuntime);;
                
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
