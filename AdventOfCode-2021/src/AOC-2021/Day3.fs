module Day3
    open System

    module Part1 =
        let getDay3Data =
            System.IO.File.ReadLines(".\Data\input3.txt")

        let mapLines (lines: seq<string>) =
            lines
                |> Seq.map(fun line -> line.ToCharArray())
                |> Seq.map(fun charArray -> 
                    charArray 
                        |> Seq.map(fun x -> 
                            match x with 
                                | '1' -> 1 
                                | _ -> 0 ))

        // Thank you stack overflow!
        let pivotLines mappedLines =
            mappedLines 
                |> Seq.collect Seq.indexed
                |> Seq.groupBy fst
                |> Seq.map (snd >> Seq.map snd)

        let private mostCommon accum elem =
            if snd accum > snd elem then accum else elem

        let private leastCommon accum elem =
            if snd accum < snd elem then accum else elem

        let private combineBits bitArrays reducerFunc =
            bitArrays 
                |> Seq.map(Seq.countBy(fun y -> y))
                |> Seq.map(fun x -> x |> Seq.reduce(reducerFunc))
                |> Seq.map(fun x -> fst x)

        let combineMostCommonBits array = 
             array |> combineBits <| mostCommon

        let combineLeastCommonBits array = 
             array |> combineBits <| leastCommon

        let bitsToNumber array =
            array
                |> Seq.indexed
                |> Seq.reduce(fun accum elem -> 
                    match fst elem with
                        | 1 -> (1, snd accum * 2048 + snd elem * 1024)
                        | 2 -> (2, snd accum + snd elem * 512)
                        | 3 -> (3, snd accum + snd elem * 256)
                        | 4 -> (4, snd accum + snd elem * 128)
                        | 5 -> (4, snd accum + snd elem * 64)
                        | 6 -> (4, snd accum + snd elem * 32)
                        | 7 -> (4, snd accum + snd elem * 16)
                        | 8 -> (4, snd accum + snd elem * 8)
                        | 9 -> (4, snd accum + snd elem * 4)
                        | 10 -> (4, snd accum + snd elem * 2)
                        | 11 -> (4, snd accum + snd elem * 1)
                        | _ -> (0, snd accum))
                |> snd
                        
    let Execute: unit =
        let Day3Data = Part1.getDay3Data

        let gammaRateBinary = 
            Day3Data
            |> Part1.mapLines 
            |> Part1.pivotLines
            |> Part1.combineMostCommonBits
            |> Seq.toArray

        let numericGammaRate = gammaRateBinary |> Part1.bitsToNumber

        let epsilonRateBinary =
            Day3Data
            |> Part1.mapLines
            |> Part1.pivotLines
            |> Part1.combineLeastCommonBits
            |> Seq.toArray

        let numericEpsilonRate = epsilonRateBinary |> Part1.bitsToNumber

        let powerConsumption = numericGammaRate * numericEpsilonRate;

        // Show Data
        printfn "\n\nDay 3 Result:\n"

        gammaRateBinary |> printfn "%A"
        gammaRateBinary |> Seq.map(fun x -> string x) |> Seq.fold (+) "" |> printfn "Gamma Rate -> Binary: %A Numeric: %A" <| numericGammaRate

        epsilonRateBinary |> printfn "%A"
        epsilonRateBinary |> Seq.map(fun x -> string x) |> Seq.fold (+) "" |> printfn "Epsilon Rate -> Binary: %A Numeric: %A" <| numericEpsilonRate

        powerConsumption |> printfn "PowerConsumption: %A"
        