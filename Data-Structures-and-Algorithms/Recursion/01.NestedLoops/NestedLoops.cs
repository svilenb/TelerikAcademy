namespace _01.NestedLoops
{
    using System;

    internal class NestedLoops
    {
        internal static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            GetLoops(0, 1, n, new int[n]);
        }

        private static void GetLoops(int startIndex, int startValue, int endValue, int[] loop)
        {
            if (startIndex == loop.Length)
            {
                Console.WriteLine(string.Join(" ", loop));
                return;
            }

            for (int i = startValue; i <= endValue; i++)
            {
                loop[startIndex] = i;
                GetLoops(startIndex + 1, startValue, endValue, loop);
            }
        }
    }
}
