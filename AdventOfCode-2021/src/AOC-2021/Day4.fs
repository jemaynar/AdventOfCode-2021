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
                
    let getGameBoards (inputLines: seq<string>): seq<BingoCell[,]> =
        let gameBoards = seq {
            array2D [
                [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 0uy }];
                [{ IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 24uy }];
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 7uy }]; 
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 5uy }]; 
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 19uy }];
            ]
        }
        gameBoards
                
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