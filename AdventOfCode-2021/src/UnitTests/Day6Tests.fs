module UnitTests.Day6Tests
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
