module UnitTests.Day4Tests
    open Xunit
    open Day4

    [<Fact>]
    let ``getDrawnNumbers: when input line is empty string then returns empty array`` () =
        let inputLines = seq { "" }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>(result, Array.empty)
        
    [<Fact>]
    let ``getDrawnNumbers: when input line is "1" then result is array containing 1`` () =
        let inputLines = seq { "1" }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>([| 1 |], result)
                
    [<Fact>]
    let ``getDrawnNumbers: when input line is "1,," then result is array containing 1`` () =
        let inputLines = seq { "1,," }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<int[]>([| 1 |], result)
        
    [<Fact>]
    let ``getDrawnNumbers: when input line is "1,a," then result is array containing 1`` () =
        let inputLines = seq { "1,a," }
        
        let result = getDrawnNumbers <| inputLines
        
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
        
        let result = getGameBoards <| inputLines
        
        Assert.Equal<seq<BingoCell[,]>>(
            seq { 
                array2D [
                    [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 0uy }];
                    [{ IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 24uy }];
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 7uy }]; 
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 5uy }]; 
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 19uy }];
                ]
            },
            result)
        