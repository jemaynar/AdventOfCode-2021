module Day4
    type BingoCell = { IsSelected: bool; Value: byte }
    
    let drawnNumbers (inputLines: seq<string>): int[] =
        let firstLine = inputLines |> Seq.head
    
        firstLine.Split ',' |> Array.map(int)
    
    module Part1 =
        let Execute: unit =
            printfn "\nDay 4 / Part 1 Result:\n"
        
            let lines = Common.getData ".\Data\input4.txt"
                
            let picks = drawnNumbers <| lines
            
            printfn "DrawnNumbers: %A" <| picks
        
    let Execute: unit =
        Part1.Execute