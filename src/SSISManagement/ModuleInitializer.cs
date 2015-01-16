using Insight.Database;
using SqlServer.Management.IntegrationServices;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        //SsisConfiguration.EnsureInsightIsInitialized();
    }
}