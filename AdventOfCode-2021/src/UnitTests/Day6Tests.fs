module UnitTests.Day6Tests
    open System.Collections.Generic
    open Xunit
    open Day6

    [<Fact>]
    let ``parseLanternFish: when line is empty then returns Option None`` () =
        let inputLine = System.String.Empty

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)

    [<Fact>]
    let ``parseLanternFish: when line is null then returns Option None`` () =
        let inputLine = null

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)

    [<Fact>]
    let ``parseLanternFish: when line is whitespace then returns Option None`` () =
        let inputLine = " "

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)

    [<Fact>]
    let ``parseLanternFish: when contains 1 then returns Option Some with sequence of 1 lanternFish with DaysUntilSpawn = 1`` () =
        let inputLine = "1"

        let result = inputLine |> parseLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 1uy; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)

    [<Fact>]
    let ``parseLanternFish: when contains 1,2 then returns Option Some with sequence of 1 lanternFish with DaysUntilSpawn = 1 and 1 lanternFish with DaysUntilSpan = 2`` () =
        let inputLine = "1,2"

        let result = inputLine |> parseLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)

    [<Fact>]
    let ``spawnLanternFish: when empty dictionary then returns empty dictionary`` () =
        let lanternFish = Dictionary<byte, uint64>()

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<Dictionary<byte, uint64>>(Dictionary<byte, uint64>(), result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 8 then returns a single lanternFish with DaysUntilSpan = 7`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(8uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(7uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 7 then returns a single lanternFish with DaysUntilSpan = 6`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(7uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(6uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 6 then returns a single lanternFish with DaysUntilSpan = 5`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(6uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(5uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 5 then returns a single lanternFish with DaysUntilSpan = 4`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(5uy, 1UL)

        let result = lanternFish |> spawnLanternFish
        
        let expected = Dictionary<byte, uint64>()
        expected.Add(4uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 4 then returns a single lanternFish with DaysUntilSpan = 3`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(4uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(3uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 3 then returns a single lanternFish with DaysUntilSpan = 2`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(3uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(2uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 2 then returns a single lanternFish with DaysUntilSpan = 1`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(2uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(1uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 1 then returns a single lanternFish with DaysUntilSpan = 0`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(1uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(0uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 0 then returns two lanternFish one with DaysUntilSpan = 6 and one with DaysUntilSpawn = 6`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(0uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(6uy, 1UL)
        expected.Add(8uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFish: when initial state is initial state from problem 3,4,3,1,2 then result is 2,3,2,0,1`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(3uy, 2UL)
        lanternFish.Add(4uy, 1UL)
        lanternFish.Add(1uy, 1UL)
        lanternFish.Add(2uy, 1UL)

        let result = lanternFish |> spawnLanternFish

        let expected = Dictionary<byte, uint64>()
        expected.Add(2uy, 2UL)
        expected.Add(3uy, 1UL)
        expected.Add(0uy, 1UL)
        expected.Add(1uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish is empty dictionary then result is empty dictionary`` () =
        let lanternFish = Dictionary<byte, uint64>()

        let result = lanternFish |> spawnLanternFishTimes <| 1

        Assert.Equal<Dictionary<byte, uint64>>(Dictionary<byte, uint64>(), result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 1 then result is 8,6`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(0uy, 1UL)

        let result = lanternFish |> spawnLanternFishTimes <| 1

        let expected = Dictionary<byte, uint64>()
        expected.Add(6uy, 1UL)
        expected.Add(8uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 2 then result is 7,5`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(0uy, 1UL)

        let result = lanternFish |> spawnLanternFishTimes <| 2

        let expected = Dictionary<byte, uint64>()
        expected.Add(5uy, 1UL)
        expected.Add(7uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 3 then result is 6,4`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(0uy, 1UL)

        let result = lanternFish |> spawnLanternFishTimes <| 3

        let expected = Dictionary<byte, uint64>()
        expected.Add(4uy, 1UL)
        expected.Add(6uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state from problem 3,4,3,1,2 when times equals 1 then result is 2,3,2,0,1`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(3uy, 2UL)
        lanternFish.Add(4uy, 1UL)
        lanternFish.Add(1uy, 1UL)
        lanternFish.Add(2uy, 1UL)

        let result = lanternFish |> spawnLanternFishTimes <| 1

        let expected = Dictionary<byte, uint64>()
        expected.Add(2uy, 2UL)
        expected.Add(3uy, 1UL)
        expected.Add(0uy, 1UL)
        expected.Add(1uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state from problem 3,4,3,1,2 when times equals 2 then result is 1,2,1,6,8,0`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(3uy, 2UL)
        lanternFish.Add(4uy, 1UL)
        lanternFish.Add(1uy, 1UL)
        lanternFish.Add(2uy, 1UL)

        let result = lanternFish |> spawnLanternFishTimes <| 2

        let expected = Dictionary<byte, uint64>()
        expected.Add(1uy, 2UL)
        expected.Add(2uy, 1UL)
        expected.Add(6uy, 1UL)
        expected.Add(8uy, 1UL)
        expected.Add(0uy, 1UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state from problem 3,4,3,1,2 when times equals 18 then result is 6,8,1,1,3,0,2,2,4,6,8,1,1,3,4,6,6,8,6,8,1,5,7,0,0,2`` () =
        let lanternFish = Dictionary<byte, uint64>()
        lanternFish.Add(3uy, 2UL)
        lanternFish.Add(4uy, 1UL)
        lanternFish.Add(1uy, 1UL)
        lanternFish.Add(2uy, 1UL)

        let result = lanternFish |> spawnLanternFishTimes <| 18

        let expected = Dictionary<byte, uint64>()
        expected.Add(0uy, 3UL)
        expected.Add(1uy, 5UL)
        expected.Add(2uy, 3UL)
        expected.Add(3uy, 2UL)
        expected.Add(4uy, 2UL)
        expected.Add(5uy, 1UL)
        expected.Add(6uy, 5UL)
        expected.Add(7uy, 1UL)
        expected.Add(8uy, 4UL)
        Assert.Equal<Dictionary<byte, uint64>>(expected, result)

    [<Fact>]
    let ``toLanternFishDictionary: when lanternFishSeq is Some empty then dictionary with 0 keys`` () =
        let lanternFishSeq = Some Seq.empty

        let result = lanternFishSeq |> toLanternFishDictionary

        Assert.Equal<int32>(0, result.Count)

    [<Fact>]
    let ``toLanternFishDictionary: when lanternFishSeq is None then dictionary with 0 keys`` () =
        let lanternFishSeq = None

        let result = lanternFishSeq |> toLanternFishDictionary

        Assert.Equal<int32>(0, result.Count)

    [<Fact>]
    let ``toLanternFishDictionary: when lanternFishSeq is Some with 1 item with DaysUntilSpawn = 1 then dictionary with Key 1 and Value = 1`` () =
        let lanternFishSeq =
            seq {
                { DaysUntilSpawn = 1uy; }
            }

        let result = Some lanternFishSeq |> toLanternFishDictionary

        let expected = Dictionary<byte, uint64>()
        expected.Add(1uy, 1UL)
            
        Assert.Equal<Dictionary<byte, uint64>>(
            expected,
            result)

    [<Fact>]
    let ``toLanternFishDictionary: when lanternFishSeq is Some with 2 items with DaysUntilSpawn = 1 then dictionary with Key 1 and Value 2`` () =
        let lanternFishSeq =
            seq {
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 1uy; }
            }

        let result = Some lanternFishSeq |> toLanternFishDictionary

        let expected = Dictionary<byte, uint64>()
        expected.Add(1uy, 2UL)
            
        Assert.Equal<Dictionary<byte, uint64>>(
            expected,
            result)

    [<Fact>]
    let ``toLanternFishDictionary: when lanternFishSeq is Some with 2 items with DaysUntilSpawn = 1 and 1 item with DaysUntilSpawn 2 then dictionary with Key 1 and Value 2 and Key 2 and Value 1`` () =
        let lanternFishSeq =
            seq {
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            }

        let result = Some lanternFishSeq |> toLanternFishDictionary

        let expected = Dictionary<byte, uint64>()
        expected.Add(1uy, 2UL)
        expected.Add(2uy, 1UL)
            
        Assert.Equal<Dictionary<byte, uint64>>(
            expected,
            result)

