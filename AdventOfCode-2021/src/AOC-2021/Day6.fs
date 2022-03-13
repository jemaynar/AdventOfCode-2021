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

    let spawnLanternFish (lanternFish: seq<LanternFish>): seq<LanternFish> =
        if lanternFish = Seq.empty then
            Seq.empty
        else
            lanternFish
                |> Seq.map(fun f ->
                    match f.DaysUntilSpawn with
                        | 8uy -> seq { { DaysUntilSpawn = 7uy } }
                        | 7uy -> seq { { DaysUntilSpawn = 6uy } }
                        | 6uy -> seq { { DaysUntilSpawn = 5uy } }
                        | 5uy -> seq { { DaysUntilSpawn = 4uy } }
                        | 4uy -> seq { { DaysUntilSpawn = 3uy } }
                        | 3uy -> seq { { DaysUntilSpawn = 2uy } }
                        | 2uy -> seq { { DaysUntilSpawn = 1uy } }
                        | 1uy -> seq { { DaysUntilSpawn = 0uy } }
                        | _ -> seq { { DaysUntilSpawn = 6uy }; { DaysUntilSpawn = 8uy } })
                |> Seq.concat

    let spawnLanternFishTimes lanternFish times =
        if lanternFish = Seq.empty || times = 0uy then
            Seq.empty
        elif times = 1uy then
            lanternFish |> spawnLanternFish
        else
            (lanternFish, 0uy)
                |> Seq.unfold (fun state ->
                    if snd state >= times then
                        None
                    else
                        let lanternFishResult = fst state |> spawnLanternFish
                        let iteration = snd state + 1uy
                        Some (lanternFishResult, (lanternFishResult, iteration)))
                |> Seq.last

    module Part1 =
        let Execute: unit =
            printfn "\nDay 5 / Part 1 Result:\n"

            let totalNumberOfFish =
                Common.getData ".\Data\input6.txt"
                    |> Seq.head
                    |> parseLanternFish
                    |> Option.defaultValue(Seq.empty)
                    |> spawnLanternFishTimes <| 80uy
                    |> Seq.length

            printfn "Total # of lanternfish after 80 spans: %A" <| totalNumberOfFish

    module Part2 =
        let Execute: unit =
           printfn "\nDay 5 / Part 2 Result:\n"

    let Execute: unit =
        Part1.Execute
        Part2.Execute