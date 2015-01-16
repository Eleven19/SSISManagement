using System;
using System.Data;

namespace SqlServer.Management.IntegrationServices.Data
{
    /// <summary>
    /// Provides extension methods on the <see cref="IRequireDatabase"/> interface.
    /// </summary>
    public static class DataAccessExtensions
    {
        /// <summary>
        /// Calls the <see cref="callback"/> delegate passing in the <see cref="IDbConnection"/> used by the <see cref="IRequireDatabase"/>
        /// </summary>
        /// <param name="requireDatabase"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">The value of 'requireDatabase' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public static void WithConnection(this IRequireDatabase requireDatabase, Action<IDbConnection> callback)
        {
            if (requireDatabase == null) throw new ArgumentNullException("requireDatabase");
            if (callback == null) throw new ArgumentNullException("callback");
            var connection = requireDatabase.GetConnection();
            callback(connection);
        }

        /// <summary>
        /// Calls the <see cref="callback"/> delegate passing in the <see cref="IDbConnection"/> used by the <see cref="IRequireDatabase"/>
        /// instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requireDatabase"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The value of 'requireDatabase' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public static T WithConnection<T>(this IRequireDatabase requireDatabase, Func<IDbConnection, T> callback)
        {
            if (requireDatabase == null) throw new ArgumentNullException("requireDatabase");
            if (callback == null) throw new ArgumentNullException("callback");
            var connection = requireDatabase.GetConnection();
            return callback(connection);
        }
    }
}