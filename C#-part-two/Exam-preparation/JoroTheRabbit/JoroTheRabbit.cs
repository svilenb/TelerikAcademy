using System;

class JoroTheRabbit
{
    static int[] terrain;

    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        terrain = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            terrain[i] = int.Parse(input[i]);
        }

        int maxLength = int.MinValue;
        for (int step = 1; step <= terrain.Length; step++)
        {
            for (int index = 0; index < terrain.Length; index++)
            {
                int currentLength = CalculateVisitedPosition(index, step);

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
            }
        }
        Console.WriteLine(maxLength);
    }

    private static int CalculateVisitedPosition(int startPos, int step)
    {
        int length = 1;
        int currentPos = startPos;
        while (true)
        {
            if (terrain[(currentPos + step) % terrain.Length] > terrain[currentPos])
            {
                length++;
                currentPos = (currentPos + step) % terrain.Length;
            }
            else
            {
                return length;
            }
        }
    }
}
