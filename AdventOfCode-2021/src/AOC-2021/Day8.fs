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
            BottomChar: Option<char>
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

    let digitsWithLengthEqualToSix = seq { 0, 6, 9 }

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

    let getDigit signalEntry digit =
         if digitsToLengthMap.ContainsKey digit = false then
             Option.None
         else
             signalEntry.UniqueSignalPattern
                |> Seq.filter(fun x -> x.Length = digitsToLengthMap.[digit])
                |> Seq.tryItem 0

    let getDigitsWithLength signalEntry digitLength =
        signalEntry.UniqueSignalPattern
            |> Seq.filter(fun x -> x.Length = digitLength)

    let getKnownDigitCount signalEntries =
        signalEntries
            |> Seq.map(fun s -> s.FourDigitOutput)
            |> Seq.concat
            |> Seq.filter(fun x -> lengthToKnownDigitsMap.ContainsKey x.Length)
            |> Seq.length

    let getDigitalLedPositions signalEntry =
        let mapDigit = getDigit signalEntry

        let oneChars = match mapDigit 1 with | Some(x) -> Seq.toArray x | None -> Array.empty
        let sevenChars = match mapDigit 7 with | Some(x) -> Seq.toArray x | None -> Array.empty

        let signalEntriesForZeroSixAndNine = getDigitsWithLength signalEntry 6

        let ledTopRight =
            signalEntriesForZeroSixAndNine
                |> Seq.map(Seq.toList)
                |> Seq.concat
                |> Seq.countBy id
                |> Seq.filter(fun o -> snd o = 2)
                |> Seq.map(fst)
                |> Seq.filter(fun f -> oneChars |> Array.contains(f))
                |> Seq.tryItem 0
        let ledTop = sevenChars |> Array.except oneChars |> Array.tryItem 0
        let ledBottomRight = oneChars |> Seq.filter(fun f -> f <> Option.get ledTopRight) |> Seq.tryItem 0
        let ledMiddle =
            signalEntriesForZeroSixAndNine
                |> Seq.map(Seq.toList)
                |> Seq.concat
                |> Seq.countBy id
                |> Seq.filter(fun o -> snd o = 2)
                |> Seq.map(fst)
                |> Seq.filter(fun o -> Some o <> ledTopRight && Some o <> ledBottomRight)
                |> Seq.tryItem 0

        let result =
            {
                Top = ledTop
                TopRight = ledTopRight
                TopLeft = None
                Middle = ledMiddle
                BottomLeft = None
                BottomRight = ledBottomRight
                BottomChar = None
            }
            
        result

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
