module Day4
    open System

    type BingoCell = { IsSelected: bool; Value: byte }
    type Winner = { Board: BingoCell[,]; AppliedPicks: byte[] }
    
    let getDrawnNumbers (inputLines: seq<string>): byte[] =
        let firstLine = inputLines |> Seq.head

        let bytes = firstLine.Split ','
        if Array.isEmpty <| bytes then
            Array.empty
        else
            bytes
                |> Seq.choose(fun n -> match Byte.TryParse(n) with | true, n -> Some n | false, _ -> None)
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
            || gameBoard[1,..5] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[2,..5] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[3,..5] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[4,..5] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[..5,0] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[..5,1] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[..5,2] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[..5,3] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            || gameBoard[..5,4] |> Array.filter(fun f -> f.IsSelected) |> Array.length = 5
            
    let firstWinner(gameBoards: seq<BingoCell[,]>): Option<BingoCell[,]> =
        gameBoards
            |> Seq.tryFind (fun board -> board |> isWinner)
    
    let applyPickToGameBoard(gameBoard: BingoCell[,], pick: byte) =
        gameBoard |> Array2D.map(fun cell ->
            if cell.Value = pick then
                { IsSelected = true; Value = cell.Value }
            else
                cell)
        
    let applyPickToGameBoards(gameBoards: seq<BingoCell[,]>, pick: byte) =
        gameBoards |> Seq.map(fun gameBoard -> applyPickToGameBoard(gameBoard, pick))
        
    let applyPicksUntilWinnerFound(gameBoards: seq<BingoCell[,]>, picks: byte[]): Option<Winner> =
        if picks |> Array.length < 5 then 
            None
        else
            Some {
                Board = array2D [
                    [{ IsSelected = true; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
                AppliedPicks = picks;
            }
    
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