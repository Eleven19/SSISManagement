using System;

namespace SqlServer.Management.IntegrationServices
{
    internal static class DbConnectionGuard
    {
        public static void ConnectionMustNotBeNull(this IRequireDbConnection self)
        {
            if (self == null) throw new ArgumentNullException("self");
            if(self.Connection == null) throw new InvalidOperationException("The operation requires a non-null database connection.");
        }
    }
}