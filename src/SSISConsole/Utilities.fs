namespace SSISConsole

[<AutoOpen>]
module Utilities = 
    // create an active pattern
    let (|Bool|_|) str =
        match System.Boolean.TryParse(str) with
        | (true,bool) -> Some(bool)
        | _ -> None

