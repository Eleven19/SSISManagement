namespace SqlServer.Management.IntegrationServices.Data
{
    public interface IExecutionRepository
    {
        long CreateExecution(string folderName, string projectName,
            string packageName, long? referenceId = null, bool use32BitRuntime = false, int? commandTimeout = null);
        int StartExecution(long executionId, int? commandTimeout = null);
        long ExecutePackage(string folderName, string projectName, string packageName, long? referenceId = null, bool use32BitRuntime = false, int? commandTimeout = null);
    }
}