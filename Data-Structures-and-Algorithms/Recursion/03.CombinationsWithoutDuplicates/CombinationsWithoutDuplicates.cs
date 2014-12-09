namespace _03.CombinationsWithoutDuplicates
{
    using System;

    internal class CombinationsWithoutDuplicates
    {
        internal static void Main()
        {
            int n = 4;
            int k = 2;
            GenerateCombinations(0, 1, n, new int[k]);
        }

        private static void GenerateCombinations(int startIndex, int startValue, int endValue, int[] combination)
        {
            if (startIndex == combination.Length)
            {
                Console.WriteLine("({0})", string.Join(", ", combination));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                combination[startIndex] = i;
                GenerateCombinations(startIndex + 1, i + 1, endValue, combination);
            }
        }
    }
}
