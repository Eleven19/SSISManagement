using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SqlServer.Management.IntegrationServices.Data
{    
    public abstract class CatalogDataService
    {
        public abstract IDbConnection GetConnection();

        protected internal abstract int StartExecution(long executionId);

        public long ExecutePackage(ProjectInfo project, string packageName)
        {
            throw new NotImplementedException();
        }
    }
}
