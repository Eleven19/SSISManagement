module SqlServer.Management.IntegrationServices.Tests

open SqlServer.Management.IntegrationServices
open NUnit.Framework
open SqlServer.Management.IntegrationServices.DataAccess

[<Test>]
let ``Can work with DataAccess class`` () =
  let cmd = new SSISDb.catalog.get_project()
  printfn "%A" cmd
  //Assert.AreEqual(42,result)
