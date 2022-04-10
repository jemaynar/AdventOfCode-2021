module Day8
    open System

    type SignalEntry = { UniqueSignalPattern: string[]; FourDigitOutput: string[] }

    type DigitalLedPosition =
        {
            Top: Option<char>
            TopRight: Option<char>
            TopLeft: Option<char>
            Middle: Option<char>
            BottomLeft: Option<char>
            BottomRight: Option<char>
            Bottom: Option<char>
        }

    let lengthToKnownDigitsMap =
        Map[
            (2, 1)
            (3, 7)
            (4, 4)
            (7, 8)
        ]

    let digitsToLengthMap =
        Map[
            (1, 2)
            (4, 4)
            (7, 3)
            (8, 7)
        ]

    let parseLine (inputLine: string) =
        if inputLine |> String.IsNullOrWhiteSpace then
            Option.None
        else
            let signalSections =
                "|" |> inputLine.Split
                |> Array.map(fun x -> x.Trim())

            let signalPattern = signalSections |> Array.head
            let signalOutput = signalSections |> Array.last
            let signal = { UniqueSignalPattern = signalPattern.Split(" ") |> Array.map(fun x -> x.Trim()); FourDigitOutput = signalOutput.Split(" ") |> Array.map(fun x -> x.Trim()) }

            Some signal

    let getKnownDigitString signalEntry digit =
        if digitsToLengthMap.ContainsKey digit then
            signalEntry.UniqueSignalPattern
                |> Seq.filter(fun x -> x.Length = digitsToLengthMap.[digit])
                |> Seq.tryItem 0
        else
            None

    let getKnownDigitChars signalEntry digit =
        let mapDigit = getKnownDigitString signalEntry
        match mapDigit digit with | Some(x) -> Seq.toArray x | None -> Array.empty

    let getDigitsWithLength signalEntry digitLength =
        signalEntry.UniqueSignalPattern
            |> Seq.filter(fun x -> x.Length = digitLength)

    let getKnownDigitCount signalEntries =
        signalEntries
            |> Seq.map(fun s -> s.FourDigitOutput)
            |> Seq.concat
            |> Seq.filter(fun x -> lengthToKnownDigitsMap.ContainsKey x.Length)
            |> Seq.length

    let mapDigitalLedPositions signalEntry =
        let oneChars = getKnownDigitChars signalEntry 1
        let fourChars = getKnownDigitChars signalEntry 4
        let sevenChars = getKnownDigitChars signalEntry 7

        let signalEntriesForZeroSixAndNine = getDigitsWithLength signalEntry 6

        let charsOccurrencesInInZeroSixAndNine times =
             signalEntriesForZeroSixAndNine
                |> Seq.map(Seq.toList)
                |> Seq.concat
                |> Seq.countBy id
                |> Seq.filter(fun o -> snd o = times)
                |> Seq.map(fst)

        let ledTopRight =
            charsOccurrencesInInZeroSixAndNine 2
                |> Seq.filter(fun f -> oneChars |> Array.contains(f))
                |> Seq.tryItem 0
        let ledTop =
            sevenChars
                |> Array.except oneChars
                |> Array.tryItem 0
        let ledBottomRight =
            oneChars
                 |> Seq.except(seq { Option.get ledTopRight })
                 |> Seq.tryItem 0
        let ledMiddle =
            charsOccurrencesInInZeroSixAndNine 2
                |> Seq.except(seq { Option.get ledTopRight; Option.get ledBottomRight })
                |> Seq.tryItem 0
        let ledTopLeft =
            fourChars
                |> Seq.except(seq { Option.get ledTopRight; Option.get ledBottomRight; Option.get ledMiddle })
                |> Seq.tryItem 0
        let ledBottomLeft =
            charsOccurrencesInInZeroSixAndNine 2
                |> Seq.except(seq { Option.get ledMiddle; Option.get ledTopRight })
                |> Seq.tryItem 0
        let ledBottom =
            charsOccurrencesInInZeroSixAndNine 3
                |> Seq.except(seq { Option.get ledBottomRight; Option.get ledTop; Option.get ledTopLeft })
                |> Seq.tryItem 0

        let result =
            {
                Top = ledTop
                TopRight = ledTopRight
                TopLeft = ledTopLeft
                Middle = ledMiddle
                BottomLeft = ledBottomLeft
                BottomRight = ledBottomRight
                Bottom = ledBottom
            }
            
        result

    let mapCharsToInt digitalLedMap digitalString =
        5

    let mapFourDigitOutputInt digitalLedMap fourDigitOutputArray =
        5353

    module Part1 =
        let Execute: unit =
            printfn "\nDay 8 / Part 1 Result:"

            let knownDigitCount =
                Common.getData ".\Data\input8.txt"
                    |> Seq.map(parseLine)
                    |> Seq.choose id
                    |> getKnownDigitCount

            printfn "\nKnown digit count: %t" <| Common.printReadableNumber knownDigitCount

    module Part2 =
        let Execute: unit =
            printfn "\nDay 8 / Part 2 Result:"

    let Execute: unit =
        Part1.Execute
        Part2.Execute
