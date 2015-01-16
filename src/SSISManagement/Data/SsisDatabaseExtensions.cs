using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public static class SsisDatabaseExtensions
    {        
        
        public static long CreateExecution(this ISsisDatabase db, string folderName, string projectName,
            string packageName, long? referenceId = null, bool use32BitRuntime = false)
        {
            return db.CreateExecution(new CreateExecutionParameters(folderName, projectName, packageName, referenceId, use32BitRuntime));
        }
    }
}