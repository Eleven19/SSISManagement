module SqlServer.Management.IntegrationServices.Tests

open SqlServer.Management.IntegrationServices
open NUnit.Framework

[<Test>]
let ``Can work with DataAccess class`` () =
  let db = new DataAccess.SSISDb()
  printfn "%A" db
  //Assert.AreEqual(42,result)
