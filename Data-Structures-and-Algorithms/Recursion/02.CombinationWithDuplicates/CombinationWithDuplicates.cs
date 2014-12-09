namespace _02.CombinationWithDuplicates
{
    using System;

    internal class CombinationWithDuplicates
    {
        internal static void Main()
        {
            int n = 3;
            int k = 2;
            GenerateCombinations(0, 1, n, new int[k]);
        }

        private static void GenerateCombinations(int startIndex, int startValue, int endValue, int[] combination)
        {
            if (startIndex == combination.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", combination));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                combination[startIndex] = i;
                GenerateCombinations(startIndex + 1, i, endValue, combination);
            }
        }
    }
}
