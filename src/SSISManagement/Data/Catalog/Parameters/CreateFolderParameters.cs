using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    public class CreateFolderParameters
    {
        private readonly string _folderName;

        public CreateFolderParameters(string folderName)
        {
            _folderName = folderName;
        }

        //[Column("folder_name")]
        public string FolderName
        {
            get { return _folderName; }
        }

        [Column("folder_id")]
        public long FolderId { get; set; }
    }
}