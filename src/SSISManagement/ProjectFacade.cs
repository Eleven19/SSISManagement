namespace SqlServer.Management.IntegrationServices
{
    internal class ProjectFacade : ProjectFacadeBase, IProject
    {
        public ProjectFacade(string folder, string name) : base(folder, name)
        {
        }
    }
}