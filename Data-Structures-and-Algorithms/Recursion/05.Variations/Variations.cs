namespace _05.Variations
{
    using System;

    internal class Variations
    {
        internal static void Main()
        {          
            int k = 2;
            string[] set = { "hi", "a", "b" };
            GenerateVariations(0, new string[k], set);
        }

        private static void GenerateVariations(int startIndex, string[] variation, string[] set)
        {
            if (startIndex == variation.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                variation[startIndex] = set[i];
                GenerateVariations(startIndex + 1, variation, set);
            }
        }
    }
}
