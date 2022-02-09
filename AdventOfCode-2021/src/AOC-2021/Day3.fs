module Day3
    open System

    let getData =
        Common.getData ".\Data\input3.txt"
        
    let toArrayOfBinaryStrings (sequenceOfBitArrays: seq<int[]>) =
        sequenceOfBitArrays
            |> Seq.map(fun x -> x |> Seq.map(string) |> Seq.fold (+) "")

    let toSequenceOfBitArrays (sequenceOfBinaryStrings: seq<string>) =
        sequenceOfBinaryStrings
            |> Seq.map(fun line -> line.ToCharArray())
            |> Seq.map(fun charArray -> 
                charArray 
                    |> Array.map(fun x -> 
                        match x with 
                            | '1' -> 1 
                            | _ -> 0 ))
            
    // Thank you stack overflow!
    let pivotSequenceOfBitArrays (sequenceOfBitArrays: seq<int[]>) =
        sequenceOfBitArrays 
            |> Seq.collect Seq.indexed
            |> Seq.groupBy fst
            |> Seq.map (snd >> Seq.map snd)
            |> Seq.map(Seq.toArray)
            
    let private mostCommon accum elem =
        if snd accum > snd elem then accum
        elif snd accum = snd elem then fst elem, 1
        else elem

    let private leastCommon accum elem =
        if snd accum < snd elem then accum
        elif snd accum = snd elem then fst elem, 1
        else elem

    let private combineBits bitArrays reducerFunc =
        bitArrays 
            |> Seq.map(Seq.countBy(fun y -> y))
            |> Seq.map(fun x -> x |> Seq.reduce(reducerFunc))
            |> Seq.map(fst)

    let combineMostCommonBits array = 
         array |> combineBits <| mostCommon

    let combineLeastCommonBits array = 
         array |> combineBits <| leastCommon

    let bitsToNumber sequenceOfBits =
        sequenceOfBits
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
    
    module Part1 =                
        let Execute: unit =
            let Day3Data = getData

            let gammaRateBinary = 
                Day3Data
                    |> toSequenceOfBitArrays 
                    |> pivotSequenceOfBitArrays
                    |> combineMostCommonBits
                    |> Seq.toArray

            let numericGammaRate = gammaRateBinary |> bitsToNumber

            let epsilonRateBinary =
                Day3Data
                    |> toSequenceOfBitArrays
                    |> pivotSequenceOfBitArrays
                    |> combineLeastCommonBits
                    |> Seq.toArray

            let numericEpsilonRate = epsilonRateBinary |> bitsToNumber

            let powerConsumption = numericGammaRate * numericEpsilonRate;

            // Show Data
            printfn "\n\nDay 3 / Part 1 Result:\n"

            gammaRateBinary |> printfn "%A"
            gammaRateBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "Gamma Rate -> Binary: %A Numeric: %A" <| numericGammaRate

            epsilonRateBinary |> printfn "%A"
            epsilonRateBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "Epsilon Rate -> Binary: %A Numeric: %A" <| numericEpsilonRate

            powerConsumption |> printfn "Power Consumption: %A"

    module Part2 =
        let filterByArrayIndex arrayOfCharArrays idx filter = 
            arrayOfCharArrays
                |> Seq.map(Array.ofSeq)
                |> Seq.filter(fun x -> x.[idx] = filter)
            
        let calculateMostCommonBits (sequenceOfBitArrays: seq<int[]>) =
            sequenceOfBitArrays
                |> pivotSequenceOfBitArrays
                |> combineMostCommonBits
                |> Seq.toArray
                
        let calculateLeastCommonBits (sequenceOfBitArrays: seq<int[]>) =
            sequenceOfBitArrays
                |> pivotSequenceOfBitArrays
                |> combineLeastCommonBits
                |> Seq.toArray
                
        let calculateOxygenGeneratorRating (data: seq<int[]>) =
            (data, 0)
            |> Seq.unfold (fun tuple ->
                let dataParam = fst tuple
                let index = snd tuple
                if dataParam = Seq.empty || dataParam |> Seq.length = 1 then None
                else
                    let filterBits = dataParam |> calculateMostCommonBits
                    let rows = filterByArrayIndex dataParam index filterBits[index]
                    Some(rows, (rows, index + 1)))
            |> Seq.last
            |> Seq.last
            
        let calculateCo2ScrubberRating (data: seq<int[]>) =
            (data, 0)
            |> Seq.unfold (fun tuple ->
                let dataParam = fst tuple
                let index = snd tuple
                if dataParam = Seq.empty || dataParam |> Seq.length = 1 then None
                else
                    let filterBits = dataParam |> calculateLeastCommonBits
                    filterBits |> printfn "LeastCommonBits: %A"
                    let rows = filterByArrayIndex dataParam index filterBits[index]
                    Some(rows, (rows, index + 1)))
            |> Seq.last
            |> Seq.last
                        
        let calculateLifeSupportRating oxygenGeneratorRating co2ScrubberRating =
            oxygenGeneratorRating * co2ScrubberRating
                
        let Execute: unit =
            printfn "\n\nDay 3 / Part 2 Result:\n"

            let data = getData

            data |> Seq.toArray |> printfn "%A"

            let lines = data |> toSequenceOfBitArrays

            let oxygenGeneratorRatingBinary = lines |> calculateOxygenGeneratorRating
            let oxygenGeneratorRatingNumeric = oxygenGeneratorRatingBinary |> bitsToNumber            
            oxygenGeneratorRatingBinary |> printfn "\nOxyGenGeneratorRating: %A"
            oxygenGeneratorRatingBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "Oxygen Generator Rating -> Binary: %A Numeric: %A" <| oxygenGeneratorRatingNumeric
            
            let co2ScrubberRatingBinary = lines |> calculateCo2ScrubberRating
            let co2ScrubberRatingNumeric = co2ScrubberRatingBinary |> bitsToNumber            
            co2ScrubberRatingBinary |> printfn "\nCO2 Scrubber Rating: %A"
            co2ScrubberRatingBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "CO2 Scrubber Rating -> Binary: %A Numeric: %A" <| co2ScrubberRatingNumeric

            let lifeSupportRating:int =
                calculateLifeSupportRating oxygenGeneratorRatingNumeric co2ScrubberRatingNumeric

            lifeSupportRating |> printfn "Life Support Rating: %A"

    let Execute: unit =
        Part1.Execute
        Part2.Execute