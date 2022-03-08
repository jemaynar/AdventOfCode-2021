module Day5
    open System

    type Coordinate = { X: uint16; Y: uint16 }
    type LineSegment = { EndPoint1: Coordinate; EndPoint2: Coordinate }
    type CoordinateOccurrences = { Coordinate: Coordinate; Occurrences: uint16 }

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

    let getLineSegments (inputLines: seq<string>): seq<LineSegment> =
        inputLines
            |> Seq.choose(parseLineSegment)

    let lineSegmentsToCoordinateOccurrences lineSegments lineSegmentsToCoordinatesFunc =
        lineSegments
            |> Seq.choose(fun lineSegment -> lineSegment |> lineSegmentsToCoordinatesFunc)
            |> Seq.concat
            |> Seq.countBy(id)
            |> Seq.map(fun tuple -> { Coordinate = fst tuple; Occurrences = snd tuple |> uint16 })

    let lineSegmentsToCoordinateOccurrenceIntersections lineSegments lineSegmentsToCoordinatesFunc =
        lineSegments
            |> lineSegmentsToCoordinateOccurrences <| lineSegmentsToCoordinatesFunc
            |> Seq.filter(fun o -> o.Occurrences > 1us)
    
    module Part1 =
        let lineSegmentToCoordinates (lineSegment: LineSegment): Option<seq<Coordinate>> =
            if lineSegment.EndPoint1.X = lineSegment.EndPoint2.X && lineSegment.EndPoint1.Y = lineSegment.EndPoint2.Y then
                let coordinates = seq<Coordinate> {
                    { X = lineSegment.EndPoint1.X; Y = lineSegment.EndPoint1.Y; }
                }
                Some coordinates
            else if lineSegment.EndPoint1.X = lineSegment.EndPoint2.X then
                let coordinates =
                    if lineSegment.EndPoint1.Y >= lineSegment.EndPoint2.Y then
                        seq { lineSegment.EndPoint2.Y .. lineSegment.EndPoint1.Y }
                    else
                        seq { lineSegment.EndPoint1.Y .. lineSegment.EndPoint2.Y }
                    |> Seq.map(fun yCoordinate -> { X = lineSegment.EndPoint1.X; Y = yCoordinate })
                Some coordinates
            else if lineSegment.EndPoint1.Y = lineSegment.EndPoint2.Y then
                let coordinates =
                    if lineSegment.EndPoint1.X >= lineSegment.EndPoint2.X then
                        seq { lineSegment.EndPoint2.X .. lineSegment.EndPoint1.X }
                    else
                        seq { lineSegment.EndPoint1.X .. lineSegment.EndPoint2.X }
                    |> Seq.map(fun xCoordinate -> { X = xCoordinate; Y = lineSegment.EndPoint1.Y })
                Some coordinates
            else
                None
        
        let Execute: unit =
            printfn "\nDay 5 / Part 1 Result:\n"

            let lineOverlaps =
                Common.getData ".\Data\input5.txt"
                    |> getLineSegments
                    |> lineSegmentsToCoordinateOccurrenceIntersections <| lineSegmentToCoordinates
                    |> Seq.length

            printfn "Overlap Count: %i" <| lineOverlaps

    module Part2 =
        let Execute: unit =
            printfn "\nDay 5 / Part 2 Result:\n"

    let Execute: unit =
        Part1.Execute
        Part2.Execute
