namespace _5.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortingMain
    {
        private static int arraySize;
        private static byte[] arr;
        private static int k;

        public static void Main(string[] args)
        {
            arraySize = byte.Parse(Console.ReadLine());
            arr = Console.ReadLine().Split().Select(byte.Parse).ToArray();
            k = byte.Parse(Console.ReadLine());

            FewestNumberOfOperationsFinder finder = new FewestNumberOfOperationsFinder(arr, k);
            Console.WriteLine(finder.Find());
        }
    }
}
