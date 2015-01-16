﻿using System.Collections.Generic;
using Insight.Database;
using SqlServer.Management.IntegrationServices.Data.Catalog.Parameters;
using SqlServer.Management.IntegrationServices.Data.Dtos;

namespace SqlServer.Management.IntegrationServices.Data
{
    public interface ISsisDatabase : IFolderRepository
    {
        void Startup();
        long CreateExecution(CreateExecutionParameters parameters);
        long ExecutePackage(ProjectInfo project, string packageName, long? referenceId = null, bool use32BitRuntime = false);
        int StartExecution(long executionId);
        IList<CatalogProperty> GetCatalogProperties();
    }
}