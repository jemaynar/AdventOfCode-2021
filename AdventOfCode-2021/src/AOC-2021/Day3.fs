module Day3
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
        if accum = (0, 0) then elem
        else
            if snd accum > snd elem then accum
            elif snd accum = snd elem then (1, 1)
            else elem

    let private leastCommon accum elem =
        if accum = (0, 0) then ((fst elem + 1) % 2, snd elem)
        else
            if snd accum < snd elem then ((fst accum + 1) % 2, snd accum)
            elif snd accum = snd elem then (0, 0)
            else elem

    let private combineBits bitArrays reducerFunc =
        bitArrays 
            |> Seq.map(Seq.countBy(fun y -> y))
            |> Seq.map(fun x -> x |> Seq.fold(reducerFunc) (0, 0))
            |> Seq.map(fst)

    let mostCommonBit array = 
         array |> combineBits <| mostCommon

    let leastCommonBit array = 
         array |> combineBits <| leastCommon

    let bitsToNumber sequenceOfBits =
        sequenceOfBits
            |> Seq.rev
            |> Seq.indexed
            |> Seq.reduce(fun accum elem -> (fst elem, snd accum + (if snd elem = 1 then int(2.0 ** float(fst elem)) else 0)))
            |> snd

    module Part1 =
        let Execute: unit =
            let Day3Data = getData

            let gammaRateBinary = 
                Day3Data
                    |> toSequenceOfBitArrays 
                    |> pivotSequenceOfBitArrays
                    |> mostCommonBit
                    |> Seq.toArray

            let numericGammaRate = gammaRateBinary |> bitsToNumber

            let epsilonRateBinary =
                Day3Data
                    |> toSequenceOfBitArrays
                    |> pivotSequenceOfBitArrays
                    |> leastCommonBit
                    |> Seq.toArray

            let numericEpsilonRate = epsilonRateBinary |> bitsToNumber

            let powerConsumption = numericGammaRate * numericEpsilonRate;

            // Show Data
            printfn "\nDay 3 / Part 1 Result:\n"
            gammaRateBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "Gamma Rate -> Binary: %A Numeric: %t" <| Common.printReadableNumber numericGammaRate
            epsilonRateBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "Epsilon Rate -> Binary: %A Numeric: %t" <| Common.printReadableNumber numericEpsilonRate
            printfn "Power Consumption: %t" <| Common.printReadableNumber powerConsumption

    module Part2 =
        let filterByArrayIndex arrayOfCharArrays filterIndex filterBitValue = 
            arrayOfCharArrays
                |> Seq.map(Array.ofSeq)
                |> Seq.filter(fun x -> x.[filterIndex] = filterBitValue)

        let mostCommonBits (sequenceOfBitArrays: seq<int[]>) =
            sequenceOfBitArrays
                |> pivotSequenceOfBitArrays
                |> mostCommonBit
                |> Seq.toArray

        let leastCommonBits (sequenceOfBitArrays: seq<int[]>) =
            sequenceOfBitArrays
                |> pivotSequenceOfBitArrays
                |> leastCommonBit
                |> Seq.toArray

        let calculateOxygenGeneratorRating (data: seq<int[]>) =
            (data, 0)
            |> Seq.unfold (fun tuple ->
                let dataParam = fst tuple
                let index = snd tuple
                if dataParam = Seq.empty || dataParam |> Seq.length = 1 then None
                else
                    let filterBits = dataParam |> mostCommonBits
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
                    let filterBits = dataParam |> leastCommonBits
                    let rows = filterByArrayIndex dataParam index filterBits[index]
                    Some(rows, (rows, index + 1)))
            |> Seq.last
            |> Seq.last

        let calculateLifeSupportRating oxygenGeneratorRating co2ScrubberRating =
            oxygenGeneratorRating * co2ScrubberRating

        let Execute: unit =
            printfn "\nDay 3 / Part 2 Result:\n"

            let data = getData

            let lines = data |> toSequenceOfBitArrays

            let oxygenGeneratorRatingBinary = lines |> calculateOxygenGeneratorRating
            let oxygenGeneratorRatingNumeric = oxygenGeneratorRatingBinary |> bitsToNumber            
            oxygenGeneratorRatingBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "Oxygen Generator Rating -> Binary: %A Numeric: %t" <| Common.printReadableNumber oxygenGeneratorRatingNumeric

            let co2ScrubberRatingBinary = lines |> calculateCo2ScrubberRating
            let co2ScrubberRatingNumeric = co2ScrubberRatingBinary |> bitsToNumber            
            co2ScrubberRatingBinary |> Seq.map(string) |> Seq.fold (+) "" |> printfn "CO2 Scrubber Rating -> Binary: %A Numeric: %t" <| Common.printReadableNumber co2ScrubberRatingNumeric

            let lifeSupportRating:int =
                calculateLifeSupportRating oxygenGeneratorRatingNumeric co2ScrubberRatingNumeric

            printfn "Life Support Rating: %t" <| Common.printReadableNumber lifeSupportRating

    let Execute: unit =
        Part1.Execute
        Part2.Execute
