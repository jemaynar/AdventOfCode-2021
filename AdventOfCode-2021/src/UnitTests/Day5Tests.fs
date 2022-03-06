module UnitTests.Day5Tests
    open Xunit
    open Day5
    
    [<Fact>]
    let ``parseLineSegment: when inputLine is blank then returns Option.None`` () =
        let inputLine = ""
        
        let result = inputLine |> parseLineSegment

        Assert.Equal<Option<LineSegment>>(
            Option.None,
            result)
        
    [<Fact>]
    let ``parseLineSegment: when inputLine is "0,0->0,1" then returns Option.None`` () =
        let inputLine = "0,0->0,1"
        
        let result = inputLine |> parseLineSegment

        Assert.Equal<Option<LineSegment>>(
            Option.None,
            result)    
    
    [<Fact>]
    let ``parseLineSegment: when inputLine is "0,0 -> 0,1" then returns lineSegment with equal value`` () =
        let inputLine = "0,0 -> 0,1"
        
        let result = inputLine |> parseLineSegment
        
        Assert.Equal<Option<LineSegment>>(
            Some { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 1us }; },
            result)
        
    [<Fact>]
    let ``parseLineSegment: when inputLine is "0,0 -> 1,0" then returns lineSegment with equal value`` () =
        let inputLine = "0,0 -> 1,0"
        
        let result = inputLine |> parseLineSegment
        
        Assert.Equal<Option<LineSegment>>(
            Some { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 1us; Y = 0us }; },
            result)

    [<Fact>]
    let ``getLineSegments: when 10 valid sample lines from problem then returns seq of lineSegments with equal values`` () =
        let inputLines = seq<string> {
            "0,9 -> 5,9";
            "8,0 -> 0,8";
            "9,4 -> 3,4";
            "2,2 -> 2,1";
            "7,0 -> 7,4";
            "6,4 -> 2,0";
            "0,9 -> 2,9";
            "3,4 -> 1,4";
            "0,0 -> 8,8";
            "5,5 -> 8,2";
        }
        
        let result = inputLines |> getLineSegments
            
        Assert.Equal<seq<LineSegment>>(
            seq<LineSegment> {
                { EndPoint1 = { X = 0us; Y = 9us; }; EndPoint2 = { X = 5us; Y = 9us; }; };
                { EndPoint1 = { X = 8us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 8us; }; };
                { EndPoint1 = { X = 9us; Y = 4us; }; EndPoint2 = { X = 3us; Y = 4us; }; };
                { EndPoint1 = { X = 2us; Y = 2us; }; EndPoint2 = { X = 2us; Y = 1us; }; };
                { EndPoint1 = { X = 7us; Y = 0us; }; EndPoint2 = { X = 7us; Y = 4us; }; };
                { EndPoint1 = { X = 6us; Y = 4us; }; EndPoint2 = { X = 2us; Y = 0us; }; };
                { EndPoint1 = { X = 0us; Y = 9us; }; EndPoint2 = { X = 2us; Y = 9us; }; };
                { EndPoint1 = { X = 3us; Y = 4us; }; EndPoint2 = { X = 1us; Y = 4us; }; };
                { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 8us; Y = 8us; }; };
                { EndPoint1 = { X = 5us; Y = 5us; }; EndPoint2 = { X = 8us; Y = 2us; }; };
            },
            result)
        