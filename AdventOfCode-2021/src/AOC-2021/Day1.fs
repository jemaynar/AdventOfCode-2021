module Day1
    open System

    let Execute =
        let lines = System.IO.File.ReadLines(".\Data\input1.txt")

        // Show Data
        // lines |> Seq.iter(fun(x) -> printfn "%s" x)

        let depths = 
            lines |> Seq.map(fun(x) -> Convert.ToInt32(x)) 
                |> Seq.pairwise 
                |> Seq.map(fun (previous, next) -> if next > previous then 1 else 0)
                |> Seq.sum

        printfn "Day 1 Result: \n\n%A" <| depths