namespace Portals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PortalsMain
    {
        private static int[,] matrix;
        private static long maxSum = 0;

        public static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            int startingRow = int.Parse(firstLine[0]);
            int startingCol = int.Parse(firstLine[1]);

            string[] secondLine = Console.ReadLine().Split();
            int matrixRows = int.Parse(secondLine[0]);
            int matrixCols = int.Parse(secondLine[1]);
            matrix = new int[matrixRows, matrixCols];
            for (int i = 0; i < matrixRows; i++)
            {
                string[] currentLine = Console.ReadLine().Split();
                for (int j = 0; j < matrixCols; j++)
                {
                    if (currentLine[j] != "#")
                    {
                        matrix[i, j] = int.Parse(currentLine[j]);
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            Teleport(startingRow, startingCol, 0);
            Console.WriteLine(maxSum);
        }

        private static void Teleport(int row, int col, int currentSum)
        {
            int power = matrix[row, col];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }

            if (power == 0)
            {
                return;
            }

            if (IsInMatrix(row + power, col) && matrix[row + power, col] != -1)
            {
                matrix[row, col] = 0;
                currentSum += power;
                Teleport(row + power, col, currentSum);
                currentSum -= power;
                matrix[row, col] = power;
            }

            if (IsInMatrix(row, col + power) && matrix[row, col + power] != -1)
            {
                matrix[row, col] = 0;
                currentSum += power;
                Teleport(row, col + power, currentSum);
                currentSum -= power;
                matrix[row, col] = power;
            }

            if (IsInMatrix(row - power, col) && matrix[row - power, col] != -1)
            {
                matrix[row, col] = 0;
                currentSum += power;
                Teleport(row - power, col, currentSum);
                currentSum -= power;
                matrix[row, col] = power;
            }

            if (IsInMatrix(row, col - power) && matrix[row, col - power] != -1)
            {
                matrix[row, col] = 0;
                currentSum += power;
                Teleport(row, col - power, currentSum);
                currentSum -= power;
                matrix[row, col] = power;
            }
        }

        private static bool IsInMatrix(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
