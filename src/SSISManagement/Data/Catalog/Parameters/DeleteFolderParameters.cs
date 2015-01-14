using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    public class DeleteFolderParameters
    {
        private readonly string _folderName;

        public DeleteFolderParameters(string folderName)
        {
            _folderName = folderName;
        }

        public string FolderName
        {
            get { return _folderName; }
        }
    }
}
