using System;
using System.Data;
using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface IFolderRepository : IDatabase
    {
        /// <summary>
        /// Creates a folder in the Integration Services catalog.
        /// </summary>
        /// <param name="folderName">The name of the new folder.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>The folder identifier is returned.</returns>
        long CreateFolder(string folderName, int? commandTimeout = null);
        void DeleteFolder(string folderName, int? commandTimeout = null);
    }

    internal abstract class FolderRepository: IFolderRepository
    {
        public abstract IDbConnection GetConnection();

        /// <summary>
        /// Creates a folder in the Integration Services catalog.
        /// </summary>
        /// <param name="folderName">The name of the new folder.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>The folder identifier is returned.</returns>
        /// <exception cref="ArgumentNullException">The value of 'database' cannot be null. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public long CreateFolder(string folderName, int? commandTimeout = null)
        {
            return this.WithConnection(conn =>
            {
                dynamic parameters = new FastExpando();
                parameters.folder_name = folderName;
                parameters.folder_id = default(int);
                conn.Execute("catalog.create_folder", (object)parameters, commandTimeout: commandTimeout);
                return parameters.folder_id;
            });
        }
        public abstract void DeleteFolder(string folderName, int? commandTimeout = null);
    }
}