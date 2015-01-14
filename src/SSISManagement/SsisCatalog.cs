using System;
using System.Data;
using Insight.Database;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisCatalog : ISsisCatalog
    {        
        private readonly IDbConnection _connection;

        public SsisCatalog(IDbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public IDeployedProject GetProject(string folderName, string projectName)
        {
            return new DeployedProjectFacade(folderName, projectName);
        }
    }
}
