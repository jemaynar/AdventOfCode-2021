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
    let rec ``parseLanternFish: when contains 1 then returns Option Some with sequence of 1 lanternFish with DaysUntilSpawn = 5`` () =
        let inputLine = "5"

        let result = inputLine |> parseLanternFish

        Assert.Equal<seq<LanternFish>>(
            seq {
                { DaysUntilSpawn = 5uy; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)
