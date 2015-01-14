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
    public abstract class SsisDatabase : IDatabase
    {
        public abstract IDbConnection GetConnection();

        public abstract long CreateExecution(CreateExecutionParameters parameters);
        public abstract int StartExecution(long executionId);

        public abstract void DeleteFolder(DeleteFolderParameters parameters);

        public long ExecutePackage(ProjectInfo project, string packageName)
        {
            throw new NotImplementedException();
        }
    }
}
