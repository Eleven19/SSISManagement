using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SqlServer.Management.IntegrationServices.Data
{
    public delegate string ConnectionStringLookup(string connectionStringName);
    public static class ConnectionStrings
    {        
        /// <summary>
        /// A regular expression used to detect connection string names.
        /// </summary>
        public static readonly Regex ConnectionStringNameSpecificationRegex
            = new Regex(@"^\s*(?<key>name)\s*=\s*(?<value>.*)", RegexOptions.Compiled);

        private static ConnectionStringLookup _connectionStringLookup = connectionStringName =>
        {
            var setting = ConfigurationManager.ConnectionStrings[connectionStringName];
            return setting.ConnectionString;
        };

        /// <summary>
        /// Get a delegate which can be used to lookup a connection string.
        /// </summary>
        public static ConnectionStringLookup ConnectionStringLookup
        {
            get { return _connectionStringLookup; }
        } 

        public static string GetConnectionStringResolved(string connectionStringOrName)
        {
            // Check if this is a connection name (i.e. in the format name=ConnectionStringName
            var match = ConnectionStringNameSpecificationRegex.Match(connectionStringOrName);
            if (match.Success)
            {
                var name = match.Groups["value"].Value;
                return ConnectionStringLookup(name);
            }

            // This should be a connection string
            return connectionStringOrName;
        }

        /// <summary>
        /// Set the <see cref="ConnectionStringLookup"/>.
        /// </summary>
        /// <param name="connectionStringLookup"></param>
        /// <exception cref="ArgumentNullException">The value of 'connectionStringLookup' cannot be null. </exception>
        public static void SetConnectionStringLookup(ConnectionStringLookup connectionStringLookup)
        {
            if (connectionStringLookup == null) throw new ArgumentNullException("connectionStringLookup");
            _connectionStringLookup = connectionStringLookup;
        }
    }
}
