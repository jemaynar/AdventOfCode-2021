module Day4
    open System

    type BingoCell = { IsSelected: bool; Value: byte }
    
    let getDrawnNumbers (inputLines: seq<string>): int[] =
        let firstLine = inputLines |> Seq.head

        let ints = firstLine.Split ','
        if Array.isEmpty <| ints then
            Array.empty
        else
            ints
                |> Seq.choose(fun n -> match Int32.TryParse(n) with | true, n -> Some n | false, _ -> None)
                |> Array.ofSeq
                
    let getGameBoards (inputLines: seq<string>) =
        array2D [[ 22; 13; 17; 11; 0 ]; [8; 2; 23; 4; 24]; [21; 9; 14; 16; 7]; [6; 10; 3; 18; 5]; [1; 12; 20; 15; 19]]
                
    module Part1 =
        let Execute: unit =
            printfn "\nDay 4 / Part 1 Result:\n"
        
            let lines = Common.getData ".\Data\input4.txt"
                
            let picks = getDrawnNumbers <| lines
            
            printfn "DrawnNumbers: %A" <| picks
            
            let gameBoards = getGameBoards <| lines
            
            printfn "GameBoards: %A" <| gameBoards
        
    let Execute: unit =
        Part1.Execute