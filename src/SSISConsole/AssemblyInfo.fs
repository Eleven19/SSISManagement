namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("SSISConsole")>]
[<assembly: AssemblyProductAttribute("SqlServer.Management.IntegrationServices")>]
[<assembly: AssemblyDescriptionAttribute("SQL Server Integration Services management library for executing and working with SSIS packages located in the integration services catalog.")>]
[<assembly: AssemblyVersionAttribute("0.0.1")>]
[<assembly: AssemblyFileVersionAttribute("0.0.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.1"
