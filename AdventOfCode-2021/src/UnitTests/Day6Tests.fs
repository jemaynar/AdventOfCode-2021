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
    let ``spawnLanternFish: when Seq.empty then returns seq.Empty`` () =
        let lanternFish = Seq.empty

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(Seq.empty, result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 8 then returns a single lanternFish with DaysUntilSpan = 7`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 8uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 7uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 7 then returns a single lanternFish with DaysUntilSpan = 6`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 7uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 6uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 6 then returns a single lanternFish with DaysUntilSpan = 5`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 6uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 5uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 5 then returns a single lanternFish with DaysUntilSpan = 4`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 5uy; }
            }

        let result = lanternFish |> spawnLanternFish
        
        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 4uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 4 then returns a single lanternFish with DaysUntilSpan = 3`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 4uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 3uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 3 then returns a single lanternFish with DaysUntilSpan = 2`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 3uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 2uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 2 then returns a single lanternFish with DaysUntilSpan = 1`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 2uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 1uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 1 then returns a single lanternFish with DaysUntilSpan = 0`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 1uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 0uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when single lanternFish with DaysUntilSpawn = 0 then returns two lanternFish one with DaysUntilSpan = 6 and one with DaysUntilSpawn = 6`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 0uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 6uy; }
                { DaysUntilSpawn = 8uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFish: when initial state is initial state from problem 3,4,3,1,2 then result is 2,3,2,0,1`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 4uy; }
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            }

        let result = lanternFish |> spawnLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 2uy; }
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 2uy; }
                { DaysUntilSpawn = 0uy; }
                { DaysUntilSpawn = 1uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish is Seq.empty then result is Seq.empty`` () =
        let lanternFish = Seq.empty

        let result = lanternFish |> spawnLanternFishTimes <| 1

        Assert.Equal<seq<LanternFish>>(Seq.empty, result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 1 then result is 8,6`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 0uy; }
            }

        let result = lanternFish |> spawnLanternFishTimes <| 1

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 6uy; }
                { DaysUntilSpawn = 8uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 2 then result is 7,5`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 0uy; }
            }

        let result = lanternFish |> spawnLanternFishTimes <| 2

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 5uy; }
                { DaysUntilSpawn = 7uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 3 then result is 6,4`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 0uy; }
            }

        let result = lanternFish |> spawnLanternFishTimes <| 3

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 4uy; }
                { DaysUntilSpawn = 6uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state from problem 3,4,3,1,2 when times equals 1 then result is 2,3,2,0,1`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 4uy; }
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            }

        let result = lanternFish |> spawnLanternFishTimes <| 1

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 2uy; }
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 2uy; }
                { DaysUntilSpawn = 0uy; }
                { DaysUntilSpawn = 1uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state from problem 3,4,3,1,2 when times equals 2 then result is 1,2,1,6,8,0`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 4uy; }
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            }

        let result = lanternFish |> spawnLanternFishTimes <| 2

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 6uy; }
                { DaysUntilSpawn = 8uy; }
                { DaysUntilSpawn = 0uy; }
            },
            result)

    [<Fact>]
    let ``spawnLanternFishTimes: when initial state is initial state from problem 3,4,3,1,2 when times equals 18 then result is 6,8,1,1,3,0,2,2,4,6,8,1,1,3,4,6,6,8,6,8,1,5,7,0,0,2`` () =
        let lanternFish =
            seq {
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 4uy; }
                { DaysUntilSpawn = 3uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            }

        let result = lanternFish |> spawnLanternFishTimes <| 18

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 6uy }
                { DaysUntilSpawn = 8uy }
                { DaysUntilSpawn = 1uy }
                { DaysUntilSpawn = 1uy }
                { DaysUntilSpawn = 3uy }
                { DaysUntilSpawn = 0uy }
                { DaysUntilSpawn = 2uy }
                { DaysUntilSpawn = 2uy }
                { DaysUntilSpawn = 4uy }
                { DaysUntilSpawn = 6uy }
                { DaysUntilSpawn = 8uy }
                { DaysUntilSpawn = 1uy }
                { DaysUntilSpawn = 1uy }
                { DaysUntilSpawn = 3uy }
                { DaysUntilSpawn = 4uy }
                { DaysUntilSpawn = 6uy }
                { DaysUntilSpawn = 6uy }
                { DaysUntilSpawn = 8uy }
                { DaysUntilSpawn = 6uy }
                { DaysUntilSpawn = 8uy }
                { DaysUntilSpawn = 1uy }
                { DaysUntilSpawn = 5uy }
                { DaysUntilSpawn = 7uy }
                { DaysUntilSpawn = 0uy }
                { DaysUntilSpawn = 0uy }
                { DaysUntilSpawn = 2uy }
            },
            result)

    [<Fact>]
    let ``Part2.toLanternFishDictionary: when lanternFishSeq is Some empty then dictionary with 0 keys`` () =
        let lanternFishSeq = Some Seq.empty

        let result = lanternFishSeq |> Part2.toLanternFishDictionary

        Assert.Equal<int32>(0, result.Count)

    [<Fact>]
    let ``Part2.toLanternFishDictionary: when lanternFishSeq is None then dictionary with 0 keys`` () =
        let lanternFishSeq = None

        let result = lanternFishSeq |> Part2.toLanternFishDictionary

        Assert.Equal<int32>(0, result.Count)

    [<Fact>]
    let ``Part2.toLanternFishDictionary: when lanternFishSeq is Some with 1 item with DaysUntilSpawn = 1 then dictionary with Key 1 and Value = 1`` () =
        let lanternFishSeq =
            seq {
                { DaysUntilSpawn = 1uy; }
            }

        let result = Some lanternFishSeq |> Part2.toLanternFishDictionary

        let expected = Dictionary<byte, int>()
        expected.Add(1uy, 1)
            
        Assert.Equal<Dictionary<byte, int>>(
            expected,
            result)

    [<Fact>]
    let ``Part2.toLanternFishDictionary: when lanternFishSeq is Some with 2 items with DaysUntilSpawn = 1 then dictionary with Key 1 and Value 2`` () =
        let lanternFishSeq =
            seq {
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 1uy; }
            }

        let result = Some lanternFishSeq |> Part2.toLanternFishDictionary

        let expected = Dictionary<byte, int>()
        expected.Add(1uy, 2)
            
        Assert.Equal<Dictionary<byte, int>>(
            expected,
            result)

    [<Fact>]
    let ``Part2.toLanternFishDictionary: when lanternFishSeq is Some with 2 items with DaysUntilSpawn = 1 and 1 item with DaysUntilSpawn 2 then dictionary with Key 1 and Value 2 and Key 2 and Value 1`` () =
        let lanternFishSeq =
            seq {
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 1uy; }
                { DaysUntilSpawn = 2uy; }
            }

        let result = Some lanternFishSeq |> Part2.toLanternFishDictionary

        let expected = Dictionary<byte, int>()
        expected.Add(1uy, 2)
        expected.Add(2uy, 1)
            
        Assert.Equal<Dictionary<byte, int>>(
            expected,
            result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when empty dictionary then returns empty dictionary`` () =
        let lanternFish = Dictionary<byte, int>()

        let result = lanternFish |> Part2.spawnLanternFish

        Assert.Equal<Dictionary<byte, int>>(Dictionary<byte, int>(), result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 8 then returns a single lanternFish with DaysUntilSpan = 7`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(8uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(7uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 7 then returns a single lanternFish with DaysUntilSpan = 6`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(7uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(6uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 6 then returns a single lanternFish with DaysUntilSpan = 5`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(6uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(5uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 5 then returns a single lanternFish with DaysUntilSpan = 4`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(5uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish
        
        let expected = Dictionary<byte, int>()
        expected.Add(4uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 4 then returns a single lanternFish with DaysUntilSpan = 3`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(4uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(3uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 3 then returns a single lanternFish with DaysUntilSpan = 2`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(3uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(2uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 2 then returns a single lanternFish with DaysUntilSpan = 1`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(2uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(1uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 1 then returns a single lanternFish with DaysUntilSpan = 0`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(1uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(0uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when single lanternFish with DaysUntilSpawn = 0 then returns two lanternFish one with DaysUntilSpan = 6 and one with DaysUntilSpawn = 6`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(0uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(6uy, 1)
        expected.Add(8uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFish: when initial state is initial state from problem 3,4,3,1,2 then result is 2,3,2,0,1`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(3uy, 2)
        lanternFish.Add(4uy, 1)
        lanternFish.Add(1uy, 1)
        lanternFish.Add(2uy, 1)

        let result = lanternFish |> Part2.spawnLanternFish

        let expected = Dictionary<byte, int>()
        expected.Add(2uy, 2)
        expected.Add(3uy, 1)
        expected.Add(0uy, 1)
        expected.Add(1uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFishTimes: when initial state is initial state lanternFish is empty dictionary then result is empty dictionary`` () =
        let lanternFish = Dictionary<byte, int>()

        let result = lanternFish |> Part2.spawnLanternFishTimes <| 1

        Assert.Equal<Dictionary<byte, int>>(Dictionary<byte, int>(), result)

    [<Fact>]
    let ``Part2.spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 1 then result is 8,6`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(0uy, 1)

        let result = lanternFish |> Part2.spawnLanternFishTimes <| 1

        let expected = Dictionary<byte, int>()
        expected.Add(6uy, 1)
        expected.Add(8uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 2 then result is 7,5`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(0uy, 1)

        let result = lanternFish |> Part2.spawnLanternFishTimes <| 2

        let expected = Dictionary<byte, int>()
        expected.Add(5uy, 1)
        expected.Add(7uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)

    [<Fact>]
    let ``Part2.spawnLanternFishTimes: when initial state is initial state lanternFish 0 and times is 3 then result is 6,4`` () =
        let lanternFish = Dictionary<byte, int>()
        lanternFish.Add(0uy, 1)

        let result = lanternFish |> Part2.spawnLanternFishTimes <| 3

        let expected = Dictionary<byte, int>()
        expected.Add(4uy, 1)
        expected.Add(6uy, 1)
        Assert.Equal<Dictionary<byte, int>>(expected, result)
