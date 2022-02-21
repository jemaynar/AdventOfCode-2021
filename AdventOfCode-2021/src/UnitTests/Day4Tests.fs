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
    let ``parseLine: when line contains 5 numbers then result is 5 BingoCells`` () =
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
    let ``getGameBoard: returns expected BingoCell Array2D`` () =
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
    let ``getGameBoards: when input contains single game board then result is sequence containing single Array2D containing game board values`` () =
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
    let ``getGameBoards: when input contains two game boards then result is sequence containing two Array2Ds containing game board values`` () =
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
    let ``isWinner: when fewer than 5 numbers selected returns false`` () =
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
    let ``isWinner: when all 5 numbers in 1st row selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 2nd row selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 3rd row selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 4th row selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 5th row selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 1st column selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 2nd column selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 3rd column selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 4th column selected returns true`` () =
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
    let ``isWinner: when all 5 numbers in 5th column selected returns true`` () =
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
    let ``applyPickToGameBoard: when pick does not exist in game board then returns original game board`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ]
            
        let result = applyPickToGameBoard(gameBoard, 26uy)
        
        Assert.Equal<BingoCell[,]>(
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ],
            result)

    [<Fact>]
    let ``applyPickToGameBoard: when pick does exists in game board once then returns original gameBoard with IsSelected flipped equal to true`` () =
        let gameBoard =
            array2D [
                [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ]
            
        let result = applyPickToGameBoard(gameBoard, 1uy)
        
        Assert.Equal<BingoCell[,]>(
            array2D [
                [{ IsSelected = true; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
            ],
            result);

    [<Fact>]
    let ``applyPickToGameBoards: When pick does not exist in any game board returns origin gameBoards`` () =
        let gameBoards =
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
                ]
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
                ]
            }
        
        let result = applyPickToGameBoards(gameBoards, 26uy)
        
        Assert.Equal<BingoCell[,]>(
            seq {
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
                ]
                array2D [
                    [{ IsSelected = false; Value = 1uy }; { IsSelected = false; Value = 2uy }; { IsSelected = false; Value = 3uy }; { IsSelected = false; Value = 4uy }; { IsSelected = true; Value = 5uy }];
                    [{ IsSelected = false; Value = 6uy }; { IsSelected = false; Value = 7uy }; { IsSelected = false; Value = 8uy }; { IsSelected = false; Value = 9uy }; { IsSelected = true; Value = 10uy }];
                    [{ IsSelected = false; Value = 11uy }; { IsSelected = false; Value = 12uy }; { IsSelected = false; Value = 13uy }; { IsSelected = false; Value = 14uy }; { IsSelected = true; Value = 15uy }]; 
                    [{ IsSelected = false; Value = 16uy }; { IsSelected = false; Value = 17uy }; { IsSelected = false; Value = 18uy }; { IsSelected = false; Value = 19uy }; { IsSelected = true; Value = 20uy }]; 
                    [{ IsSelected = false; Value = 21uy }; { IsSelected = false; Value = 22uy }; { IsSelected = false; Value = 23uy }; { IsSelected = false; Value = 24uy }; { IsSelected = true; Value = 25uy }];
                ]
            },
            result);

        