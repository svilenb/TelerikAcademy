namespace Towns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TownsMain
    {
        private static int[] towns;
        private static int[] ascLen;
        private static int[] descLen;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            towns = new int[n];
            ascLen = new int[n];
            descLen = new int[n];

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                towns[i] = int.Parse(line[0]);
            }

            LongestIncreasingSubsequence(towns.Length);
            LongestDecreasingSubsequence(towns.Length - 1);
            int maxInc = ascLen.Max();
            int maxDec = descLen.Max();
            int maxLength = 1;

            for (int i = 0; i < ascLen.Length; i++)
            {
                if (i == ascLen.Length - 1)
                {
                    int currentLength = ascLen[i];
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
                else
                {
                    if (towns[i] != towns[i + 1])
                    {
                        int currentLength = ascLen[i] + descLen[i + 1];
                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                        }
                    }
                }
            }

            Console.WriteLine(maxLength);
        }

        private static int MaxFrom(int[] arr, int index)
        {
            int result = int.MinValue;
            for (int i = index; i < arr.Length; i++)
            {
                if (arr[i] > result)
                {
                    result = arr[i];
                }
            }

            return result;
        }

        private static int MaxTo(int[] arr, int index)
        {
            int result = int.MinValue;
            for (int i = 0; i <= index; i++)
            {
                if (arr[i] > result)
                {
                    result = arr[i];
                }
            }

            return result;
        }

        private static void LongestIncreasingSubsequence(int endIndex)
        {
            ascLen[0] = 1;
            for (int x = 1; x < endIndex; x++)
            {
                int maxLength = 0;
                for (int prev = 0; prev < x; prev++)
                {
                    if (towns[prev] < towns[x] && ascLen[prev] > maxLength)
                    {
                        maxLength = ascLen[prev];
                    }

                    ascLen[x] = 1 + maxLength;
                }
            }
        }

        private static void LongestDecreasingSubsequence(int startIndex)
        {
            descLen[startIndex] = 1;
            for (int x = startIndex - 1; x >= 0; x--)
            {
                int maxLength = 0;
                for (int prev = startIndex; prev > x; prev--)
                {
                    if (towns[prev] < towns[x] && descLen[prev] > maxLength)
                    {
                        maxLength = descLen[prev];
                    }

                    descLen[x] = 1 + maxLength;
                }
            }
        }
    }
}
