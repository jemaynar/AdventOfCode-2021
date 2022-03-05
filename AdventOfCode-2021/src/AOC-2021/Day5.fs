module Day5
    open System

    type Coordinate = { X: uint16; Y: uint16 }
    type LineSegment = { EndPoint1: Coordinate; EndPoint2: Coordinate }
    
    let parseLineSegment (inputLine: string): Option<LineSegment> =
        if inputLine |> String.IsNullOrWhiteSpace then
            Option.None
        else
            Option.Some {
                 EndPoint1 = { X = 0us; Y = 0us; };
                 EndPoint2 = { X = 0us; Y = 1us; }
             }
            
    module Part1 =
        let Execute: unit =
            printfn "\nDay 5 / Part 1 Result:\n"
            
            let fileLines = Common.getData ".\Data\input5.txt"
            
            let lineOverlaps = 0
            
            printfn "\nOverlap Count: %i" <| lineOverlaps
            
    module Part2 =
        let Execute: unit =
            printfn "\nDay 5 / Part 2 Result:\n"
    
    let Execute: unit =
        Part1.Execute
        Part2.Execute
