using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public static class SsisDatabaseExtensions
    {
        public static void DeleteFolder(this ISsisDatabase db, string folderName)
        {
            db.DeleteFolder(new DeleteFolderParameters(folderName));
        }

        public static long CreateFolder(this ISsisDatabase db, string folderName)
        {
            return db.CreateFolder(new CreateFolderParameters(folderName));
        }
    }
}