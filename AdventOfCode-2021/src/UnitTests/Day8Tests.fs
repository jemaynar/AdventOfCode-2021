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

    [<Fact>]
    let ``getKnownDigitCount: when line contains series 4 known digits then returns 4`` () =
        let inputLine = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | gx cbe eafb abcdefg"

        let parsed = inputLine |> parseLine

        let seqResult =
            match parsed with
                | Some(x) -> seq { x }
                | None  -> Seq.empty

        let result =
            seqResult
                |> getKnownDigitCount

        Assert.Equal<int>(4, result)

    [<Fact>]
    let ``getKnownDigitCount: when lines from sample problem then returns 26`` () =
        let inputLines =
            seq {
                "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe"
                "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc"
                "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg"
                "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb"
                "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea"
                "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb"
                "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe"
                "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef"
                "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb"
                "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
            }

        let result =
            inputLines
                |> Seq.map(parseLine)
                |> Seq.choose id
                |> getKnownDigitCount

        Assert.Equal<int>(26, result)

    [<Fact>]
    let ``getDigit: when digit is 2 then returns then returns Option.None`` () =
        let signalEntry =
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
            }

        let result = getDigit signalEntry 2

        Assert.Equal<Option<string>>(None, result)

    [<Fact>]
    let ``getDigit: when digit is 1 then returns unique signal pattern with length 2 (ab)`` () =
        let signalEntry =
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
            }

        let result = getDigit signalEntry 1

        Assert.Equal<string>(
            "ab",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getDigit: when digit is 4 then returns unique signal pattern with length 4 (eafb)`` () =
        let signalEntry =
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
            }

        let result = getDigit signalEntry 4

        Assert.Equal<string>(
            "eafb",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getDigit: when digit is 7 then returns unique signal pattern with length 3 (dab)`` () =
        let signalEntry =
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
            }

        let result = getDigit signalEntry 7

        Assert.Equal<string>(
            "dab",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getDigit: when digit is 8 then returns unique signal pattern with length 7 (acedgfb)`` () =
        let signalEntry =
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
            }

        let result = getDigit signalEntry 8

        Assert.Equal<string>(
            "acedgfb",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getDigitalLedPositions: when 7 is dab and 1 is ab then Top is d`` () =
        let signalEntry =
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
            }

        let result = getDigitalLedPositions signalEntry

        let matchedResult = match result.Top with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('d', matchedResult)

    [<Fact>]
    let ``getDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then BottomRight is b`` () =
        let signalEntry =
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
            }

        let result = getDigitalLedPositions signalEntry

        let matchedResult = match result.BottomRight with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('b', matchedResult)

    [<Fact>]
    let ``getDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then TopRight is a`` () =
        let signalEntry =
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
            }

        let result = getDigitalLedPositions signalEntry

        let matchedResult = match result.TopRight with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('a', matchedResult)
