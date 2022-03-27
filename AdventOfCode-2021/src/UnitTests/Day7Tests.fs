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
        let optimalPosition = 1

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(0, result)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 1 and optimalPosition position is 0 then result is 1`` () =
        let crab = { HorizontalPosition = 1us }
        let optimalPosition = 0

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(1, result)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 0 and optimalPosition position is 1 then result is 1`` () =
        let crab = { HorizontalPosition = 0us }
        let optimalPosition = 1

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(1, result)

    [<Fact>]
    let ``Part1.getCrabConsumption: when Crab.HorizontalPosition is 2 and optimalPosition position is 0 then result is 2`` () =
        let crab = { HorizontalPosition = 2us }
        let optimalPosition = 0

        let result = Part1.getCrabConsumption crab optimalPosition

        Assert.Equal<int>(2, result)

    [<Fact>]
    let ``getTriangleNumber: when 0 then result is 0`` () =
        let nth = 0

        let result = getTriangleNumber nth

        Assert.Equal<int>(0, result)

    [<Fact>]
    let ``getTriangleNumber: when 1 then result is 1`` () =
        let nth = 1

        let result = getTriangleNumber nth

        Assert.Equal<int>(1, result)

    [<Fact>]
    let ``getTriangleNumber: when 2 then result is 3`` () =
        let nth = 2

        let result = getTriangleNumber nth

        Assert.Equal<int>(3, result)
        
    [<Fact>]
    let ``getTriangleNumber: when 3 then result is 6`` () =
        let nth = 3

        let result = getTriangleNumber nth

        Assert.Equal<int>(6, result)

    [<Fact>]
    let ``getAverage: when 16,1,2,0,4,2,7,1,2,14 then result is seq { 4; 5 }`` () =
        let sortedCrabs =
            [|
                { HorizontalPosition = 0us }
                { HorizontalPosition = 1us }
                { HorizontalPosition = 1us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 4us }
                { HorizontalPosition = 7us }
                { HorizontalPosition = 14us }
                { HorizontalPosition = 16us }
            |]

        let result = sortedCrabs |> getAverage

        Assert.Equal<seq<int>>(seq { 4; 5 }, result)

    [<Fact>]
    let ``getAverage: when 10,1,2,0,4,2,7,1,2,14 then result is seq { 4; 5 }`` () =
        let sortedCrabs =
            [|
                { HorizontalPosition = 0us }
                { HorizontalPosition = 1us }
                { HorizontalPosition = 1us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 2us }
                { HorizontalPosition = 4us }
                { HorizontalPosition = 8us }
                { HorizontalPosition = 10us }
                { HorizontalPosition = 16us }
            |]

        let result = sortedCrabs |> getAverage

        Assert.Equal<seq<int>>(seq { 4; 5 }, result)

    [<Fact>]
    let ``Part1.fuelConsumption: when horizontal positions are 16,1,2,0,4,2,7,1,2,14 when crabConsumption is one fuel per position then result is 37`` () =
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
                |> fuelConsumption <| Part1.getCrabConsumption <| getMedian

        Assert.Equal<int>(
            37,
            match result with
                | Some(i) -> i
                | None -> 0)

    [<Fact>]
    let ``Part2.fuelConsumption: when horizontal positions are 16,1,2,0,4,2,7,1,2,14 when crabConsumption increases by one per position then result is 168`` () =
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
                |> fuelConsumption <| Part2.getCrabConsumption <| getAverage

        Assert.Equal<int>(
            168,
            match result with
                | Some(i) -> i
                | None -> 0)
