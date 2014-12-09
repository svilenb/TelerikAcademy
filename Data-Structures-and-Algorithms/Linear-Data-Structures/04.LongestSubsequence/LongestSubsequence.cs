namespace _04.LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            while (true)
            {
                Console.Write("Enter a integer number or empty line to end: ");
                int element;
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Longest subsequence of equal elements elements: " + string.Join(", ", FindLongestSubsequenceEqualNumbers(numbers)));
                    break;
                }
                else if (int.TryParse(input, out element))
                {
                    numbers.Add(element);
                }
                else
                {
                    Console.WriteLine("Invalid number! Try again.");
                }
            }
        }

        private static IList<int> FindLongestSubsequenceEqualNumbers(IList<int> numbers)
        {
            int curentLenght = 1;
            int bestLenght = 1;
            int bestSequenceBegining = 0;

            for (int currentElementIndex = 0; currentElementIndex < numbers.Count; currentElementIndex++)
            {
                for (int nextElement = currentElementIndex + 1; nextElement < numbers.Count; nextElement++)
                {
                    if ((numbers[currentElementIndex] != numbers[nextElement]))
                    {
                        if (curentLenght > bestLenght)
                        {
                            bestLenght = curentLenght;
                            bestSequenceBegining = currentElementIndex;
                            curentLenght = nextElement - 1;
                        }

                        currentElementIndex = nextElement - 1;
                        curentLenght = 1;
                        break;
                    }
                    else if (numbers[currentElementIndex] == numbers[nextElement])
                    {
                        curentLenght++;
                    }
                }

                if (curentLenght > bestLenght)
                {
                    bestLenght = curentLenght;
                    bestSequenceBegining = currentElementIndex;
                }
                curentLenght = 1;
            }

            var result = new List<int>();
            for (int i = bestSequenceBegining; i < bestSequenceBegining + bestLenght; i++)
            {
                result.Add(numbers[i]);
            }

            return result;
        }
    }
}
