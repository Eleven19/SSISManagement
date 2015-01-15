using System;
using System.Data;

namespace SqlServer.Management.IntegrationServices
{
    /// <summary>
    /// The SsisApplication is the entry point into the Integration Services Management API.
    /// </summary>
    public class SsisApplication : ISsisApplication
    {
        private readonly SsisConfiguration _configuration;

        public SsisApplication():this(new SsisConfiguration())
        {            
        }

        public SsisApplication(SsisConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            _configuration = configuration;
        }

        public SsisConfiguration Configuration
        {
            get { return _configuration; }
        }        

        public virtual ISsisCatalog GetCatalog(IDbConnection connection)
        {
            return new SsisCatalog(connection);
        }
    }
}