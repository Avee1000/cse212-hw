using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        void MultipleLoops(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i);
            }

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(j * j);
            }
        }

        MultipleLoops(10);
    }
}