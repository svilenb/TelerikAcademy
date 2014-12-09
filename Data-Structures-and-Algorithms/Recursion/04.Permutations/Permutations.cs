namespace _04.Permutations
{
    using System;

    internal class Permutations
    {
        internal static void Main()
        {
            int n = 3;
            GeneratePermutations(0, 1, n, new int[n], new bool[n]);
        }

        private static void GeneratePermutations(int startIndex, int startValue, int endValue, int[] permutation, bool[] isUsed)
        {
            if (startIndex == permutation.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", permutation));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                if (!isUsed[i - 1])
                {
                    permutation[startIndex] = i;
                    isUsed[i - 1] = true;
                    GeneratePermutations(startIndex + 1, startValue, endValue, permutation, isUsed);
                    isUsed[i - 1] = false;
                }
            }
        }
    }
}
