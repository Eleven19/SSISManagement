using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public static class SsisDatabaseExtensions
    {
        public static void DeleteFolder(this SsisDatabase db, string folderName)
        {
            db.DeleteFolder(new DeleteFolderParameters(folderName));
        }

        public static long CreateFolder(this SsisDatabase db, string folderName)
        {
            return db.CreateFolder(new CreateFolderParameters(folderName));
        }
    }
}