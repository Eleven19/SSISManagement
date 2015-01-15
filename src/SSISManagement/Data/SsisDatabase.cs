using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface IDatabase
    {
        IDbConnection GetConnection();
    }

    public interface ISsisDatabase
    {
        [Sql("startup", Schema = "catalog")]
        void Startup();
    }

    public abstract class SsisDatabase : ISsisDatabase, IDatabase
    {
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
    }    
}
