namespace SqlServer.Management.IntegrationServices
open System
open FSharp.Data
open SqlServer.Management.IntegrationServices.Data



[<AutoOpen>]
module DataAccess = 
  open FSharp.Data

  [<Literal>]
  let SSISDbConnectionStringOrName = "name=SSISDB"

  type SSISDb = SqlProgrammabilityProvider<SSISDbConnectionStringOrName>
                
 
type CatalogDataService (connectionStringProvider:IConnectionStringProvider) =
  member this.ExecutePackage folderName projectName packageName =
    let cmd = new SSISDb.catalog.create_execution()