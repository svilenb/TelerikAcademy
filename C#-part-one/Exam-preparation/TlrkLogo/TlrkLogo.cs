using System;

class TlrkLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int z = (x + 1) / 2;
        int N = (2 * x) + (2 * z) - 3;
        char[,] matrix = new char[N, N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = '.';
            }
        }

        int currentRow, currentCol;
        currentRow = z - 1;
        currentCol = 0;
        int pathLength = (6 * x) + (2 * z);

        for (int i = 0; i < z; i++)
        {
            matrix[currentRow, currentCol] = '*';
            currentRow--;
            currentCol++;
        }

        currentRow += 2;

        for (int i = 0; i < (2 * x) - 2; i++)
        {
            matrix[currentRow, currentCol] = '*';
            currentRow++;
            currentCol++;
        }

        currentCol -= 2;

        for (int i = 0; i < x - 1; i++)
        {
            matrix[currentRow, currentCol] = '*';
            currentRow++;
            currentCol--;
        }

        currentRow -= 2;

        for (int i = 0; i < x - 1; i++)
        {
            matrix[currentRow, currentCol] = '*';
            currentRow--;
            currentCol--;
        }

        currentCol += 2;

        for (int i = 0; i < (2 * x) - 2; i++)
        {
            matrix[currentRow, currentCol] = '*';
            currentRow--;
            currentCol++;
        }

        currentRow += 2;

        for (int i = 0; i < z - 1; i++)
        {
            matrix[currentRow, currentCol] = '*';
            currentRow++;
            currentCol++;
        }
        
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}

