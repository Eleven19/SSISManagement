using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

namespace SqlServer.Management.IntegrationServices.Data
{
    public static class SsisDatabaseExtensions
    {
        public static void DeleteFolder(this SsisDatabase db, string folderName)
        {
            db.DeleteFolder(new DeleteFolderParameters(folderName));
        }
    }
}