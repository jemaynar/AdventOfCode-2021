module Day2
    open System

    type CoordinateType = { Position: int; Depth: int; Aim: int }

    module Coordinate =
        let parsePositionData (rowStringData: string): CoordinateType = 
            let columns = rowStringData.Split(' ')
            match columns[0] with
            | "forward" -> { Position = Convert.ToInt32(columns[1]); Depth = 0; Aim = 0; }
            | "down"    -> { Position = 0; Depth = 0; Aim = Convert.ToInt32(columns[1]) }
            | "up"      -> { Position = 0; Depth = 0; Aim = -(Convert.ToInt32(columns[1])) }
            | _         -> { Position = 0; Depth = 0; Aim = 0 }

        let sumCoordinate accum next = { Position = accum.Position + next.Position; Depth = (next.Position * (accum.Aim + next.Aim)) + accum.Depth; Aim = accum.Aim + next.Aim; }

        let positionProduct x = x.Position * x.Depth

        let displayCoordinate x = printfn "%A" <| x

    let Execute =
        let lines = Common.getData ".\Data\input2.txt"

        // Parse all data
        let allCoordinates = lines |> Seq.map(Coordinate.parsePositionData)

        // Show Data
        // allCoordinates |> Seq.iter(Coordinate.displayCoordinate)

        // Reduce all coordinates (using sumPositionData function)
        let finalPosition = allCoordinates |> Seq.reduce(Coordinate.sumCoordinate)

        // Multiply Position by Depth.
        let positionProduct = finalPosition.Position * finalPosition.Depth

        // Display result
        printfn "\nDay 2 Result:"
        printfn "\nFinal Position:\n %A" <| finalPosition
        printfn "Position Product: %t" <| Common.printReadableNumber positionProduct