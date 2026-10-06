using System;
using System.Collections.Generic;

public class WildcardBinary
{
    public static void WildcardBinaryPatterns(List<string> results, string pattern)
    {
        // 1. Locate the first wildcard '*'
        int index = pattern.IndexOf('*');
        Console.WriteLine("Index of '*': " + index);

        // 2. Base Case: No wildcards remaining
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // 3. Slice the string into before and after the '*'
        string before = pattern[..index];       // Characters before '*'
        Console.WriteLine("Before: " + before);
        string after = pattern[(index + 1)..];  // Characters after '*'
        Console.WriteLine("After: " + after);

        // 4. Recursive Step: Try '0' then try '1'
        WildcardBinaryPatterns(results, before + "0" + after);
        WildcardBinaryPatterns(results, before + "1" + after);
    }

    public static void Main()
    {
        List<string> results = new List<string>();
        string pattern = "1*10*1";

        WildcardBinaryPatterns(results, pattern);

        Console.WriteLine($"Results for pattern \"{pattern}\":");
        Console.WriteLine(string.Join(", ", results));
        // Output: 1001, 1011, 1101, 1111
    }
}