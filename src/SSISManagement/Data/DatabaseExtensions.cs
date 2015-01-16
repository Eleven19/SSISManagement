using System;
using System.Data;

namespace SqlServer.Management.IntegrationServices.Data
{
    /// <summary>
    /// Provides extension methods on the <see cref="IDatabase"/> interface.
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Calls the <see cref="callback"/> delegate passing in the <see cref="IDbConnection"/> used by the <see cref="IDatabase"/>
        /// </summary>
        /// <param name="database"></param>
        /// <param name="callback"></param>
        /// <exception cref="ArgumentNullException">The value of 'database' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public static void WithConnection(this IDatabase database, Action<IDbConnection> callback)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (callback == null) throw new ArgumentNullException("callback");
            var connection = database.GetConnection();
            callback(connection);
        }

        /// <summary>
        /// Calls the <see cref="callback"/> delegate passing in the <see cref="IDbConnection"/> used by the <see cref="IDatabase"/>
        /// instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The value of 'database' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public static T WithConnection<T>(this IDatabase database, Func<IDbConnection, T> callback)
        {
            if (database == null) throw new ArgumentNullException("database");
            if (callback == null) throw new ArgumentNullException("callback");
            var connection = database.GetConnection();
            return callback(connection);
        }
    }
}