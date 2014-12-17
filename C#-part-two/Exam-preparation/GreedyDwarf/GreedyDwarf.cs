using System;

class GreedyDwarf
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] valley = new int[firstLine.Length];

        for (int i = 0; i < firstLine.Length; i++)
        {
            valley[i] = int.Parse(firstLine[i]);
        }

        int numberOfPatterns = int.Parse(Console.ReadLine());

        string[][] strPatterns = new string[numberOfPatterns][];

        for (int row = 0; row < numberOfPatterns; row++)
        {
            strPatterns[row] = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        int[][] patterns = new int[numberOfPatterns][];

        for (int row = 0; row < numberOfPatterns; row++)
        {
            patterns[row] = new int[strPatterns[row].Length];

            for (int col = 0; col < patterns[row].Length; col++)
            {
                patterns[row][col] = int.Parse(strPatterns[row][col]);
            }
        }

        int maxCollectedCoins = int.MinValue;
        for (int pattern = 0; pattern < numberOfPatterns; pattern++)
        {
            bool[] visited = new bool[valley.Length];
            int patternIndex = 0;
            int currentPosition = 0;
            bool endOfGathering = false;
            int collectedCoins = valley[currentPosition];
            visited[currentPosition] = true;

            while (endOfGathering == false)
            {
                if (currentPosition + patterns[pattern][patternIndex] < 0 
                    || currentPosition + patterns[pattern][patternIndex] > valley.Length - 1
                    || visited[currentPosition + patterns[pattern][patternIndex]] == true)
                {
                    endOfGathering = true;

                    if (collectedCoins > maxCollectedCoins)
                    {
                        maxCollectedCoins = collectedCoins;
                    }
                }
                else
                {
                    currentPosition += patterns[pattern][patternIndex];
                    collectedCoins += valley[currentPosition];
                    patternIndex = (patternIndex + 1) % patterns[pattern].Length;
                    visited[currentPosition] = true;
                }
            }
        }

        Console.WriteLine(maxCollectedCoins);
    }
}
