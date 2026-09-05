public static class ArraySelector
{
    public static void Run()
    {
        var a1 = new[] { 1, 2, 3, 4, 5 };
        var a2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(a1, a2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var results = new int[select.Length];

        int list1Index = 0;
        int list2Index = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                results[i] = list1[list1Index++];
            }
            else if (select[i] == 2)
            {
                results[i] = list2[list2Index++];
            }
        }
        return results; 
    }
}