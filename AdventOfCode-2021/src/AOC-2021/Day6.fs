module Day6
    open System
    open System.Collections.Generic
    
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
        if lanternFish = Seq.empty || times = 0 then
            Seq.empty
        elif times = 1 then
            lanternFish |> spawnLanternFish
        else
            (lanternFish, 0)
                |> Seq.unfold (fun state ->
                    if snd state >= times then
                        None
                    else
                        let lanternFishResult = fst state |> spawnLanternFish
                        let iteration = snd state + 1
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
                    |> spawnLanternFishTimes <| 80
                    |> Seq.length

            printfn "Total # of lanternfish after 80 spans: %A" <| totalNumberOfFish

    module Part2 =
        let toLanternFishDictionary (lanternfishOption: Option<seq<LanternFish>>): Dictionary<byte, uint64> =
            let lanternFishSeq = lanternfishOption |> Option.defaultValue(Seq.empty)
            if lanternFishSeq = Seq.empty then
                Dictionary<byte, uint64>()
            else
                let lanternFishDictionary = Dictionary<byte, uint64>()
                lanternFishSeq
                    |> Seq.groupBy(fun x -> x.DaysUntilSpawn)
                    |> Seq.iter(fun x -> lanternFishDictionary.[fst x] <- uint64((snd x |> Seq.length)))
                lanternFishDictionary

        let spawnLanternFish (lanternFishDictionary: Dictionary<byte, uint64>): Dictionary<byte, uint64> =
            if lanternFishDictionary.Count = 0 then
                Dictionary<byte, uint64>()
            else
                if lanternFishDictionary.ContainsKey(0uy) && lanternFishDictionary.ContainsKey(7uy) then
                    lanternFishDictionary.[7uy] <- lanternFishDictionary[7uy] + lanternFishDictionary[0uy]
                elif lanternFishDictionary.ContainsKey(0uy) then
                    lanternFishDictionary.[7uy] <- lanternFishDictionary[0uy]
                lanternFishDictionary.Keys
                    |> Seq.map(fun k ->
                        match k with
                        | 8uy -> (7uy, lanternFishDictionary[8uy])
                        | 7uy -> (6uy, lanternFishDictionary[7uy])
                        | 6uy -> (5uy, lanternFishDictionary[6uy])
                        | 5uy -> (4uy, lanternFishDictionary[5uy])
                        | 4uy -> (3uy, lanternFishDictionary[4uy])
                        | 3uy -> (2uy, lanternFishDictionary[3uy])
                        | 2uy -> (1uy, lanternFishDictionary[2uy])
                        | 1uy -> (0uy, lanternFishDictionary[1uy])
                        | _ -> (8uy, lanternFishDictionary[0uy]))
                    |> dict
                    |> Dictionary

        let spawnLanternFishTimes (lanternFish: Dictionary<byte, uint64>) times =
            if lanternFish.Count = 0 || times = 0 then
                Dictionary<byte, uint64>()
            elif times = 1 then
                lanternFish |> spawnLanternFish
            else
                (lanternFish, 0)
                    |> Seq.unfold (fun state ->
                        if snd state >= times then
                            None
                        else
                            let lanternFishResult = fst state |> spawnLanternFish
                            let iteration = snd state + 1
                            Some (lanternFishResult, (lanternFishResult, iteration)))
                    |> Seq.last

        let Execute: unit =
            printfn "\nDay 5 / Part 2 Result:\n"

            let totalNumberOfFish =
                Common.getData ".\Data\input6.txt"
                    |> Seq.head
                    |> parseLanternFish
                    |> toLanternFishDictionary
                    |> spawnLanternFishTimes <| 256
                    |> Seq.sumBy(fun x -> x.Value)

            printfn "Total # of lanternfish after 256 spans: %A" <| totalNumberOfFish

    let Execute: unit =
        Part1.Execute
        Part2.Execute
