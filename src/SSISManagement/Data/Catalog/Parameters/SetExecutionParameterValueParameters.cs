using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    public class SetExecutionParameterValueParameters
    {
        private readonly long _executionId;
        private readonly CatalogParameterTypes _objectType;
        private readonly string _parameterName;
        private readonly object _parameterValue;

        public SetExecutionParameterValueParameters(long executionId, CatalogParameterTypes objectType, string parameterName, object parameterValue)
        {
            _executionId = executionId;
            _objectType = objectType;
            _parameterName = parameterName;
            _parameterValue = parameterValue;
        }

        public long ExecutionId
        {
            get { return _executionId; }
        }

        public CatalogParameterTypes ObjectType
        {
            get { return _objectType; }
        }

        public string ParameterName
        {
            get { return _parameterName; }
        }

        public object ParameterValue
        {
            get { return _parameterValue; }
        }
    }
}