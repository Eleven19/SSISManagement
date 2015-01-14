using System;
using System.Data;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisCatalog : ISsisCatalog
    {        
        private readonly IDbConnection _connection;

        public SsisCatalog(string connectionStringOrName)
        {
            
        }

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

        public SsisDatabase Database
        {
            get { throw new NotImplementedException(); }
        }
    }
}
