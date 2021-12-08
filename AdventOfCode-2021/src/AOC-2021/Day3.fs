module Day3
    open System

    let Execute: unit =
        let lines = System.IO.File.ReadLines(".\Data\input3.txt")

        let mappedLines = 
            lines 
            |> Seq.map(fun line -> line.ToCharArray())
            |> Seq.map(fun (charArray) -> 
                charArray 
                    |> Seq.map(fun x -> 
                        match x with 
                            | '1' -> 1uy 
                            | _ -> 0uy ))

        // Thank you stack overflow!
        let pivotedLines =
            mappedLines 
                |> Seq.collect Seq.indexed
                |> Seq.groupBy fst
                |> Seq.map (snd >> Seq.map snd)
            
        printfn "\n\nDay 3 Result:\n"

        // Show Data
        pivotedLines |> Seq.iter(fun(x) -> printfn "%A" x)