open System
open SSISConsole.CommandLine
open Nessos.UnionArgParser

[<EntryPoint>]
let main argv = 
    let commandLine = 
        argv |> Array.toList |> parseCommandLine
    printfn "%A" argv
    0 // return an integer exit code
