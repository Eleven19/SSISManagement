using System;

namespace SqlServer.Management.IntegrationServices
{
    public abstract class ProjectFacadeBase : IProject
    {
        private readonly string _name;
        private readonly string _folder;

        protected ProjectFacadeBase(string folder, string name)
        {
            if (folder == null) throw new ArgumentNullException("folder");
            if (name == null) throw new ArgumentNullException("name");            
            _name = name;
            _folder = folder;
        }        

        public string Name
        {
            get { return _name; }
        }

        public string Folder
        {
            get { return _folder; }
        }
    }
}