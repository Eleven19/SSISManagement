namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("SSISConsole")>]
[<assembly: AssemblyProductAttribute("SqlServer.Management.IntegrationServices")>]
[<assembly: AssemblyDescriptionAttribute("SQL Server Integration Services management library for executing and working with SSIS packages")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
