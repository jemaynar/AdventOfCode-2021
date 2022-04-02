module Day8
    open System

    type SignalEntry = { UniqueSignalPattern: string[]; FourDigitOutput: string[] }
    type DigitalLedPosition = { Top: char; TopRight: char; TopLeft: char; Middle: char; BottomLeft: char; BottomRight: char; BottomChar: char; }

    let knownDigitsLengthToNumberMap =
        Map[
            (2, 1)
            (3, 7)
            (4, 4)
            (7, 8)
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

    let getKnownDigitCount signalEntries =
        signalEntries
            |> Seq.map(fun s -> s.FourDigitOutput)
            |> Seq.concat
            |> Seq.filter(fun x -> knownDigitsLengthToNumberMap.ContainsKey x.Length)
            |> Seq.length

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
