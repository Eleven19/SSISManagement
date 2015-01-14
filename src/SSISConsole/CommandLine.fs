namespace SSISConsole.CommandLine
open System
open Nessos.UnionArgParser

type ExecutePackageArguments =
    | Project of string
    | Folder of string
    | PackageName of string
    | [<Rest>] Rest of string

with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Project _ -> "the name of the project in the SSIS catalog."
            | Folder _ -> "the name of the project folder in the SSIS catalog."
            | PackageName _ -> "the name of the package to execute."
            | Rest _ -> "the rest of the command line"

[<AutoOpen>]
module CommandLine =    
    open Nessos.UnionArgParser

    let ExecutePackageCommandLineParser = UnionArgParser.Create<ExecutePackageArguments>()   
    
    let (|ExecutePackageArgs|_|) args =
        match args with
        | cmd::rest when String.Equals(cmd, "ExecutePackage", StringComparison.OrdinalIgnoreCase) -> 
            let tail = rest |> List.toArray

            let arguments = ExecutePackageCommandLineParser.Parse tail
            Some arguments
        | _ -> None

    let parseCommandLine (args: string list) =        
        match args with
        | ExecutePackageArgs arguments -> 
            arguments.Usage("usage: SSISConsole <options>\r\n<options>:")
            |> printfn "%s"
        | _ -> failwith "Invalid input"