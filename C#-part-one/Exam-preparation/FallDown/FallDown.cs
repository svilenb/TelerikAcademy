using System;

class FallDown
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];

        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int j = 0; j < 8; j++)
            {
                int bit = (number >> j) & 1;
                matrix[i, j] = bit;
            }
        }

        int currentRow = -1;

        for (int i = 6; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (matrix[i, j] == 1)
                {
                    currentRow = i;

                    while (currentRow < 7 && matrix[currentRow + 1, j] != 1)
                    {
                        matrix[currentRow, j] = 0;
                        matrix[currentRow + 1, j] = 1;
                        currentRow++;
                    }
                }
            }
        }
        int currentNumber = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (matrix[i, j] == 1)
                {
                    currentNumber = currentNumber | (1 << j);
                }
            }
            Console.WriteLine(currentNumber);
            currentNumber = 0;
        }
    }
}

