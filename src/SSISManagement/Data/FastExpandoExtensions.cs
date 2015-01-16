using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data
{
    internal static class FastExpandoExtensions
    {
        /// <summary>
        /// Provides a flueent way to set a property on a <see cref="FastExpando"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expando"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FastExpando AddProperty<T>(this FastExpando expando, string propertyName, T value)
        {
            expando[propertyName] = value;
            return expando;
        }

        /// <summary>
        /// Adds a property using the default value for the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expando"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static FastExpando AddProperty<T>(this FastExpando expando, string propertyName)
        {
            return AddProperty(expando, propertyName, default(T));
        }
    }
}