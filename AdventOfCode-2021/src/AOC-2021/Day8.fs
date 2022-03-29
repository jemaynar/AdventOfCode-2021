module Day8
    open System

    type SignalEntry = { UniqueSignalPattern: string[]; FourDigitOutput: string[] }

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

    module Part1 =
        let lengthToNumberMap =
            Map[
                (2, 1)
                (3, 7)
                (4, 4)
                (7, 8)
            ]

        let Execute: unit =
            printfn "\nDay 8 / Part 1 Result:"

    module Part2 =
        let Execute: unit =
            printfn "\nDay 8 / Part 2 Result:"

    let Execute: unit =
        Part1.Execute
        Part2.Execute
