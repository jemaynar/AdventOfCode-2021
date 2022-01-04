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

        let combineBits bitArrays =
            bitArrays 
                |> Seq.map(Seq.countBy(fun y -> y))
                |> Seq.map(fun x -> x |> Seq.reduce(fun accum elem -> if snd accum > snd elem then accum else elem))
                |> Seq.map(fun x -> fst x)

        let binaryArrayToNumber array =
            array
                |> Seq.indexed
                |> Seq.reduce(fun accum elem -> 
                    match fst elem with
                        | 1 -> (1, snd accum * 16uy + snd elem * 8uy)
                        | 2 -> (2, snd accum + snd elem * 4uy)
                        | 3 -> (3, snd accum + snd elem * 2uy)
                        | 4 -> (4, snd accum + snd elem * 1uy)
                        | _ -> (0, snd accum))
                |> snd
                        
    let Execute: unit =
        let pivotedLines = 
            Part1.getDay3Data
            |> Part1.mapLines 
            |> Part1.pivotLines
            |> Part1.combineBits
            |> Seq.toArray

        let numericValue =
            pivotedLines
            |> Part1.binaryArrayToNumber

        printfn "\n\nDay 3 Result:\n"

        // printfn "%A" pivotedLines

        printfn "%A" numericValue
        // Show Data
        // pivotedLines |> Seq.iter(fun(x) -> printfn "%A" x)