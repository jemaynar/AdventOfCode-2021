module UnitTests.Day7Tests
    open Xunit
    open Day7

    [<Fact>]
    let rec ``parseCrabs: when line is empty then returns Option None`` () =
        let inputLine = System.String.Empty

        let result = inputLine |> parseCrabs

        Assert.Equal<Option<seq<Crab>>>(None, result)

    [<Fact>]
    let ``parseCrabs: when line is null then returns Option None`` () =
        let inputLine = null

        let result = inputLine |> parseCrabs

        Assert.Equal<Option<seq<Crab>>>(None, result)

    [<Fact>]
    let ``parseCrabs: when line is whitespace then returns Option None`` () =
        let inputLine = " "

        let result = inputLine |> parseCrabs

        Assert.Equal<Option<seq<Crab>>>(None, result)

    [<Fact>]
    let ``parseCrabs: when contains 1 then returns Option Some with sequence of 1 crab with HorizontalPosition = 1`` () =
        let inputLine = "1"

        let result = inputLine |> parseCrabs

        Assert.Equal<seq<Crab>>(
            seq {
                { HorizontalPosition = 1us; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)

    [<Fact>]
    let ``parseCrabs: when contains 1,2 then returns Option Some with sequence of 1 crab with HorizontalPosition = 1 and 1 crab with HorizontalPosition = 2`` () =
        let inputLine = "1,2"

        let result = inputLine |> parseCrabs

        Assert.Equal<seq<Crab>>(
            seq {
                { HorizontalPosition = 1us; }
                { HorizontalPosition = 2us; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 1 and optimalPosition position is 1 then result is 0`` () =
        let crab = { HorizontalPosition = 1us }
        let optimalPosition = 1us

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(result, 0)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 1 and optimalPosition position is 0 then result is 1`` () =
        let crab = { HorizontalPosition = 1us }
        let optimalPosition = 0us

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(result, 1)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 0 and optimalPosition position is 1 then result is 1`` () =
        let crab = { HorizontalPosition = 0us }
        let optimalPosition = 1us

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(result, 1)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 2 and optimalPosition position is 0 then result is 2`` () =
        let crab = { HorizontalPosition = 2us }
        let optimalPosition = 0us

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(result, 2)

    [<Fact>]
    let ``fuelConsumption: when horizontal positions are 16,1,2,0,4,2,7,1,2,14 when crabConsumption is one fuel per position then result is 37`` () =
        let crabs =
            seq {
                { HorizontalPosition = 16us }
                { HorizontalPosition = 1us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 0us }
                { HorizontalPosition = 4us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 7us }
                { HorizontalPosition = 1us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 14us }
            }

        let result =
            Some crabs
                |> fuelConsumption <| Part1.getCrabConsumption

        Assert.Equal<int>(
            37,
            match result with
                | Some(i) -> i
                | None -> 0)
