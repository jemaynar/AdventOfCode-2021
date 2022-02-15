module Day4Tests
    open Xunit

    [<Fact>]
    let ``getDrawnNumbers: when input line is empty string then returns empty array`` () =
        let inputLines = seq { "" }
        
        let result = Day4.getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>(result, Array.empty)
        
    [<Fact>]
    let ``getDrawnNumbers: when input line is "1" then result is array containing 1`` () =
        let inputLines = seq { "1" }
        
        let result = Day4.getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>([| 1 |], result)
                
    [<Fact>]
    let ``getDrawnNumbers: when input line is "1,," then result is array containing 1`` () =
        let inputLines = seq { "1,," }
        
        let result = Day4.getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>([| 1 |], result)
        
    [<Fact>]
    let ``getDrawnNumbers: when input line is "1,a," then result is array containing 1`` () =
        let inputLines = seq { "1,a," }
        
        let result = Day4.getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>([| 1 |], result)