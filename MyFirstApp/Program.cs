using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> results = new List<string>();
        string inputLetters = "ABCD";
        int targetSize = 2;

        Console.WriteLine($"--- Starting Permutations for '{inputLetters}' choosing {targetSize} --- \n");
        
        // Kick off the recursive method
        PermutationsChoose(results, inputLetters, targetSize);

        Console.WriteLine("\n--- Final Results Collected ---");
        foreach (var word in results)
        {
            Console.WriteLine(word);
        }
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Debugging Hook: Indent text based on word length to visualize recursion depth
        string indent = new string(' ', word.Length * 4);
        Console.WriteLine($"{indent}--> Entered: word='{word}', available='{letters}'");

        // 1. Base Case: If the current word reached the target size, add it to results
        if (word.Length == size)
        {
            // Console.WriteLine($"{indent}   [BASE CASE HIT] Adding '{word}' to results and returning.");
            results.Add(word);
            return;
        }

        // 2. Loop through each character in the available letters
        for (int i = 0; i < letters.Length; i++)
        {
            char chosenChar = letters[i];
            // Remove the chosen character from the letters string for the next call
            string remainingLetters = letters.Remove(i, 1);

            Console.WriteLine($"{indent}   Loop i={i}: Chose '{chosenChar}', remaining='{remainingLetters}'");

            // 3. Recursive call: Add chosen character to 'word' and pass remaining letters
            PermutationsChoose(results, remainingLetters, size, word + chosenChar);
        }

        Console.WriteLine($"{indent}X Leaving: Finished loop for word='{word}'");
    }
}
