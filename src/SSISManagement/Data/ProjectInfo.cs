using System;

namespace SqlServer.Management.IntegrationServices.Data
{
    public class ProjectInfo
    {
        private readonly string _folder;
        private readonly string _name;

        public ProjectInfo(string folder, string name)
        {
            if (folder == null) throw new ArgumentNullException("folder");
            if (name == null) throw new ArgumentNullException("name");
            _folder = folder;
            _name = name;
        }

        public string Folder
        {
            get { return _folder; }
        }

        public string Name
        {
            get { return _name; }
        }

        public static ProjectInfo FromProject(IProject project)
        {
            if (project == null) return null;
            return new ProjectInfo(project.Folder, project.Name);
        }
    }
}