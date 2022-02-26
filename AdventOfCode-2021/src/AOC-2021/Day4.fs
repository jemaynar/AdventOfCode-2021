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
            let result =
                (gameBoards, 0)
                    // Unfold must return Some Tuple or None
                    // Some fst: Value yielded from sequence for this iteration.
                    // Some snd: State to be passed to next iteration of generator function. 
                    |> Seq.unfold(fun tuple ->
                        let index = snd tuple
                        if index = -1 then
                            None
                        else
                            let boardState = fst tuple
                            let updatedBoards = applyPickToGameBoards(boardState, picks.[index])
                            let firstWinner = firstWinner <| updatedBoards
                            
                            if Option.isNone <| firstWinner then
                                Some((updatedBoards, picks |> Seq.truncate (index + 1)), (updatedBoards, index + 1))
                            else
                                Some((updatedBoards, picks |> Seq.truncate (index + 1)), (updatedBoards, -1)))
                    |> Seq.last
                    
            let winner = fst result |> firstWinner

            winner |> Option.map(fun w -> { Board = w; AppliedPicks = snd result |> Seq.toArray; } )

    let calculateSumOfUnmarkedBingoCells (winner: Option<Winner>): Option<int> =
            winner
                |> Option.map(
                    fun w ->
                        w.Board
                            |> Seq.cast<BingoCell> 
                            |> Seq.filter(fun c -> c.IsSelected = false)
                            |> Seq.map(fun c -> c.Value |> Convert.ToInt32)
                            |> Seq.sum)
        
    let lastPick (winner: Option<Winner>): Option<int> =
        winner
            |> Option.map(
                fun w ->
                    w.AppliedPicks
                        |> Array.map(Convert.ToInt32)
                        |> Array.last)

    let calculateScore (winner: Option<Winner>): int =
        let sumOfUnmarkedCells =
            winner
                |> calculateSumOfUnmarkedBingoCells
                |> function 
                    | Some(value) -> value
                    | None -> 0

        let pick =
            winner
                |> lastPick
                |> function
                    | Some(value) -> value
                    | None -> 0

        sumOfUnmarkedCells * pick

    module Part1 =
        let Execute: unit =
            printfn "\nDay 4 / Part 1 Result:\n"
        
            let lines = Common.getData ".\Data\input4.txt"
            let picks = getDrawnNumbers <| lines
            let gameBoards = getGameBoards <| lines
            
            let winningScore =
                applyPicksUntilWinnerFound(gameBoards, picks)
                    |> calculateScore
                    
            printfn "Winning Score: %A" <| winningScore
        
    let Execute: unit =
        Part1.Execute