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
    let ``Part1.getKnownDigitCount: when line contains series 4 known digits then returns 4`` () =
        let inputLine = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | gx cbe eafb abcdefg"

        let parsed = inputLine |> parseLine

        let seqResult =
            match parsed with
                | Some(x) -> seq { x }
                | None  -> Seq.empty

        let result =
            seqResult
                |> Part1.getKnownDigitCount

        Assert.Equal<int>(4, result)

    [<Fact>]
    let ``Part1.getKnownDigitCount: when lines from sample problem then returns 26`` () =
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
                |> Part1.getKnownDigitCount

        Assert.Equal<int>(26, result)
