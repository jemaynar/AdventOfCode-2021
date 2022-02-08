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
