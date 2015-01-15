using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SqlServer.Management.IntegrationServices.Core
{
    internal static class ExceptionHelper
    {
        public static Exception WrapSqlException(this SqlException sqlException)
        {
            Debug.WriteLine("ErrorCode: {0}; Number: {1}"
                , sqlException.ErrorCode
                , sqlException.Number);
            switch (sqlException.Number)
            {
                case 27146:
                    return new PackageAccessException(sqlException.Message, sqlException);
                default:
                    return sqlException;

            }            
        }
    }
}