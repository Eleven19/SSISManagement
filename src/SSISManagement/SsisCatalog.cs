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
        static SsisCatalog()
        {
            SqlInsightDbProvider.RegisterProvider();
        }
        /// <summary>
        /// A regular expression used to detect connection string names.
        /// </summary>
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
        private Lazy<SsisDatabase> _databaseAccessor;

        /// <summary>
        /// Create the catalog using the default connection string name of SSISDB.
        /// </summary>
        /// <exception cref="ArgumentException">The connectStringOrName parameter must be provided with a non-empty value.</exception>
        /// <exception cref="ArgumentNullException">The value of 'connectionStringOrName' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public SsisCatalog():this("name=SSISDB")
        {            
        }

        /// <summary>
        /// Create the catalog with the given connection string or connection string name.
        /// Connection string names are specified like the following: name=SSISDB.
        /// </summary>        
        /// <exception cref="ArgumentNullException">The value of 'connectionStringOrName' cannot be null. </exception>
        /// <exception cref="ArgumentException">The connectStringOrName parameter must be provided with a non-empty value.</exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public SsisCatalog(string connectionStringOrName)
        {
            if (connectionStringOrName == null) 
                throw new ArgumentNullException("connectionStringOrName");
            if (string.IsNullOrWhiteSpace(connectionStringOrName)) 
                throw new ArgumentException("The connectStringOrName parameter must be provided with a non-empty value.");
            _connection = GetConnectionByConnectionStringOrName(connectionStringOrName);
            _databaseAccessor = new Lazy<SsisDatabase>(()=> _connection.AsParallel<SsisDatabase>());
        }        

        /// <summary>
        /// Create the catalog using a supplied <see cref="IDbConnection"/> instance.
        /// </summary>
        /// <param name="connection"></param>
        /// <exception cref="ArgumentNullException">The value of 'connection' cannot be null. </exception>
        public SsisCatalog(IDbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }

        public static Func<string, string> GetConnectionStringByName
        {
            get { return _connectionStringByNameResolver; }
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public SsisDatabase Database
        {
            get { return Connection.AsParallel<SsisDatabase>(); }
        }

        /// <summary>
        /// Set the resolver used to get connection strings.
        /// </summary>
        /// <param name="resolver"></param>
        /// <exception cref="ArgumentNullException">The value of 'resolver' cannot be null. </exception>
        public static void SetConnectionStringByNameResolver(Func<string, string> resolver)
        {
            if (resolver == null) throw new ArgumentNullException("resolver");
            _connectionStringByNameResolver = resolver;
        }

        /// <summary>
        /// Get a connection by a connection string or connection name.
        /// </summary>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        protected virtual IDbConnection GetConnectionByConnectionStringOrName(string connectionStringOrName)
        {
            var match = ConnectionStringNameSpecificationRegex.Match(connectionStringOrName);
            if (match.Success)
            {
                var name = match.Groups["value"].Value;
                var connectString = GetConnectionStringByName(name);
                return new SqlConnection(connectString);
            }
            return new SqlConnection(connectionStringOrName);
        }

        public IDeployedProject GetProject(string folderName, string projectName)
        {
            return new DeployedProjectFacade(folderName, projectName);
        }        
    }
}
