using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    public class CreateExecutionParameters
    {
        private readonly string _folderName;
        private readonly string _projectName;
        private readonly string _packageName;
        private readonly long? _referenceId;
        private readonly bool _use32BitRuntime;

        public CreateExecutionParameters(string folderName, string projectName, string packageName, long? referenceId=null, bool use32BitRuntime=false)
        {
            _folderName = folderName;
            _projectName = projectName;
            _packageName = packageName;
            _referenceId = referenceId;
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

        public long? ReferenceId
        {
            get { return _referenceId; }
        }

        [Column("use32bitruntime")]
        public bool Use32BitRuntime
        {
            get { return _use32BitRuntime; }
        }

        public long ExecutionId { get; set; }
        
    }
}