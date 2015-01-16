using System.Data;
using System.Data.SqlClient;
using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface IDbAccessorFactory
    {
        IDbAccessor Create<TDbAccessor>(SqlConnectionStringBuilder connectionStringBuilder) where TDbAccessor: class, IDbAccessor;
    }

    internal class DbAccessorFactory : IDbAccessorFactory
    {        
        public IDbAccessor Create<TDbAccessor>(SqlConnectionStringBuilder connectionStringBuilder) where TDbAccessor : class,IDbAccessor
        {
            return connectionStringBuilder.AsParallel<TDbAccessor>();
        }
    }
}