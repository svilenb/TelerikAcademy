namespace _06.SubsetOfKStrings
{
    using System;

    internal class SubsetOfKStrings
    {
        internal static void Main()
        {
            string[] set = { "test", "rock", "fun" };
            int k = 2;
            GenerateCombinations(0, 0, set, new string[k]);
        }

        private static void GenerateCombinations(int startIndex, int startIndexSet, string[] set, string[] combination)
        {
            if (startIndex == combination.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", combination));
                return;
            }

            for (int i = startIndexSet; i < set.Length; i++)
            {
                combination[startIndex] = set[i];
                GenerateCombinations(startIndex + 1, i + 1, set, combination);
            }
        }
    }
}
