module UnitTests.Day8Tests
    open Xunit
    open Day8

    [<Fact>]
    let ``parseLine: when line is empty then returns Option.None`` () =
        let inputLine = System.String.Empty

        let result = inputLine |> parseLine

        Assert.Equal<Option<SignalEntry>>(None, result)

    [<Fact>]
    let ``parseLine: when line is null then returns Option.None`` () =
        let inputLine = null

        let result = inputLine |> parseLine

        Assert.Equal<Option<SignalEntry>>(None, result)

    [<Fact>]
    let ``parseLine: when line is whitespace then returns Option.None`` () =
        let inputLine = " "

        let result = inputLine |> parseLine

        Assert.Equal<Option<SignalEntry>>(None, result)

    [<Fact>]
    let ``parseLine when line contains 10 series of alpha characters pipe then four series of alpha characters then returns Some SignalEntry`` () =
        let inputLine = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"

        let result = inputLine |> parseLine
        
        let matched = 
            match result with 
                | Some(signalEntry) -> signalEntry
                | None -> { UniqueSignalPattern = Array.empty; FourDigitOutput = Array.empty }
        
        Assert.Equal<SignalEntry>(
            {
                UniqueSignalPattern =
                    [|
                        "acedgfb"
                        "cdfbe"
                        "gcdfa"
                        "fbcad"
                        "dab"
                        "cefabd"
                        "cdfgeb"
                        "eafb"
                        "cagedb"
                        "ab"
                    |]
                FourDigitOutput =
                    [|
                        "cdfeb"
                        "fcadb"
                        "cdfeb"
                        "cdbaf"
                    |]
            },
            matched)