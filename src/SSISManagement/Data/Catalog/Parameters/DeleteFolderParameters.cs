using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    public class DeleteFolderParameters
    {
        private readonly string _folderName;

        public DeleteFolderParameters(string folderName)
        {
            _folderName = folderName;
        }

        [Column("folder_name")]
        public string FolderName
        {
            get { return _folderName; }
        }
    }
}
