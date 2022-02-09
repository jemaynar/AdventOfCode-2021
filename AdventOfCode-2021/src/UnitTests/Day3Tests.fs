module UnitTests.Day3Tests
    open System.Collections.Generic
    open Xunit
    
    [<Fact>]
    let ``toSequenceOfBitArrays: { "000000000000" } -> { [| for i in 1 .. 12 -> 0 |] }`` () =
        let binaryStrings = seq { yield "000000000000" }
        
        let result = Day3.toSequenceOfBitArrays binaryStrings

        let expectedResult = seq { yield [| for i in 1 .. 12 -> 0 |] }
        Assert.Equal<IEnumerable<int[]>>(result, expectedResult)
        
    [<Fact>]
    let ``toSequenceOfBitArrays: { "111111111111" } -> { [| for i in 1 .. 12 -> 1 |] }`` () =
        let binaryStrings = seq { yield "111111111111" }
        
        let result = Day3.toSequenceOfBitArrays binaryStrings

        let expectedResult = seq { yield [| for i in 1 .. 12 -> 1 |] }
        Assert.Equal<IEnumerable<int[]>>(result, expectedResult)
        
    [<Fact>]
    let ``toArrayOfBinaryStrings: { [| for in in 1 .. 12 -> 0 |] } -> { "000000000000" }`` () =
        let sequenceOfArrayOfInts = seq { yield [| for i in 1 .. 12 -> 0 |] } 
        
        let result = Day3.toArrayOfBinaryStrings sequenceOfArrayOfInts

        let expectedResult = seq { yield "000000000000" }
        Assert.Equal<IEnumerable<string>>(result, expectedResult)
        
    [<Fact>]
    let ``toArrayOfBinaryStrings: { [| for in in 1 .. 12 -> 1 |] } -> { "111111111111" }`` () =
        let sequenceOfArrayOfInts = seq { yield [| for i in 1 .. 12 -> 1 |] } 
        
        let result = Day3.toArrayOfBinaryStrings sequenceOfArrayOfInts

        let expectedResult = seq { yield "111111111111" }
        Assert.Equal<IEnumerable<string>>(result, expectedResult)
        
    [<Fact>]
    let ``pivotSequenceOfBitArrays: a sequence 2 elements the first of 12 0's and the second of 12 1's is transformed to 12 arrays containing [| 0; 1 |]`` () =
        let sequenceOfArrayOfInts = seq { for x in 0 .. 1 -> [| for i in 1 .. 12 -> x |] } 
        
        let result = Day3.pivotSequenceOfBitArrays sequenceOfArrayOfInts |> Seq.map(Seq.toArray)
        
        let expectedResult = seq { for x in 1 .. 12 -> [| 0; 1 |] }
        Assert.Equal<IEnumerable<int[]>>(result, expectedResult)