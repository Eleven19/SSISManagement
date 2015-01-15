using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisConfiguration
    {
        private static bool _hasInsightBeenInitialized;

        static SsisConfiguration()
        {
            EnsureInsightIsInitialized();
        }

        private Func<string, IDbConnection> _connectionProvider = connectionStringOrName =>
        {
            var connectionString = ConnectionStrings.GetConnectionStringResolved(connectionStringOrName);            
            return new SqlConnection(connectionString);
        };

        /// <summary>
        /// Gets a delegate that can be used to provide an <see cref="IDbConnection"/>.
        /// The delegate accepts a <see cref="string"/> as input. 
        /// This string should be an actual connection string or a connection string name specified in the format
        /// of "name=ConnectionName", i.e. name=SSISDB.
        /// </summary>        
        public Func<string, IDbConnection> ConnectionProvider
        {
            get { return _connectionProvider; }
        }

        internal static void EnsureInsightIsInitialized()
        {
            if (!_hasInsightBeenInitialized)
            {
                // Ensure we register the SqlInsightDbProvider
                // TODO: Consider moving this call closer to where the Insight.Database dependency is actually used
                SqlInsightDbProvider.RegisterProvider();
                ColumnMapping.Parameters.AddMapper(new SsisParameterMapper());
                _hasInsightBeenInitialized = true;
            }
        }

        /// <summary>
        /// Set the connection provider used by this configuration.
        /// </summary>
        /// <param name="connectionProvider"></param>
        /// <exception cref="ArgumentNullException">The value of 'connectionProvider' cannot be null. </exception>
        public void SetConnectionProvider(Func<string, IDbConnection> connectionProvider)
        {
            if (connectionProvider == null) throw new ArgumentNullException("connectionProvider");
            Interlocked.Exchange(ref _connectionProvider, connectionProvider);
        }
    }
}