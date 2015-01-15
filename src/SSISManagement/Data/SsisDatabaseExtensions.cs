using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public static class SsisDatabaseExtensions
    {        
        public static long CreateFolder(this ISsisDatabase db, string folderName)
        {
            return db.CreateFolder(new CreateFolderParameters(folderName));
        }

        public static long CreateExecution(this ISsisDatabase db, string folderName, string projectName,
            string packageName, long? referenceId = null, bool use32BitRuntime = false)
        {
            return db.CreateExecution(new CreateExecutionParameters(folderName, projectName, packageName, referenceId, use32BitRuntime));
        }

        public static void DeleteFolder(this ISsisDatabase db, string folderName)
        {
            db.DeleteFolder(new DeleteFolderParameters(folderName));
        }
    }
}