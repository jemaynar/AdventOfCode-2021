open System

// For more information see https://aka.ms/fsharp-console-apps
let lines = System.IO.File.ReadLines(".\Data\input2.txt")

type Coordinate = { Position: int; Depth: int }

let parsePositionData (rowStringData: string): Coordinate = 
    let columns = rowStringData.Split(' ')
    match columns[0] with
    | "forward" -> { Position = Convert.ToInt32(columns[1]); Depth = 0 }
    | "down"    -> { Position = 0; Depth = Convert.ToInt32(columns[1]) }
    | "up"      -> { Position = 0; Depth = -(Convert.ToInt32(columns[1])) }
    | _         -> { Position = 0; Depth = 0 }

// Parse all data
let allCoordinates = lines |> Seq.map(fun(x) -> parsePositionData(x))

// Show Data
let showData x = printfn "%A" <| x
allCoordinates |> Seq.iter(showData)

// Reduce all coordinates (using sumPosotionData function)
let sumPositionData x y = { Position = x.Position + y.Position; Depth = x.Depth + y.Depth }
let finalPosition = allCoordinates |> Seq.reduce(sumPositionData)

// Multiply Position by Depth.
let positionProduct = finalPosition.Position * finalPosition.Depth

// Display result
printfn "\nFinal Position: %A" <| finalPosition
printfn "\nPosition Product: %s" <| (positionProduct).ToString("N0")