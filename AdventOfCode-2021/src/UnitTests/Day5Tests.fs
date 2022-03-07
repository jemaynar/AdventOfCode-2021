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
    let ``getLineSegments: when inputLines is empty then returns empty sequence.`` () =
        let inputLines = Seq.empty
        
        let result = inputLines |> getLineSegments
            
        Assert.Equal<seq<LineSegment>>(Seq.empty, result)
    
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
                
    [<Fact>]
    let ``getLineSegments: when inputLines contains one valid line and one invalid line then empty line is filtered.`` () =
        let inputLines = seq<string> {
            "0,9 -> 5,9";
            "invalid line"
        }
        
        let result = inputLines |> getLineSegments
            
        Assert.Equal<seq<LineSegment>>(
             seq<LineSegment> {
                { EndPoint1 = { X = 0us; Y = 9us; }; EndPoint2 = { X = 5us; Y = 9us; }; }
             },
             result)
        
    [<Fact>]
    let ``lineSegmentToCoordinates: when endPoints 0,0 -> 0,0 then returns single coordinate 0,0`` () =
        let lineSegment =
            { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 0us; }; }
        
        let result =
            lineSegment
                |> lineSegmentToCoordinates 
            
        Assert.Equal<seq<Coordinate>>(
            seq<Coordinate> {
                { X = 0us; Y = 0us; };
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)
        
    [<Fact>]
    let ``lineSegmentToCoordinates: when endPoints 0,0 -> 0,1 then returns coordinates coordinates 0,0 and 0,1`` () =
        let lineSegment =
            { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 1us; }; }
        
        let result =
            lineSegment
            |> lineSegmentToCoordinates
        
        Assert.Equal<seq<Coordinate>>(
            seq<Coordinate> {
                { X = 0us; Y = 0us; }
                { X = 0us; Y = 1us; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)
        
    [<Fact>]
    let ``lineSegmentToCoordinates: when endPoints 1,1 -> 0,1 then returns coordinates coordinates 1,1 and 0,1`` () =
        let lineSegment =
            { EndPoint1 = { X = 1us; Y = 1us; }; EndPoint2 = { X = 0us; Y = 1us; }; }
        
        let result =
            lineSegment
            |> lineSegmentToCoordinates
        
        Assert.Equal<seq<Coordinate>>(
            seq<Coordinate> {
                { X = 0us; Y = 1us; }
                { X = 1us; Y = 1us; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)
        
    [<Fact>]
    let ``lineSegmentToCoordinates: when endpoints 0,0 -> 1,0 then returns coordinates 0,0 and 1,0`` () =
        let lineSegment =
            { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 1us; Y = 0us; }; }
        
        let result =
            lineSegment
            |> lineSegmentToCoordinates
        
        Assert.Equal<seq<Coordinate>>(
            seq<Coordinate> {
                { X = 0us; Y = 0us; }
                { X = 1us; Y = 0us; }
            },
            match result with
                | Some(sequence) -> sequence
                | None -> Seq.empty)
    
    [<Fact>]
    let ``lineSegmentToCoordinateOccurrences: when single line segment 0,0 -> 0,0 then returns single coordinate 0,0 with 1 occurrence`` () =
        let lineSegments =
            seq<LineSegment> {
                { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 0us; }; }            
            }
            
        let result = lineSegments |> lineSegmentsToCoordinateOccurrences
            
        Assert.Equal<seq<CoordinateOccurrences>>(
            seq<CoordinateOccurrences> {
                { Coordinate = { X = 0us; Y = 0us; }; Occurrences = 1us; }
            },
            result)

    [<Fact>]
    let ``lineSegmentToCoordinateOccurrences: when single line segment 0,0 -> 0,1 then returns two coordinates 0,0 and 0,1 each with 1 occurrence`` () =
        let lineSegments =
            seq<LineSegment> {
                { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 1us; }; }            
            }
            
        let result = lineSegments |> lineSegmentsToCoordinateOccurrences
            
        Assert.Equal<seq<CoordinateOccurrences>>(
            seq<CoordinateOccurrences> {
                { Coordinate = { X = 0us; Y = 0us; }; Occurrences = 1us; }
                { Coordinate = { X = 0us; Y = 1us; }; Occurrences = 1us; }
            },
            result)
        
    [<Fact>]
    let ``lineSegmentToCoordinateOccurrences: when two line segments 0,0 -> 0,1 and 0,1 -> 1,1 then returns 2 expected coordinates with one occurence and 1 coordinate with 2 occurrences`` () =
        let lineSegments =
            seq<LineSegment> {
                { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 1us; }; }
                { EndPoint1 = { X = 0us; Y = 1us; }; EndPoint2 = { X = 1us; Y = 1us; }; }
            }
            
        let result = lineSegments |> lineSegmentsToCoordinateOccurrences
            
        Assert.Equal<seq<CoordinateOccurrences>>(
            seq<CoordinateOccurrences> {
                { Coordinate = { X = 0us; Y = 0us; }; Occurrences = 1us; }
                { Coordinate = { X = 0us; Y = 1us; }; Occurrences = 2us; }
                { Coordinate = { X = 1us; Y = 1us; }; Occurrences = 1us; }
            },
            result)
        
    [<Fact>]
    let ``lineSegmentsToCoordinateOccurrenceIntersections: when 10 valid sample lines from problem then returns 5 expected coordinates with 2 occurrences`` () =
        let lineSegments =
            seq<LineSegment> {
                { EndPoint1 = { X = 0us; Y = 9us; }; EndPoint2 = { X = 5us; Y = 9us; } }
                { EndPoint1 = { X = 8us; Y = 0us; }; EndPoint2 = { X = 0us; Y = 8us; } }
                { EndPoint1 = { X = 9us; Y = 4us; }; EndPoint2 = { X = 3us; Y = 4us; } }
                { EndPoint1 = { X = 2us; Y = 2us; }; EndPoint2 = { X = 2us; Y = 1us; } }
                { EndPoint1 = { X = 7us; Y = 0us; }; EndPoint2 = { X = 7us; Y = 4us; } }
                { EndPoint1 = { X = 6us; Y = 4us; }; EndPoint2 = { X = 2us; Y = 0us; } }
                { EndPoint1 = { X = 0us; Y = 9us; }; EndPoint2 = { X = 2us; Y = 9us; } }
                { EndPoint1 = { X = 3us; Y = 4us; }; EndPoint2 = { X = 1us; Y = 4us; } }
                { EndPoint1 = { X = 0us; Y = 0us; }; EndPoint2 = { X = 8us; Y = 8us; } }
                { EndPoint1 = { X = 5us; Y = 5us; }; EndPoint2 = { X = 8us; Y = 2us; } }
            }
            
        let result = lineSegments |> lineSegmentsToCoordinateOccurrenceIntersections |> Seq.toArray

        Assert.Equal<array<CoordinateOccurrences>>(
            [|
                { Coordinate = { X = 0us; Y = 9us; }; Occurrences = 2us; }
                { Coordinate = { X = 1us; Y = 9us; }; Occurrences = 2us; }
                { Coordinate = { X = 2us; Y = 9us; }; Occurrences = 2us; }
                { Coordinate = { X = 3us; Y = 4us; }; Occurrences = 2us; }
                { Coordinate = { X = 7us; Y = 4us; }; Occurrences = 2us; }
            |],
            result)
 
        
        