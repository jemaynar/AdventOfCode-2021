module Day5
    open System

    type Coordinate = { X: uint16; Y: uint16 }
    type LineSegment = { EndPoint1: Coordinate; EndPoint2: Coordinate }
    
    let parseLineSegment (inputLine: string): Option<LineSegment> =
        if inputLine |> String.IsNullOrWhiteSpace then
            Option.None
        else
            let coordinateArray = inputLine.Split " -> "
            if coordinateArray.Length <> 2 then
                Option.None
            else
                coordinateArray
                    |> Array.pairwise
                    |> Array.map(fun tuple ->
                        Option<LineSegment>.Some {
                            EndPoint1 = {
                                X = (fst tuple).Split(',').[0] |> Convert.ToUInt16;
                                Y = (fst tuple).Split(',').[1] |> Convert.ToUInt16;
                            }
                            EndPoint2 = {
                                X = (snd tuple).Split(',').[0] |> Convert.ToUInt16;
                                Y = (snd tuple).Split(',').[1] |> Convert.ToUInt16;
                            }
                        })
                    |> Array.head
            
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
