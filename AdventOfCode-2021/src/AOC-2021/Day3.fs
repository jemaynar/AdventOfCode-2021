module Day3
    open System

    module Part1 =
        let getDay3Data =
            System.IO.File.ReadLines(".\Data\input3.txt")

        let mapLines (lines: seq<string>) =
            lines 
                |> Seq.map(fun (line) -> line.ToCharArray())
                |> Seq.map(fun (charArray) -> 
                    charArray 
                        |> Seq.map(fun x -> 
                            match x with 
                                | '1' -> 1uy 
                                | _ -> 0uy ))

        // Thank you stack overflow!
        let pivotLines mappedLines =
            mappedLines 
                |> Seq.collect Seq.indexed
                |> Seq.groupBy fst
                |> Seq.map (snd >> Seq.map snd)

    let Execute: unit =
        let pivotedLines = 
            Part1.getDay3Data
            |> Part1.mapLines 
            |> Part1.pivotLines
            
        printfn "\n\nDay 3 Result:\n"

        // Show Data
        pivotedLines |> Seq.iter(fun(x) -> printfn "%A" x)