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
                
    module Part1 =
        let Execute: unit =
            printfn "\nDay 4 / Part 1 Result:\n"
        
            let lines = Common.getData ".\Data\input4.txt"
                
            let picks = getDrawnNumbers <| lines
            
            printfn "DrawnNumbers: %A" <| picks
        
    let Execute: unit =
        Part1.Execute