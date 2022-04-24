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
    let ``getKnownDigitString: when digit is 2 then returns then returns Option.None`` () =
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

        let result = getKnownDigitString signalEntry 2

        Assert.Equal<Option<string>>(None, result)

    [<Fact>]
    let ``getKnownDigitString: when digit is 1 then returns unique signal pattern with length 2 (ab)`` () =
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

        let result = getKnownDigitString signalEntry 1

        Assert.Equal<string>(
            "ab",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getKnownDigitString: when digit is 4 then returns unique signal pattern with length 4 (eafb)`` () =
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

        let result = getKnownDigitString signalEntry 4

        Assert.Equal<string>(
            "eafb",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getKnownDigitString: when digit is 7 then returns unique signal pattern with length 3 (dab)`` () =
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

        let result = getKnownDigitString signalEntry 7

        Assert.Equal<string>(
            "dab",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``getKnownDigitString: when digit is 8 then returns unique signal pattern with length 7 (acedgfb)`` () =
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

        let result = getKnownDigitString signalEntry 8

        Assert.Equal<string>(
            "acedgfb",
            match result with
                | Some(result) -> result
                | None -> System.String.Empty)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab then Top is d`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.Top with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('d', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then BottomRight is b`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.BottomRight with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('b', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then TopRight is a`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.TopRight with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('a', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then Middle is f`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.Middle with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('f', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then when 4 is eafb then TopLeft is e`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.TopLeft with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('e', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb then when 4 is eafb then BottomLeft is g`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.BottomLeft with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('g', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is dab and 1 is ab when signal patterns with length 6 are cefabd, cdfgeb, and cagedb when 4 is eafb then Bottom is c`` () =
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

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.Bottom with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('c', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is cbd and 1 is bc then when signal patters with length 6 are fbegcd, adcefb, fgdeca then Top is d`` () =
        let signalEntry =
            {
                UniqueSignalPattern =
                    [|
                        "fbegcd"
                        "cbd"
                        "adcefb"
                        "dageb"
                        "afcb"
                        "bc"
                        "aefdc"
                        "ecdab"
                        "fgdeca"
                        "fcdbega"
                    |]
                FourDigitOutput =
                    [|
                        "efabcd"
                        "cedba"
                        "gadfec"
                        "cb"
                    |]
            }

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.Top with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('d', matchedResult)
        
    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is cbd and 1 is bc when signal patterns with length 6 are fbegcd, adcefb, and fgdeca then BottomRight is c`` () =
        let signalEntry =
            {
                UniqueSignalPattern =
                    [|
                        "fbegcd"
                        "cbd"
                        "adcefb"
                        "dageb"
                        "afcb"
                        "bc"
                        "aefdc"
                        "ecdab"
                        "fgdeca"
                        "fcdbega"
                    |]
                FourDigitOutput =
                    [|
                        "efabcd"
                        "cedba"
                        "gadfec"
                        "cb"
                    |]
            }

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.BottomRight with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('c', matchedResult)

    [<Fact>]
    let ``mapDigitalLedPositions: when 7 is cbd and 1 is bc when signal patterns with length 6 are fbegcd, adcefb, and fgdeca then Middle is a`` () =
        let signalEntry =
            {
                UniqueSignalPattern =
                    [|
                        "fbegcd"
                        "cbd"
                        "adcefb"
                        "dageb"
                        "afcb"
                        "bc"
                        "aefdc"
                        "ecdab"
                        "fgdeca"
                        "fcdbega"
                    |]
                FourDigitOutput =
                    [|
                        "efabcd"
                        "cedba"
                        "gadfec"
                        "cb"
                    |]
            }

        let result = mapDigitalLedPositions signalEntry

        let matchedResult = match result.Middle with | Some(x) -> x | None -> '_'
        Assert.Equal<char>('a', matchedResult)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "cdfeb" then result is 5`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "cdfeb"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            5,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "fcadb" then result is 3`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "fcadb"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            3,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "dafgc" then result is 2`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "dafgc"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            2,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "ab" then result is 1`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "ab"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            1,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "dab" then result is 7`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "dab"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            7,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "afab" then result is 4`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "afab"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            4,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "abcdefg" then result is 8`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "abcdefg"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            8,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "deagcb" then result is 0`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "deagcb"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            0,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "defabc" then result is 9`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "defabc"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            9,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapCharsToInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when digitalString is "defagc" then result is 6`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let digitalString = "defagc"

        let result = mapCharsToInt digitalLedMap digitalString

        Assert.Equal<int>(
            6,
            match result with
                | Some(result) -> result
                | None -> -1)

    [<Fact>]
    let ``mapFourDigitOutputInt: when digitalLedMap is { Top = 'd'; TopRight = 'a'; TopLeft = 'e'; Middle = 'f'; BottomLeft = 'g'; BottomRight = 'b'; Bottom = 'c' } when fourDigitOutputArray is [| "cdfeb"; "fcadb"; "cdfeb"; "cdbaf" |] then result is 5353`` () =
        let digitalLedMap =
            {
                Top = Some 'd'
                TopRight = Some 'a' 
                TopLeft = Some 'e'
                Middle = Some 'f'
                BottomLeft = Some 'g'
                BottomRight = Some 'b'
                Bottom = Some 'c'
            }

        let fourDigitOutputArray = [| "cdfeb"; "fcadb"; "cdfeb"; "cdbaf" |]

        let result = mapFourDigitOutputInt digitalLedMap fourDigitOutputArray

        Assert.Equal<int>(5353, result)

    [<Fact>]
    let ``ConfidenceBoostingTest: when complete first sample problem then sequence contains expected output numbers`` () =
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
                |> Seq.map(fun f -> f |> parseLine)
                |> Seq.choose id
                |> Seq.map(fun se -> mapFourDigitOutputInt <| mapDigitalLedPositions se <| se.FourDigitOutput)

        let expectedResult =
            seq {
                8394
                9781
                1197
                9361
                4873
                8418
                4548
                1625
                8717
                4315
            }
        
        Assert.Equal<seq<int>>(
            expectedResult,
            result)

    [<Fact>]
    let ``ConfidenceBoostingTest: when complete first sample problem then sum is 61,229`` () =
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
                |> Seq.map(fun f -> f |> parseLine)
                |> Seq.choose id
                |> Seq.map(fun se -> mapFourDigitOutputInt <| mapDigitalLedPositions se <| se.FourDigitOutput)
                |> Seq.sum

        Assert.Equal<int>(
            61_229,
            result)
