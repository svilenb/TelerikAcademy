using System;

class OnesAndZeros
{
    private static string[] ones = { ".#.", "##.", ".#.", ".#.", "###" };
    private static string[] zeros = { "###", "#.#", "#.#", "#.#", "###" };

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] bitValue = new int[16];
        string[,] matrix = new string[5, 16];

        for (int i = 15; i >= 0; i--)
        {
            bitValue[15 - i] = (n >> i) & 1;
        }

        for (int i = 0; i < 16; i++)
        {
            if (bitValue[i] == 1)
            {
                int stringIndex = new int();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, i] = ones[stringIndex];
                    stringIndex++;
                }
            }
            else if (bitValue[i] == 0)
            {
                int stringIndex = new int();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, i] = zeros[stringIndex];
                    stringIndex++;
                }
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == matrix.GetLength(1) - 1)
                {
                    Console.Write(matrix[i, j]);
                }
                else
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
    }
}
