using System.Data;

namespace SqlServer.Management.IntegrationServices
{
    public interface IHaveDbConnection
    {
        IDbConnection Connection { get; }
    }

    public interface IRequireDbConnection : IHaveDbConnection
    {
        void SetConnection(IDbConnection connection);
    }

    public interface IDeployedProject : IProject, IRequireDbConnection
    {
        long ExecutePackage(string packageName);
    }
}