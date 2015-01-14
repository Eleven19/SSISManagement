namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    public class CreateExecutionParameters
    {
        private readonly string _folderName;
        private readonly string _projectName;
        private readonly string _packageName;
        private readonly bool _use32BitRuntime;

        public CreateExecutionParameters(string folderName, string projectName, string packageName, bool use32BitRuntime=true)
        {
            _folderName = folderName;
            _projectName = projectName;
            _packageName = packageName;
            _use32BitRuntime = use32BitRuntime;
        }

        public string FolderName
        {
            get { return _folderName; }
        }

        public string ProjectName
        {
            get { return _projectName; }
        }

        public string PackageName
        {
            get { return _packageName; }
        }

        public bool Use32BitRuntime
        {
            get { return _use32BitRuntime; }
        }

        public long ExecutionId { get; set; }
    }
}