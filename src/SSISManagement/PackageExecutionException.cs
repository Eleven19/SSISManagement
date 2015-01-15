using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SqlServer.Management.IntegrationServices
{
    [Serializable]
    public class PackageExecutionException : Exception
    {        
        public PackageExecutionException()
        {
        }

        public PackageExecutionException(string message) : base(message)
        {
        }        

        public PackageExecutionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PackageExecutionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class PackageAccessException : PackageExecutionException
    {
        public PackageAccessException()
        {
        }

        public PackageAccessException(string message)
            : base(message)
        {
        }

        public PackageAccessException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected PackageAccessException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
