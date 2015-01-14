using System;
using System.Data;

namespace SqlServer.Management.IntegrationServices
{
    internal class DeployedProjectFacade : ProjectFacadeBase, IDeployedProject
    {
        private IDbConnection _connection;
        public DeployedProjectFacade(string folder, string name) : base(folder, name)
        {
        }

        public long ExecutePackage(string packageName)
        {
            this.ConnectionMustNotBeNull();
            throw new System.NotImplementedException();
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public void SetConnection(IDbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }
    }
}