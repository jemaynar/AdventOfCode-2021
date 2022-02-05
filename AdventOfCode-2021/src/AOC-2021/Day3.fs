module Day3
    open System

    let getData = 
        System.IO.File.ReadLines(".\Data\input3.txt")
        
    let nestedArrayToArrayOfStrings (arrayOfArrays) =
        arrayOfArrays |> Seq.map(fun x -> x |> Seq.map(fun e -> string e) |> Seq.fold (+) "")

    module Part1 =
        let mapLines (lines: seq<string>) =
            lines
                |> Seq.map(fun line -> line.ToCharArray())
                |> Seq.map(fun charArray -> 
                    charArray 
                        |> Array.map(fun x -> 
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
            if snd accum > snd elem then accum
            elif snd accum = snd elem then fst elem, 1
            else elem

        let private leastCommon accum elem =
            if snd accum <= snd elem then accum else elem

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

    module Part2 =
        let filterByArrayIndex arrayOfCharArrays idx filter = 
            arrayOfCharArrays
            |> Seq.map(Array.ofSeq)
            |> Seq.filter(fun x -> x.[idx] = filter)
            
        let calculateMostCommonBits (arrayOfBinaryStrings) =
            arrayOfBinaryStrings
            |> Part1.mapLines
            |> Part1.pivotLines
            |> Part1.combineMostCommonBits
            |> Seq.toArray

    let Execute: unit =
        let Day3Data = getData

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
        printfn "\n\nDay 3 / Part 1 Result:\n"

        gammaRateBinary |> printfn "%A"
        gammaRateBinary |> Seq.map(fun x -> string x) |> Seq.fold (+) "" |> printfn "Gamma Rate -> Binary: %A Numeric: %A" <| numericGammaRate

        epsilonRateBinary |> printfn "%A"
        epsilonRateBinary |> Seq.map(fun x -> string x) |> Seq.fold (+) "" |> printfn "Epsilon Rate -> Binary: %A Numeric: %A" <| numericEpsilonRate

        powerConsumption |> printfn "Power Consumption: %A"

        printfn "\n\nDay 3 / Part 2 Result:\n"

        Day3Data |> printfn "%A"

        let mostCommonBits =
            Day3Data |> Part2.calculateMostCommonBits

        mostCommonBits |> printfn "\nMost Common Bits: %A"

        let lines = 
            Day3Data
            |> Part1.mapLines

        let filteredByFirstBit =
            Part2.filterByArrayIndex lines 0 mostCommonBits[0]
            |> nestedArrayToArrayOfStrings |> Seq.toArray
        
        filteredByFirstBit |> printfn "\nFiltered By First Bit of mostCommonBits: %A"

        let numericOxygenGeneratorRating = 1
        let numericCo2ScrubberRating = 1

        let lifeSupportRating = numericOxygenGeneratorRating * numericCo2ScrubberRating

        lifeSupportRating |> printfn "Life Support Rating: %A"
        