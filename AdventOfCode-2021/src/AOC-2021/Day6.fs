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
                        | 6uy -> seq { { DaysUntilSpawn = 5uy } }
                        | 5uy -> seq { { DaysUntilSpawn = 4uy } }
                        | 4uy -> seq { { DaysUntilSpawn = 3uy } }
                        | 3uy -> seq { { DaysUntilSpawn = 2uy } }
                        | 2uy -> seq { { DaysUntilSpawn = 1uy } }
                        | 1uy -> seq { { DaysUntilSpawn = 0uy } }
                        | _ -> seq { { DaysUntilSpawn = 6uy }; { DaysUntilSpawn = 8uy } })
                |> Seq.concat

    module Part1 =
        let Execute: unit =
           printfn "\nDay 5 / Part 1 Result:\n"

    module Part2 =
        let Execute: unit =
           printfn "\nDay 5 / Part 2 Result:\n"

    let Execute: unit =
        Part1.Execute
        Part2.Execute