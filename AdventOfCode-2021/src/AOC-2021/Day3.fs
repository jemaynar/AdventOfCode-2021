module Day3
    open System

    module Part1 =
        let mapLines (lines: seq<string>) =
            lines 
                |> Seq.map(fun (line) -> line.ToCharArray())
                |> Seq.map(fun (charArray) -> 
                    charArray 
                        |> Seq.map(fun x -> 
                            match x with 
                                | '1' -> 1uy 
                                | _ -> 0uy ))

        let pivotLines mappedLines =
            mappedLines 
                |> Seq.collect Seq.indexed
                |> Seq.groupBy fst
                |> Seq.map (snd >> Seq.map snd)

    let Execute: unit =
        let lines = System.IO.File.ReadLines(".\Data\input3.txt")

        let mappedLines = Part1.mapLines lines

        // Thank you stack overflow!
        let pivotedLines = Part1.pivotLines mappedLines
            
        printfn "\n\nDay 3 Result:\n"

        // Show Data
        pivotedLines |> Seq.iter(fun(x) -> printfn "%A" x)