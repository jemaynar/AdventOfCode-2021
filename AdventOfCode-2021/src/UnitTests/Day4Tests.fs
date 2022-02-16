module UnitTests.Day4Tests
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
        
    [<Fact>]
    let ``getGameBoards: when input contains single game board then result is Array2D containing game board values`` () =
        let inputLines = seq {
            "1,2,3,4,5";
            "";
            "22 13 17 11  0";
            " 8  2 23  4 24";
            "21  9 14 16  7";
            " 6 10  3 18  5";
            " 1 12 20 15 19"
        }
        
        let result = Day4.getGameBoards <| inputLines
        
        Assert.Equal(array2D [[ 22; 13; 17; 11; 0 ]; [8; 2; 23; 4; 24]; [21; 9; 14; 16; 7]; [6; 10; 3; 18; 5]; [1; 12; 20; 15; 19]], result)
        