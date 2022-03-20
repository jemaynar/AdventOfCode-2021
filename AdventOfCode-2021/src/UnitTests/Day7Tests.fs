module UnitTests.Day7Tests
    open Xunit
    open Day7

    [<Fact>]
    let rec ``parseCrabs: when line is empty then returns Option None`` () =
        let inputLine = System.String.Empty

        let result = inputLine |> parseCrabs

        Assert.Equal<Option<seq<Crab>>>(None, result)
