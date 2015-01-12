namespace SqlServer.Management.IntegrationServices

/// Documentation for my library
///
/// ## Example
///
///     let h = Library.hello 1
///     printfn "%d" h
///
[<AutoOpen>]
module DataAccess = 
  open FSharp.Data

  [<Literal>]
  let ConnectionStringOrName = "name=SSISDB"

  type SSISDb = SqlProgrammabilityProvider<ConnectionStringOrName>
