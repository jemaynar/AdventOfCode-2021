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
                "|"
                    |> inputLine.Split
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
                |> Seq.filter(fun c -> fourChars |> Seq.contains(c))
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

    let mapCharsToInt (digitalLedMap: DigitalLedPosition) (digitalString: string) =
        let ledChars = digitalString |> Seq.toArray
        match ledChars.Length with
            | 2 | 3 | 4 | 7 -> Some lengthToKnownDigitsMap.[ledChars.Length]
            | 5 -> 
                if ledChars |> Seq.contains(Option.get digitalLedMap.BottomLeft) then Some 2
                elif ledChars |> Seq.contains(Option.get digitalLedMap.TopLeft) then Some 5
                else Some 3
            | 6 ->
                if ledChars |> Seq.contains(Option.get digitalLedMap.Middle) = false then Some 0
                elif ledChars |> Seq.contains(Option.get digitalLedMap.BottomLeft) = false then Some 9
                else Some 6
            | _ -> None

    let mapFourDigitOutputInt digitalLedMap fourDigitOutputArray =
        fourDigitOutputArray
            |> Seq.choose(fun x -> mapCharsToInt digitalLedMap x)
            |> Seq.map(fun x -> string(x))
            |> Seq.reduce(fun acc elem -> acc + elem)
            |> int

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

        let result =
            Common.getData ".\Data\input8.txt"
                |> Seq.map(parseLine)
                |> Seq.choose id
                |> Seq.map(fun se -> mapFourDigitOutputInt <| mapDigitalLedPositions se <| se.FourDigitOutput)
                |> Seq.sum

        printfn "\nSum of all output values: %t" <| Common.printReadableNumber result

    let Execute: unit =
        Part1.Execute
        Part2.Execute
