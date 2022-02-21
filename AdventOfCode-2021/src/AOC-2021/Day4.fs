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
                
    let parseLine (line: string) =
        let ints = line.Split ' '
        if Array.isEmpty <| ints then
            Array.empty
        else
            ints
                |> Seq.choose(fun n -> match Byte.TryParse(n) with | true, n -> Some { IsSelected = false; Value = n } | false, _ -> None)
                |> Array.ofSeq
                
    let getGameBoard (inputLines: seq<string>): BingoCell[,] =
        let array = inputLines |> Seq.map(parseLine) |> Seq.toArray
        Array2D.init 5 5 (fun i j -> array[i][j]) 
                
    let getGameBoards (inputLines: seq<string>): seq<BingoCell[,]> =
        inputLines
            |> Seq.skip 2
            |> Seq.filter(fun line -> line <> "")
            |> Seq.unfold(fun state ->
                if (Seq.isEmpty <| state) then
                    None
                else
                    let gameBoard = state |> Seq.take 5 |> getGameBoard
                    let newState = state |> Seq.skip 5
                    Some(gameBoard, newState))
            
    let isWinner(gameBoard: BingoCell[,]): bool =
        gameBoard[0,..5] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
                  
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