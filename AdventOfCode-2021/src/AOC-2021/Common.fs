module Common
    
    // Return array of strings the binary input.
    let getData (filename) =
        System.IO.File.ReadLines(filename)