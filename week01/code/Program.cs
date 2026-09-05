using System;
using System.Collections.Generic;

namespace ArrayAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Console.WriteLine("=== Problem 1: MultiplesOf ===");
            
            double number1 = 7;
            int length1 = 5;
            double[] result1 = Arrays.MultiplesOf(number1, length1);
            Console.WriteLine($"MultiplesOf({number1}, {length1}): [{string.Join(", ", result1)}]");

            double number2 = 1.5;
            int length2 = 4;
            double[] result2 = Arrays.MultiplesOf(number2, length2);
            Console.WriteLine($"MultiplesOf({number2}, {length2}): [{string.Join(", ", result2)}]");

            Console.WriteLine("\n=== Problem 2: RotateListRight ===");

            List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int amount1 = 5;
            Console.WriteLine($"Original List: [{string.Join(", ", numbers1)}]");
            Arrays.RotateListRight(numbers1, amount1);
            Console.WriteLine($"After RotateListRight(amount: {amount1}): [{string.Join(", ", numbers1)}]");

            Console.WriteLine();

            List<int> numbers2 = new List<int> { 10, 20, 30, 40 };
            int amount2 = 4;
            Console.WriteLine($"Original List: [{string.Join(", ", numbers2)}]");
            Arrays.RotateListRight(numbers2, amount2);
            Console.WriteLine($"After RotateListRight(amount: {amount2}): [{string.Join(", ", numbers2)}]");
        }
    }

    public static class Arrays
    {
        /// <summary>
        /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
        /// </summary>
        public static double[] MultiplesOf(double number, int length)
        {
            // initialize an array with the size of length
            var multiples = new double[length];

            // fill the array with multiples of the supplied number
            for (var i = 0; i < length; i++)
            {
                // calculate the multiple by multiplying the number with (i + 1) and assign it to the array
                multiples[i] = number * (i + 1);
            }

            return multiples;
        }

        /// <summary>
        /// Rotate the 'data' to the right by the 'amount'.
        /// Modifies the existing data list rather than returning a new list.
        /// </summary>
        public static void RotateListRight(List<int> data, int amount)
        {
            // create a new list to hold the rotated values
            var rotateList = new List<int>();

            // add the last 'amount' elements to the new list
            for (var i = data.Count - amount; i < data.Count; i++)
            {
                rotateList.Add(data[i]);
            }

            // add the remaining elements to the new list
            for (var i = 0; i < data.Count - amount; i++)
            {
                rotateList.Add(data[i]);
            }

            // clear the original list and add the rotated values
            data.Clear();
            data.AddRange(rotateList);
        }
    }
}