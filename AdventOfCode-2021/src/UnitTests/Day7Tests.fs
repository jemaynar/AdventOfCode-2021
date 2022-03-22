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
    let ``fuelConsumption: when horizontal positions are 16,1,2,0,4,2,7,1,2,14 then result is 37`` () =
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
                |> fuelConsumption

        Assert.Equal<int>(
            37,
            match result with
                | Some(i) -> i
                | None -> 0)
