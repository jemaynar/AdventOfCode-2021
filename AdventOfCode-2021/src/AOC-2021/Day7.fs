module Day7
    open System

    type Crab = { HorizontalPosition: uint16 }

    let parseCrabs inputLine =
        if inputLine |> String.IsNullOrWhiteSpace then
            Option.None
        else
            let numberArray = inputLine.Split ","
            if numberArray.Length = 0 then
                Option.None
            else
                let crabs =
                    numberArray
                        |> Seq.map(fun i -> { HorizontalPosition = i |> Convert.ToUInt16 })
                Some crabs

    let getMedian (sortedCrabs: Crab[]) =
        seq {
            int(sortedCrabs.[sortedCrabs.Length / 2].HorizontalPosition)            
        }

    let getAverage (sortedCrabs: Crab[]) =
        let total = sortedCrabs |> Array.sumBy(fun f -> int(f.HorizontalPosition))
        let avg = float(total) / float(sortedCrabs.Length)
        let ceiling = avg |> Math.Ceiling |> int
        let floor = avg |> Math.Floor |> int
        if ceiling = floor then
            seq [| ceiling |]
        else 
            [|
                floor
                ceiling
            |]

    let rec fuelConsumption optionCrabs crabConsumption optimalPosition =
        if optionCrabs |> Option.defaultValue Seq.empty = Seq.empty then
            None
        else
            let sortedCrabs =
                optionCrabs
                    |> Option.defaultValue Seq.empty
                    |> Array.ofSeq
                    |> Array.sort
            let optimalPosition = optimalPosition <| sortedCrabs

            let fuelConsumption =
                optimalPosition
                    |> Seq.map(fun potentialOptimal ->
                        sortedCrabs
                            |> Seq.map(fun c -> crabConsumption c potentialOptimal)
                            |> Seq.sum)
                    |> Seq.min

            Some fuelConsumption

    let getTriangleNumber nth =
        nth * (nth + 1) / 2

    module Part1 =
        let getCrabConsumption crab optimalPosition =
            abs(int(crab.HorizontalPosition) - int(optimalPosition))

        let Execute: unit =
            printfn "\nDay 7 / Part 1 Result:"

            let fuelConsumption =
                Common.getData(".\Data\input7.txt")
                    |> Seq.head
                    |> parseCrabs
                    |> fuelConsumption <| getCrabConsumption <| getMedian
                    |> Option.defaultValue 0

            printfn "\nFuel Consumption: %t" <| Common.printReadableNumber fuelConsumption

    module Part2 =
        let Execute: unit =
            printfn "\nDay 7 / Part 2 Result:"

        let getCrabConsumption crab optimalPosition =
            getTriangleNumber <| abs(int(crab.HorizontalPosition) - int(optimalPosition))

        let fuelConsumption =
            Common.getData(".\Data\input7.txt")
                |> Seq.head
                |> parseCrabs
                |> fuelConsumption <| getCrabConsumption <| getAverage
                |> Option.defaultValue 0

        printfn "\nFuel Consumption: %t" <| Common.printReadableNumber fuelConsumption

    let Execute: unit =
        Part1.Execute
        Part2.Execute
