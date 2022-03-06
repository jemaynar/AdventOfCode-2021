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
