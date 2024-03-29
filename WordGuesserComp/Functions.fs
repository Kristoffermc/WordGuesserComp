﻿module WordGuesser.Functions

open WordGuesser.Config
   
let rec listToString aList =
    match aList with
    [] -> ""
    |h::t -> h.ToString() + listToString t
    
let guess (name: string) (used: string list) =
    let result = [| for i in 0..name.Length-1 -> Config.HIDDEN |]
    for u in used do
        let mutable pos = 0
        let mutable index = name.IndexOf(u)
        while index >= pos do
            if index >= 0 then
                for i in 0..u.Length-1 do
                    result.[index+i] <- u.[i]
            pos <- pos + 1
            index <- name.Substring(pos).IndexOf(u) + pos

    listToString (Array.toList result)

let help answer used =
    let h = guess answer used
    (answer.[h.IndexOf(Config.HIDDEN)]).ToString()
