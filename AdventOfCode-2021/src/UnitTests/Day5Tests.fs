module UnitTests.Day5Tests
    open Xunit
    open Day5
    
    [<Fact>]
    let ``getLineSegment: when inputLine is 0,1, -> 1,1 then returns lineSegment with equal value`` () =
        let inputLine = "0,1 -> 1,1"
        
        let result = inputLine |> parseLineSegment
        
        Assert.Equal<LineSegment>(
            result, { EndPoint1 = { X = 0us; Y = 1us; }; EndPoint2 = { X = 1us; Y = 1us }; })
