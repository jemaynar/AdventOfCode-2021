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
    
    let fuelConsumption optionCrabs crabConsumption =
        if optionCrabs |> Option.defaultValue Seq.empty = Seq.empty then
            None
        else
            let sortedCrabs =
                optionCrabs 
                    |> Option.defaultValue Seq.empty
                    |> Array.ofSeq
                    |> Array.sort
            let optimalPosition = sortedCrabs.[sortedCrabs.Length / 2].HorizontalPosition
            let fuelConsumption =
                sortedCrabs
                    |> Seq.map(fun c -> crabConsumption c optimalPosition)
                    |> Seq.sum
            
            Some fuelConsumption

    let getTriangleNumber nth =
        nth

    module Part1 =
        let getCrabConsumption crab optimalPosition =
            abs(int(crab.HorizontalPosition) - int(optimalPosition))

        let Execute: unit =
            printfn "\nDay 7 / Part 1 Result:\n"

            let fuelConsumption =
                Common.getData(".\Data\input7.txt")
                    |> Seq.head
                    |> parseCrabs
                    |> fuelConsumption <| getCrabConsumption
                    |> Option.defaultValue 0

            printfn "\nFuel Consumption: %t" <| Common.printReadableNumber fuelConsumption

    module Part2 =
        let Execute: unit =
            printfn "\nDay 7 / Part 2 Result:\n"

        let getCrabConsumption crab optimalPosition =
            abs(int(crab.HorizontalPosition) - int(optimalPosition))

        let fuelConsumption =
            Common.getData(".\Data\input7.txt")
                |> Seq.head
                |> parseCrabs
                |> fuelConsumption <| getCrabConsumption
                |> Option.defaultValue 0

        printfn "\nFuel Consumption: %t" <| Common.printReadableNumber fuelConsumption

    let Execute: unit =
        Part1.Execute
        Part2.Execute
