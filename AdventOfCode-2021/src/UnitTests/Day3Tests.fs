module UnitTests.Day3Tests
    open System.Collections.Generic
    open Xunit
                
    [<Fact>]
    let ``toArrayOfBinaryStrings: { [| for in in 1 .. 12 -> 0 |] } -> { "000000000000" }`` () =
        let sequenceOfArrayOfInts = seq { yield [| for _ in 1 .. 12 -> 0 |] } 
        
        let result = Day3.toArrayOfBinaryStrings sequenceOfArrayOfInts

        let expectedResult = seq { yield "000000000000" }
        Assert.Equal<IEnumerable<string>>(result, expectedResult)
        
    [<Fact>]
    let ``toArrayOfBinaryStrings: { [| for in in 1 .. 12 -> 1 |] } -> { "111111111111" }`` () =
        let sequenceOfArrayOfInts = seq { yield [| for _ in 1 .. 12 -> 1 |] } 
        
        let result = Day3.toArrayOfBinaryStrings sequenceOfArrayOfInts

        let expectedResult = seq { yield "111111111111" }
        Assert.Equal<IEnumerable<string>>(expectedResult, result)
    
    [<Fact>]
    let ``toSequenceOfBitArrays: { "000000000000" } -> { [| for i in 1 .. 12 -> 0 |] }`` () =
        let binaryStrings = seq { yield "000000000000" }
        
        let result = Day3.toSequenceOfBitArrays binaryStrings

        let expectedResult = seq { yield [| for _ in 1 .. 12 -> 0 |] }
        Assert.Equal<IEnumerable<int[]>>(expectedResult, result)
        
    [<Fact>]
    let ``toSequenceOfBitArrays: { "111111111111" } -> { [| for i in 1 .. 12 -> 1 |] }`` () =
        let binaryStrings = seq { yield "111111111111" }
        
        let result = Day3.toSequenceOfBitArrays binaryStrings

        let expectedResult = seq { yield [| for _ in 1 .. 12 -> 1 |] }
        Assert.Equal<IEnumerable<int[]>>(expectedResult, result)
                
    [<Fact>]
    let ``pivotSequenceOfBitArrays: a sequence 2 elements the first of 12 0's and the second of 12 1's returns 12 arrays containing [| 0; 1 |]`` () =
        let sequenceOfArrayOfInts = seq { for x in 0 .. 1 -> [| for _ in 1 .. 12 -> x |] } 
        
        let result = Day3.pivotSequenceOfBitArrays sequenceOfArrayOfInts
        
        let expectedResult = seq { for _ in 1 .. 12 -> [| 0; 1 |] }
        Assert.Equal<IEnumerable<int[]>>(expectedResult, result)
        
    [<Fact>]
    let rec ``bitsToNumber: a sequence of 12 0s returns 0`` () =
        let sequenceOfBitsEqualToZero = seq { for _ in 1 .. 12 -> 0 }
        
        let result = sequenceOfBitsEqualToZero |> Day3.bitsToNumber
        
        Assert.Equal(0, result)
        
    [<Fact>]
    let ``bitsToNumber: a sequence of 12 1s returns 4095`` () =
        let sequenceOfBitsEqualToOne = seq { for _ in 1 .. 12 -> 1 }
        
        let result = sequenceOfBitsEqualToOne |> Day3.bitsToNumber
        
        Assert.Equal(4095, result)
        
    [<Fact>]
    let ``bitsToNumber: a sequence of 010101 returns 21`` () =
        let sequenceOfBitsEqualToTwentyOne = [| 0; 1; 0; 1; 0; 1 |]
        
        let result = sequenceOfBitsEqualToTwentyOne |> Day3.bitsToNumber
        
        Assert.Equal(21, result)
                
    [<Fact>]
    let ``bitsToNumber: a sequence of 000001 returns 1`` () =
        let sequenceOfBitsEqualToTwentyOne = [| 0; 0; 0; 0; 0; 1 |]
        
        let result = sequenceOfBitsEqualToTwentyOne |> Day3.bitsToNumber
        
        Assert.Equal(1, result)
        
    [<Fact>]
    let rec ``bitsToNumber: a sequence of 100000 returns 32`` () =
        let sequenceOfBitsEqualToTwentyOne = [| 1; 0; 0; 0; 0; 0 |]
        
        let result = sequenceOfBitsEqualToTwentyOne |> Day3.bitsToNumber
        
        Assert.Equal(32, result)

    [<Fact>]
    let ``mostCommonBit: a sequence of 1 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 1 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 0 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 0 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)

    [<Fact>]
    let ``mostCommonBit: a sequence of 11 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 1; 1 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 10 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 1; 0 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 1010 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 1; 0; 1; 0 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 1000 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 1; 0; 0; 0 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 00 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 0; 0 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 11; 11; returns seq { 1; 1 }`` () =
        let sequenceOfBits = seq { [| 1; 1 |]; [| 1; 1 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1; 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 10; 01; returns seq { 1; 1 }`` () =
        let sequenceOfBits = seq { [| 1; 0 |]; [| 0; 1 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1; 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 10; 01; 00; 11; returns seq { 1; 1; 0; 1 }`` () =
        let sequenceOfBits = seq { [| 1; 0 |]; [| 0; 1 |]; [| 0; 0 |]; [| 1; 1 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1; 1; 0; 1 |], result)
        
    [<Fact>]
    let ``mostCommonBit: a sequence of 100; 100; returns seq { 0; 0 }`` () =
        let sequenceOfBits = seq { [| 1; 0; 0 |]; [| 1; 0; 0 |] }
        
        let result = sequenceOfBits |> Day3.mostCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0; 0 |], result)
    
    [<Fact>]
    let ``leastCommonBit: a sequence of 1 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 1 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
            
    [<Fact>]
    let ``leastCommonBit: a sequence of 0 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
    
    [<Fact>]
    let ``leastCommonBit: a sequence of 11 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 1; 1 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 10 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 1; 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 01 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 0; 1 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 1010 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 1; 0; 1; 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 1000 returns seq { 0 }`` () =
        let sequenceOfBits = seq { [| 1; 0; 0; 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 00 returns seq { 1 }`` () =
        let sequenceOfBits = seq { [| 0; 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 11; 11 returns seq { 0; 0 }`` () =
        let sequenceOfBits = seq { [| 1; 1 |]; [| 1; 1 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0; 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 10; 10 returns seq { 0; 0 }`` () =
        let sequenceOfBits = seq { [| 1; 0 |]; [| 1; 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0; 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 100; 100; returns seq { 1; 1 }`` () =
        let sequenceOfBits = seq { [| 1; 0; 0 |]; [| 1; 0; 0 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 1; 1 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 11; 00; 01  returns seq { 0; 1; 0 }`` () =
        let sequenceOfBits = seq { [| 1; 1 |]; [| 0; 0 |]; [| 0; 1 |]; }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0; 1 ; 0 |], result)
        
    [<Fact>]
    let ``leastCommonBit: a sequence of 10; 01; 00; 11; returns seq { 0; 0; 1; 0 }`` () =
        let sequenceOfBits = seq { [| 1; 0 |]; [| 0; 1 |]; [| 0; 0 |]; [| 1; 1 |] }
        
        let result = sequenceOfBits |> Day3.leastCommonBit
       
        Assert.Equal<IEnumerable<int>>([| 0; 0; 1; 0 |], result)

    [<Fact>]
    let ``Part2.filterByArrayIndex: a sequence of bits with numeric values 4, 2, 1 when filtering index 0 with value 1 returns binary 4`` () =
        let sequenceOfBits =
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
                [| 0; 0; 1 |] // 1
            }

        let result = Day3.Part2.filterByArrayIndex sequenceOfBits 0 1
        
        Assert.Equal<IEnumerable<int[]>>(
            seq {
                [| 1; 0; 0 |] // 4
            }, result)
        
    [<Fact>]
    let ``Part2.filterByArrayIndex: a sequence of bits with numeric values 4, 2, 1 when filtering index 1 with value 1 returns binary 2`` () =
        let sequenceOfBits =
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
                [| 0; 0; 1 |] // 1
            }

        let result = Day3.Part2.filterByArrayIndex sequenceOfBits 1 1
        
        Assert.Equal<IEnumerable<int[]>>(
            seq {
                [| 0; 1; 0 |] // 2
            }, result)
        
    [<Fact>]
    let ``Part2.filterByArrayIndex: a sequence of bits with numeric values 4, 2, 1 when filtering index 3 with value 1 returns binary 1`` () =
        let sequenceOfBits =
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
                [| 0; 0; 1 |] // 1
            }

        let result = Day3.Part2.filterByArrayIndex sequenceOfBits 2 1
        
        Assert.Equal<IEnumerable<int[]>>(
            seq {
                [| 0; 0; 1 |] // 1
            }, result)

    [<Fact>]
    let ``Part2.filterByArrayIndex: a sequence of bits with numeric values 4, 2, 1 when filtering index 0 with value 0 returns binary 2 and 1`` () =
        let sequenceOfBits =
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
                [| 0; 0; 1 |] // 1
            }

        let result = Day3.Part2.filterByArrayIndex sequenceOfBits 0 0
        
        Assert.Equal<IEnumerable<int[]>>(
            seq {
                [| 0; 1; 0 |] // 2 
                [| 0; 0; 1 |] // 1
            }, result)
        
    [<Fact>]
    let ``Part2.filterByArrayIndex: a sequence of bits with numeric values 4, 2, 1 when filtering index 1 with value 0 returns binary 4 and 1`` () =
        let sequenceOfBits =
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
                [| 0; 0; 1 |] // 1
            }

        let result = Day3.Part2.filterByArrayIndex sequenceOfBits 1 0
        
        Assert.Equal<IEnumerable<int[]>>(
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 0; 1 |] // 1
            }, result)
        
    [<Fact>]
    let ``Part2.filterByArrayIndex: a sequence of bits with numeric values 4, 2, 1 when filtering index 3 with value 0 returns binary 4 and 2`` () =
        let sequenceOfBits =
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
                [| 0; 0; 1 |] // 1
            }

        let result = Day3.Part2.filterByArrayIndex sequenceOfBits 2 0
        
        Assert.Equal<IEnumerable<int[]>>(
            seq {
                [| 1; 0; 0 |] // 4
                [| 0; 1; 0 |] // 2
            }, result)

    [<Fact>]
    let ``Part2.mostCommonBits: a sequence containing a single bit sequence returns the original single bit sequence`` () =
        let singleBitSequence = seq {
            [| 0; 1; 0; 1; 0; 1 |]
        }
        
        let result = Day3.Part2.mostCommonBits singleBitSequence
        
        Assert.Equal<int[]>([| 0; 1; 0; 1; 0; 1 |], result)
        
    [<Fact>]
    let ``Part2.mostCommonBits: a sequence containing two bit sequences where contained bits have equal frequency returns all 1s`` () =
        let singleBitSequence = seq {
            [| 0; 1; 0; 1; 0; 1 |]
            [| 1; 0; 1; 0; 1; 0 |]
        }
        
        let result = Day3.Part2.mostCommonBits singleBitSequence
        
        Assert.Equal<int[]>([| 1; 1; 1; 1; 1; 1 |], result)
        