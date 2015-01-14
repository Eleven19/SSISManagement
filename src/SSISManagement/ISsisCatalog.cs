using SqlServer.Management.IntegrationServices.Data;

namespace SqlServer.Management.IntegrationServices
{
    public interface ISsisCatalog
    {
        IDeployedProject GetProject(string folderName, string projectName);

        SsisDatabase Database { get; }
    }
}