namespace _3.Dividers
{
    using System;
    using System.Collections.Generic;

    class Dividers
    {
        private static IList<int[]> permutations;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] digits = new int[n];
            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(digits);
            permutations = new List<int[]>();
            GeneratePermutations(digits, 0);
            int minimumDividers = int.MaxValue;
            int solution = 0;
            foreach (var perm in permutations)
            {
                int number = GetNumber(perm);
                int dividers = GetDividersNumber(number);
                if (dividers < minimumDividers)
                {
                    minimumDividers = dividers;
                    solution = number;
                }
            }

            Console.WriteLine(solution);
        }

        private static void GeneratePermutations(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                permutations.Add((int[])arr.Clone());
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static int GetNumber(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result = result * 10 + arr[i];
            }

            return result;
        }

        private static int GetDividersNumber(int num)
        {
            int count = 0;
            for (int i = 1; i <= num; ++i)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
