namespace _2.Bunnies
{
    using System;
    using System.Collections.Generic;

    class Bunnies
    {
        static void Main(string[] args)
        {
            int repliesNumber = int.Parse(Console.ReadLine());
            int[] replies = new int[repliesNumber];
            for (int i = 0; i < repliesNumber; i++)
            {
                replies[i] = int.Parse(Console.ReadLine());
            }

            int answer = CalculateMinimumRabbits(replies);
            Console.WriteLine(answer);
        }

        private static int CalculateMinimumRabbits(int[] replies)
        {
            var repliesCount = new Dictionary<int, int>();
            for (int i = 0; i < replies.Length; i++)
            {
                if (!repliesCount.ContainsKey(replies[i] + 1))
                {
                    repliesCount.Add(replies[i] + 1, 0);
                }

                repliesCount[replies[i] + 1]++;
            }

            int minRabbits = 0;
            foreach (var item in repliesCount)
            {
                if (item.Value <= item.Key)
                {
                    minRabbits += item.Key;
                }
                else
                {
                    minRabbits += (int)Math.Ceiling((double)item.Value / item.Key) * item.Key;
                }
            }

            return minRabbits;
        }
    }
}
