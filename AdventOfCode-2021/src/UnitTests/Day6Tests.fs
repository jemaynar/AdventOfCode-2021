module UnitTests.Day6Tests
    open Xunit
    open Day6

    [<Fact>]
    let rec ``parseLanternFish: when line is empty then returns Option None`` () =
        let inputLine = System.String.Empty

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)

    [<Fact>]
    let rec ``parseLanternFish: when line is null then returns Option None`` () =
        let inputLine = null

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)

    [<Fact>]
    let rec ``parseLanternFish: when line is whitespace then returns Option None`` () =
        let inputLine = " "

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)

    [<Fact>]
    let rec ``parseLanternFish: when contains 1 then returns Option Some with sequence of 1 lanternFish with DaysUntilSpawn = 1`` () =
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
    let rec ``parseLanternFish: when contains 1,2 then returns Option Some with sequence of 1 lanternFish with DaysUntilSpawn = 1 and 1 lanternFish with DaysUntilSpan = 2`` () =
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
