using System;
using System.Data;
using System.Text.RegularExpressions;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data;

namespace SqlServer.Management.IntegrationServices
{
    public delegate string GetConnectionStringByNameDelegate(string connectionStringName);
    public class SsisCatalog : ISsisCatalog
    {        
        private static readonly Regex ConnectionStringOrNameRegex 
            = new Regex(@"^\s*(?<key>name)\s*=\s*(?<value>.*)", RegexOptions.Compiled);
        private readonly IDbConnection _connection;

        public SsisCatalog():this("name=SSISDB")
        {            
        }
        public SsisCatalog(string connectionStringOrName)
        {
            
        }

        public static GetConnectionStringByNameDelegate GetConnectionStringByName { get; set; } 

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
