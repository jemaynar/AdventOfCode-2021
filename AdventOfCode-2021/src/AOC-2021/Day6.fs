module Day6
    open System
    
    type LanternFish = { DaysUntilSpawn: byte; }

    let parseLanternFish inputLine =
        if inputLine |> String.IsNullOrWhiteSpace then
            Option.None
        else
            let numberArray = inputLine.Split ","
            if numberArray.Length = 0 then
                Option.None
            else
                let lanternFish =
                    numberArray
                        |> Seq.map(fun i -> { DaysUntilSpawn = i |> Convert.ToByte })
                Some lanternFish

    let spawnLanternFish (lanternFish): seq<LanternFish> =
        if lanternFish = Seq.empty then
            Seq.empty
        else
            seq {
                { DaysUntilSpawn = 5uy; }
            }

    module Part1 =
        let Execute: unit =
           printfn "\nDay 5 / Part 1 Result:\n"

    module Part2 =
        let Execute: unit =
           printfn "\nDay 5 / Part 2 Result:\n"

    let Execute: unit =
        Part1.Execute
        Part2.Execute