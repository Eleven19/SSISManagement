// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "DataAccess.fs"
open SqlServer.Management.IntegrationServices

let num = Library.hello 42
printfn "%i" num
