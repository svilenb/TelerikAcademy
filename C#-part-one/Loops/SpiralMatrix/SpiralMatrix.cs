using System;

class SpiralMatrix
{
    static void PrintMatrix(int[,] Matrix, int matrixSize)
    {
        for (int row = 0; row < matrixSize; row++)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                Console.Write("{0,-2} ", Matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int n;
        bool valid = int.TryParse(Console.ReadLine(), out n);

        if (!valid)
        {
            Console.WriteLine("Invalid input!");
        }
        else if (n == 0)
        {
            Console.WriteLine("Such matrix doesn't exist!");
        }
        else
        {
            int[,] spiralMatrix = new int[n, n];
            string direction = "right";
            int currentRow = 0;
            int currentCol = 0;

            for (int i = 1; i <= n * n; i++)
            {
                if (direction == "right" && (currentCol >= n || spiralMatrix[currentRow, currentCol] != 0))
                {
                    currentCol--;
                    currentRow++;
                    direction = "down";
                }
                else if (direction == "down" && (currentRow >= n || spiralMatrix[currentRow, currentCol] != 0))
                {
                    currentRow--;
                    currentCol--;
                    direction = "left";
                }
                else if (direction == "left" && (currentCol < 0 || spiralMatrix[currentRow, currentCol] != 0))
                {
                    currentCol++;
                    currentRow--;
                    direction = "up";
                }
                else if (direction == "up" && (currentRow < 0 || spiralMatrix[currentRow, currentCol] != 0))
                {
                    currentRow++;
                    currentCol++;
                    direction = "right";
                }

                spiralMatrix[currentRow, currentCol] = i;

                if (direction == "right")
                {
                    currentCol++;
                }
                else if (direction == "down")
                {
                    currentRow++;
                }
                else if (direction == "left")
                {
                    currentCol--;
                }
                else if (direction == "up")
                {
                    currentRow--;
                }
            }

            PrintMatrix(spiralMatrix, n);
        }         
    }
}

