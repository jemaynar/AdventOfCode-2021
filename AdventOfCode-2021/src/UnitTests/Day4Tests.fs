module UnitTests.Day4Tests
    open Xunit
    open Day4

    [<Fact>]
    let ``getDrawnNumbers: When input line is empty string then returns empty array`` () =
        let inputLines = seq { "" }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<byte[]>(result, Array.empty)
        
    [<Fact>]
    let ``getDrawnNumbers: When input line is "1" then result is array containing 1`` () =
        let inputLines = seq { "1" }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<byte[]>([| 1uy |], result)
                
    [<Fact>]
    let ``getDrawnNumbers: When input line is "1,," then result is array containing 1`` () =
        let inputLines = seq { "1,," }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<byte[]>([| 1uy |], result)
        
    [<Fact>]
    let ``getDrawnNumbers: When input line is "1,a," then result is array containing 1`` () =
        let inputLines = seq { "1,a," }
        
        let result = getDrawnNumbers <| inputLines
        
        Assert.Equal<byte[]>([| 1uy |], result)
        
    [<Fact>]
    let ``parseLine: When line contains 5 numbers then result is 5 BingoCells`` () =
        let inputLine = "22 13 17 11  0"
        
        let result = parseLine(inputLine)
        
        Assert.Equal<BingoCell[]>(
            [|
                { IsSelected = false; Value = 22uy }
                { IsSelected = false; Value = 13uy }
                { IsSelected = false; Value = 17uy }
                { IsSelected = false; Value = 11uy }
                { IsSelected = false; Value = 0uy }
            |], result)
        
    [<Fact>]
    let ``getGameBoard: Returns expected BingoCell Array2D`` () =
        let inputLines = seq {
            "22 13 17 11  0";
            " 8  2 23  4 24";
            "21  9 14 16  7";
            " 6 10  3 18  5";
            " 1 12 20 15 19"
        }
        
        let result = getGameBoard <| inputLines
        
        Assert.Equal<BingoCell[,]>(
            array2D [
                [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 0uy }];
                [{ IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 24uy }];
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 7uy }]; 
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 5uy }]; 
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 19uy }];
            ], result)
        
    [<Fact>]
    let ``getGameBoards: When input contains single game board then result is sequence containing single Array2D containing game board values`` () =
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
        
    [<Fact>]
    let ``getGameBoards: When input contains two game boards then result is sequence containing two Array2Ds containing game board values`` () =
        let inputLines = seq {
            "1,2,3,4,5";
            "";
            "22 13 17 11  0";
            " 8  2 23  4 24";
            "21  9 14 16  7";
            " 6 10  3 18  5";
            " 1 12 20 15 19";
            "";
            "68 56 28 57 12";
            "78 66 20 85 51";
            "35 23  7 99 44";
            "86 37  8 45 49";
            "40 77 32  6 88";
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
                ];
                array2D [
                    [{ IsSelected = false; Value = 68uy }; { IsSelected = false; Value = 56uy }; { IsSelected = false; Value = 28uy }; { IsSelected = false; Value = 57uy }; { IsSelected = false; Value = 12uy }];
                    [{ IsSelected = false; Value = 78uy }; { IsSelected = false; Value = 66uy }; { IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 85uy }; { IsSelected = false; Value = 51uy }];
                    [{ IsSelected = false; Value = 35uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 99uy }; { IsSelected = false; Value = 44uy }]; 
                    [{ IsSelected = false; Value = 86uy }; { IsSelected = false; Value = 37uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 45uy }; { IsSelected = false; Value = 49uy }]; 
                    [{ IsSelected = false; Value = 40uy }; { IsSelected = false; Value = 77uy }; { IsSelected = false; Value = 32uy }; { IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 88uy }];
                ];
            },
            result)
        
    [<Fact>]
    let ``isWinner: When fewer than 5 numbers selected returns false`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = true; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(false, result) 

    [<Fact>]
    let ``isWinner: When all 5 numbers in 1st row selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = true; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result) 

    [<Fact>]
    let ``isWinner: When all 5 numbers in 2nd row selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = true; Value = 6uy }; { IsSelected = true; Value = 7uy }; { IsSelected = true; Value = 8uy }; { IsSelected = true; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result)

    [<Fact>]
    let ``isWinner: When all 5 numbers in 3rd row selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = true; Value = 11uy }; { IsSelected = true; Value = 12uy }; { IsSelected = true; Value = 13uy }; { IsSelected = true; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result) 

    [<Fact>]
    let ``isWinner: When all 5 numbers in 4th row selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = true; Value = 16uy }; { IsSelected = true; Value = 17uy }; { IsSelected = true; Value = 18uy }; { IsSelected = true; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result) 

    [<Fact>]
    let ``isWinner: When all 5 numbers in 5th row selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = true; Value = 21uy }; { IsSelected = true; Value = 22uy }; { IsSelected = true; Value = 23uy }; { IsSelected = true; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result) 

    [<Fact>]
    let ``isWinner: When all 5 numbers in 1st column selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = true; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = true; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = true; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = true; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = true; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result)

    [<Fact>]
    let ``isWinner: When all 5 numbers in 2nd column selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = true; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = true; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = true; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = true; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result)

    [<Fact>]
    let ``isWinner: When all 5 numbers in 3rd column selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = true; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = true; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = true; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = true; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result)

    [<Fact>]
    let ``isWinner: When all 5 numbers in 4th column selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = true; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = true; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = true; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = true; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result)
 
    [<Fact>]
    let ``isWinner: When all 5 numbers in 5th column selected returns true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ]
            
        let result = isWinner <| gameBoard
        
        Assert.Equal<bool>(true, result)
        
    [<Fact>]
    let ``firstWinner: When no supplied board is winner returns None`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
            }
            
        let result = firstWinner <| gameBoards
        
        Assert.Equal<Option<BingoCell[,]>>(None, result)
        
    [<Fact>]
    let ``firstWinner: When first board is winner returns the winning game board`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = true; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = true; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = true; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = true; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = true; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
            }
            
        let result = firstWinner <| gameBoards
        
        let expectedResult =
            array2D [
                [{ IsSelected = true; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = true; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = true; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = true; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = true; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
        Assert.Equal<Option<BingoCell[,]>>(
            Some expectedResult,
            result)

    [<Fact>]
    let ``applyPickToGameBoard: When pick does not exist in game board then returns original game board`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = applyPickToGameBoard(gameBoard, 26uy)
        
        Assert.Equal<BingoCell[,]>(
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ],
            result)

    [<Fact>]
    let ``applyPickToGameBoard: When pick does exists in game board once then returns original game board with IsSelected flipped equal to true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ]
            
        let result = applyPickToGameBoard(gameBoard, 1uy)
        
        Assert.Equal<BingoCell[,]>(
            array2D [
                [{ IsSelected = true; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
            ],
            result);

    [<Fact>]
    let ``applyPickToGameBoards: When pick does not exist in any game board returns origin game boards`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
            }
        
        let result = applyPickToGameBoards(gameBoards, 26uy)
        
        Assert.Equal<BingoCell[,]>(
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
            },
            result);

    [<Fact>]
    let ``applyPickToGameBoards: When pick does exists in both game boards then returns origin game board with IsSelected set to true`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
                array2D [
                    [{ IsSelected = false; Value = 25uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 21uy }];
                    [{ IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 16uy }];
                    [{ IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 11uy }]; 
                    [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 6uy }]; 
                    [{ IsSelected = false; Value = 5uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 1uy }];
                ]
            }
        
        let result = applyPickToGameBoards(gameBoards, 1uy)
        
        Assert.Equal<BingoCell[,]>(
            seq {
                array2D [
                    [{ IsSelected = true; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
                array2D [
                    [{ IsSelected = false; Value = 25uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 21uy }];
                    [{ IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 16uy }];
                    [{ IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 11uy }]; 
                    [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 6uy }]; 
                    [{ IsSelected = false; Value = 5uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 2uy }; { IsSelected = true; Value = 1uy }];
                ]
            },
            result)
        
    [<Fact>]
    let ``applyPicksUntilWinnerFound: When fewer than 5 picks then returns None`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
            }
        let picks = [| 1uy; 2uy; 3uy; 4uy; |]
            
        let result = applyPicksUntilWinnerFound(gameBoards, picks)
        
        Assert.Equal<Option<Winner>>(None, result)
        
    [<Fact>]
    let ``applyPicksUntilWinnerFound: When 5 picks that cause a winner then returns Winner`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ]
            }
        let picks = [| 1uy; 2uy; 3uy; 4uy; 5uy; |]
            
        let result = applyPicksUntilWinnerFound(gameBoards, picks)
        
        Assert.Equal<Option<Winner>>(
            Some {
                Board = array2D [
                    [{ IsSelected = true; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
                AppliedPicks = [| 1uy; 2uy; 3uy; 4uy; 5uy; |];
            }, result)
        
    [<Fact>]
    let ``applyPicksUntilWinnerFound: When 5 picks that cause a winner on second game board then returns Winner`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = false; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
                array2D [
                    [{ IsSelected = false; Value = 26uy }; { IsSelected = false; Value = 27uy }; { IsSelected = false; Value = 28uy }; { IsSelected = false; Value = 29uy }; { IsSelected = false; Value = 30uy }];
                    [{ IsSelected = false; Value = 31uy }; { IsSelected = false; Value = 32uy }; { IsSelected = false; Value = 33uy }; { IsSelected = false; Value = 34uy }; { IsSelected = false; Value = 35uy }];
                    [{ IsSelected = false; Value = 36uy }; { IsSelected = false; Value = 37uy }; { IsSelected = false; Value = 38uy }; { IsSelected = false; Value = 39uy }; { IsSelected = false; Value = 40uy }]; 
                    [{ IsSelected = false; Value = 41uy }; { IsSelected = false; Value = 42uy }; { IsSelected = false; Value = 43uy }; { IsSelected = false; Value = 44uy }; { IsSelected = false; Value = 45uy }]; 
                    [{ IsSelected = false; Value = 46uy }; { IsSelected = false; Value = 47uy }; { IsSelected = false; Value = 48uy }; { IsSelected = false; Value = 49uy }; { IsSelected = false; Value = 50uy }];
                ]
            }

        let picks = [| 26uy; 31uy; 36uy; 41uy; 46uy; |]
            
        let result = applyPicksUntilWinnerFound(gameBoards, picks)
        
        Assert.Equal<Option<Winner>>(
            Some {
                Board = array2D [
                    [{ IsSelected = true; Value = 26uy }; { IsSelected = false; Value = 27uy }; { IsSelected = false; Value = 28uy }; { IsSelected = false; Value = 29uy }; { IsSelected = false; Value = 30uy }];
                    [{ IsSelected = true; Value = 31uy }; { IsSelected = false; Value = 32uy }; { IsSelected = false; Value = 33uy }; { IsSelected = false; Value = 34uy }; { IsSelected = false; Value = 35uy }];
                    [{ IsSelected = true; Value = 36uy }; { IsSelected = false; Value = 37uy }; { IsSelected = false; Value = 38uy }; { IsSelected = false; Value = 39uy }; { IsSelected = false; Value = 40uy }]; 
                    [{ IsSelected = true; Value = 41uy }; { IsSelected = false; Value = 42uy }; { IsSelected = false; Value = 43uy }; { IsSelected = false; Value = 44uy }; { IsSelected = false; Value = 45uy }]; 
                    [{ IsSelected = true; Value = 46uy }; { IsSelected = false; Value = 47uy }; { IsSelected = false; Value = 48uy }; { IsSelected = false; Value = 49uy }; { IsSelected = false; Value = 50uy }];
                ];
                AppliedPicks = [| 26uy; 31uy; 36uy; 41uy; 46uy; |];
            }, result)

    [<Fact>]
    let ``applyPicksUntilWinnerFound: When 27 picks picks from part 1 description when 3 boards from description then returns third board and first 12 picks as winner.`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value =  0uy }];
                    [{ IsSelected = false; Value =  8uy }; { IsSelected = false; Value =  2uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value =  4uy }; { IsSelected = false; Value = 24uy }];
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value =  9uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value =  7uy }]; 
                    [{ IsSelected = false; Value =  6uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value =  3uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  5uy }]; 
                    [{ IsSelected = false; Value =  1uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 19uy }];
                ];
                array2D [
                    [{ IsSelected = false; Value =  3uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value =  0uy }; { IsSelected = false; Value =  2uy }; { IsSelected = false; Value = 22uy }];
                    [{ IsSelected = false; Value =  9uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value =  5uy }];
                    [{ IsSelected = false; Value = 19uy }; { IsSelected = false; Value =  8uy }; { IsSelected = false; Value =  7uy }; { IsSelected = false; Value = 25uy }; { IsSelected = false; Value = 23uy }]; 
                    [{ IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value =  4uy }]; 
                    [{ IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  6uy }];
                ];
                array2D [
                    [{ IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value =  4uy }];
                    [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value =  9uy }; { IsSelected = false; Value = 19uy }];
                    [{ IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  8uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 26uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value =  6uy }; { IsSelected = false; Value =  5uy }]; 
                    [{ IsSelected = false; Value =  2uy }; { IsSelected = false; Value =  0uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  3uy }; { IsSelected = false; Value =  7uy }];
                ]
            }

        let picks = [| 7uy; 4uy; 9uy; 5uy; 11uy; 17uy; 23uy; 2uy; 0uy; 14uy; 21uy; 24uy; 10uy; 16uy; 13uy; 6uy; 15uy; 25uy; 12uy; 22uy; 18uy; 20uy; 8uy; 19uy; 3uy; 26uy; 1uy; |]
            
        let result = applyPicksUntilWinnerFound(gameBoards, picks)
        
        Assert.Equal<Option<Winner>>(
            Some {
                Board = array2D [
                    [{ IsSelected = true; Value = 14uy }; { IsSelected = true; Value = 21uy }; { IsSelected = true; Value = 17uy }; { IsSelected = true; Value = 24uy }; { IsSelected = true; Value =  4uy }];
                    [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 15uy }; { IsSelected = true; Value =  9uy }; { IsSelected = false; Value = 19uy }];
                    [{ IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  8uy }; { IsSelected = true; Value = 23uy }; { IsSelected = false; Value = 26uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 22uy }; { IsSelected = true; Value = 11uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value =  6uy }; { IsSelected = true; Value =  5uy }]; 
                    [{ IsSelected = true; Value =  2uy }; { IsSelected = true; Value =  0uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  3uy }; { IsSelected = true; Value =  7uy }];
                ]
                AppliedPicks = [| 7uy; 4uy; 9uy; 5uy; 11uy; 17uy; 23uy; 2uy; 0uy; 14uy; 21uy; 24uy; |];
            }, result)
        
    [<Fact>]
    let ``calculateSumOfUnmarkedBingoCells: when sum of all unmarked numbers on winning board is 188 then returns 188`` () =
        let winner =
            Some {
                Board = 
                    array2D [
                        [{ IsSelected = true; Value = 14uy }; { IsSelected = true; Value = 21uy }; { IsSelected = true; Value = 17uy }; { IsSelected = true; Value = 24uy }; { IsSelected = true; Value =  4uy }];
                        [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 15uy }; { IsSelected = true; Value =  9uy }; { IsSelected = false; Value = 19uy }];
                        [{ IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  8uy }; { IsSelected = true; Value = 23uy }; { IsSelected = false; Value = 26uy }; { IsSelected = false; Value = 20uy }]; 
                        [{ IsSelected = false; Value = 22uy }; { IsSelected = true; Value = 11uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value =  6uy }; { IsSelected = true; Value =  5uy }]; 
                        [{ IsSelected = true; Value =  2uy }; { IsSelected = true; Value =  0uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  3uy }; { IsSelected = true; Value =  7uy }];
                    ];
                AppliedPicks = [| 7uy; 4uy; 9uy; 5uy; 11uy; 17uy; 23uy; 2uy; 0uy; 14uy; 21uy; 24uy; |]
            }

        let result = winner |> calculateSumOfUnmarkedBingoCells
        
        Assert.Equal<Option<int>>(Some 188, result)
        
    [<Fact>]
    let ``calculateSumOfUnmarkedBingoCells: When 5 picks that cause a winner, when sum of all unmarked numbers on winning board is 310 then returns 310`` () =
        let winner =
            Some {
                Board = array2D [
                    [{ IsSelected = true; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
                AppliedPicks = [| 1uy; 2uy; 3uy; 4uy; 5uy; |]
            }
            
        let result = winner |> calculateSumOfUnmarkedBingoCells
        
        Assert.Equal<Option<int>>(Some 310, result)
        
    [<Fact>]
    let ``calculateScore: When 5 picks that cause a winner, when sum of all unmarked numbers on winning board is 310 and last pick is 5 then result is 1,550`` () =
        let winner =
            Some {
                Board = array2D [
                    [{ IsSelected = true; Value = 1uy }; { IsSelected = true; Value = 2uy }; { IsSelected = true; Value = 3uy }; { IsSelected = true; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = false; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value = 25uy }];
                ];
                AppliedPicks = [| 1uy; 2uy; 3uy; 4uy; 5uy; |]
            }
        
        let result = winner |> calculateScore
        
        Assert.Equal<int>(1550, result)
        
    [<Fact>]
    let ``calculateScore: When sum of all unmarked numbers on winning board is 188 when last number called was 24 then result is 4512`` () =
        let winner =
            Some {
                Board = 
                    array2D [
                        [{ IsSelected = true; Value = 14uy }; { IsSelected = true; Value = 21uy }; { IsSelected = true; Value = 17uy }; { IsSelected = true; Value = 24uy }; { IsSelected = true; Value =  4uy }];
                        [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 15uy }; { IsSelected = true; Value =  9uy }; { IsSelected = false; Value = 19uy }];
                        [{ IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  8uy }; { IsSelected = true; Value = 23uy }; { IsSelected = false; Value = 26uy }; { IsSelected = false; Value = 20uy }]; 
                        [{ IsSelected = false; Value = 22uy }; { IsSelected = true; Value = 11uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value =  6uy }; { IsSelected = true; Value =  5uy }]; 
                        [{ IsSelected = true; Value =  2uy }; { IsSelected = true; Value =  0uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  3uy }; { IsSelected = true; Value =  7uy }];
                    ];
                AppliedPicks = [| 7uy; 4uy; 9uy; 5uy; 11uy; 17uy; 23uy; 2uy; 0uy; 14uy; 21uy; 24uy; |]
            }

        let result = winner |> calculateScore
        
        Assert.Equal<int>(4512, result)

    [<Fact>]
    let ``applyPicksUntilLastWinnerFound: When 27 picks picks from part 1 description when 3 boards from description then returns third board and first 15 picks as last winner.`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value =  0uy }];
                    [{ IsSelected = false; Value =  8uy }; { IsSelected = false; Value =  2uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value =  4uy }; { IsSelected = false; Value = 24uy }];
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value =  9uy }; { IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value =  7uy }]; 
                    [{ IsSelected = false; Value =  6uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value =  3uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  5uy }]; 
                    [{ IsSelected = false; Value =  1uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value = 19uy }];
                ];
                array2D [
                    [{ IsSelected = false; Value =  3uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value =  0uy }; { IsSelected = false; Value =  2uy }; { IsSelected = false; Value = 22uy }];
                    [{ IsSelected = false; Value =  9uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value =  5uy }];
                    [{ IsSelected = false; Value = 19uy }; { IsSelected = false; Value =  8uy }; { IsSelected = false; Value =  7uy }; { IsSelected = false; Value = 25uy }; { IsSelected = false; Value = 23uy }]; 
                    [{ IsSelected = false; Value = 20uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value =  4uy }]; 
                    [{ IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  6uy }];
                ];
                array2D [
                    [{ IsSelected = false; Value = 14uy }; { IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 24uy }; { IsSelected = false; Value =  4uy }];
                    [{ IsSelected = false; Value = 10uy }; { IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 15uy }; { IsSelected = false; Value =  9uy }; { IsSelected = false; Value = 19uy }];
                    [{ IsSelected = false; Value = 18uy }; { IsSelected = false; Value =  8uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 26uy }; { IsSelected = false; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value =  6uy }; { IsSelected = false; Value =  5uy }]; 
                    [{ IsSelected = false; Value =  2uy }; { IsSelected = false; Value =  0uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  3uy }; { IsSelected = false; Value =  7uy }];
                ]
            }

        let picks = [| 7uy; 4uy; 9uy; 5uy; 11uy; 17uy; 23uy; 2uy; 0uy; 14uy; 21uy; 24uy; 10uy; 16uy; 13uy; 6uy; 15uy; 25uy; 12uy; 22uy; 18uy; 20uy; 8uy; 19uy; 3uy; 26uy; 1uy; |]
            
        let result = applyPicksUntilLastWinnerFound(gameBoards, picks)
        
        Assert.Equal<Option<Winner>>(
            Some {
                Board = array2D [
                    [{ IsSelected = false; Value =  3uy }; { IsSelected = false; Value = 15uy }; { IsSelected = true; Value =  0uy }; { IsSelected = true; Value =  2uy }; { IsSelected = false; Value = 22uy }];
                    [{ IsSelected = true; Value =  9uy }; { IsSelected = false; Value = 18uy }; { IsSelected = true; Value = 13uy }; { IsSelected = true; Value = 17uy }; { IsSelected = true; Value =  5uy }];
                    [{ IsSelected = false; Value = 19uy }; { IsSelected = false; Value =  8uy }; { IsSelected = true; Value =  7uy }; { IsSelected = false; Value = 25uy }; { IsSelected = true; Value = 23uy }]; 
                    [{ IsSelected = false; Value = 20uy }; { IsSelected = true; Value = 11uy }; { IsSelected = true; Value = 10uy }; { IsSelected = true; Value = 24uy }; { IsSelected = true; Value =  4uy }]; 
                    [{ IsSelected = true; Value = 14uy }; { IsSelected = true; Value = 21uy }; { IsSelected = true; Value = 16uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value =  6uy }];
                ];
                AppliedPicks = [| 7uy; 4uy; 9uy; 5uy; 11uy; 17uy; 23uy; 2uy; 0uy; 14uy; 21uy; 24uy; 10uy; 16uy; 13uy; |];
            }, result)
        