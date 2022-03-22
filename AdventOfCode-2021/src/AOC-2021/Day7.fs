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
    
    let fuelConsumption optionCrabs =
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
                    |> Seq.map(fun c -> abs(int(c.HorizontalPosition) - int(optimalPosition)))
                    |> Seq.sum
            
            Some fuelConsumption

    module Part1 =
        let Execute: unit =
            printfn "\nDay 7 / Part 1 Result:\n"

    module Part2 =
        let Execute: unit =
            printfn "\nDay 7 / Part 1 Result:\n"

    let Execute: unit =
        Part1.Execute
        Part2.Execute
