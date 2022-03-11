module UnitTests.Day6Tests
    open Xunit
    open Day6

    [<Fact>]
    let rec ``parseLanternFish: when line is empty then returns Option None`` () =
        let inputLine = System.String.Empty

        let result = inputLine |> parseLanternFish

        Assert.Equal<Option<seq<LanternFish>>>(None, result)
