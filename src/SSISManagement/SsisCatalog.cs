using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisCatalog : ISsisCatalog
    {        
        internal static readonly Regex ConnectionStringNameSpecificationRegex 
            = new Regex(@"^\s*(?<key>name)\s*=\s*(?<value>.*)", RegexOptions.Compiled);

        private static Func<string, string> _connectionStringByNameResolver =
            name =>
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[name];
                if (connectionStringSettings == null)
                {
                    throw new KeyNotFoundException("Could not locate a connection string by the name of '"
                                                   + name 
                                                   + "' in the application's configuration. " 
                                                   + "Make sure the connection name exists in app.config or web.config.");
                }
                return connectionStringSettings.ConnectionString;
            }; 

        private readonly IDbConnection _connection;

        public SsisCatalog():this("name=SSISDB")
        {            
        }
        public SsisCatalog(string connectionStringOrName)
        {
            if (connectionStringOrName == null) 
                throw new ArgumentNullException("connectionStringOrName");
            if (string.IsNullOrWhiteSpace(connectionStringOrName)) 
                throw new ArgumentException("The connectStringOrName parameter must be provided with a non-empty value.");
            _connection = GetConnectionByConnectionStringOrName(connectionStringOrName);
        }

        public static Func<string, string> GetConnectionStringByName
        {
            get { return _connectionStringByNameResolver; }
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

        public static void SetConnectionStringByNameResolver(Func<string, string> resolver)
        {
            if (resolver == null) throw new ArgumentNullException("resolver");
            _connectionStringByNameResolver = resolver;
        }

        public IDbConnection GetConnectionByConnectionStringOrName(string connectionStringOrName)
        {
            var match = ConnectionStringNameSpecificationRegex.Match(connectionStringOrName);
            if (match.Success)
            {
                var name = match.Groups["name"].Value;
                var connectString = GetConnectionStringByName(name);
                return new SqlConnection(connectString);
            }
            return new SqlConnection(connectionStringOrName);
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
