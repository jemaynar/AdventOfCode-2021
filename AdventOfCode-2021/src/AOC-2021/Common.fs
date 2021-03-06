module Common
    open System.IO

    // Return array of strings the binary input.
    let getData (filename) =
        File.ReadLines(filename)

    let printReadableNumber (number) (tw:TextWriter) =
        tw.Write($"{number:n0}")
