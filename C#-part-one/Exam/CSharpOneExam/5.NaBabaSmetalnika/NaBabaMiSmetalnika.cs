using System;
using System.Numerics;

class NaBabaMiSmetalnika
{
    static void Main()
    {
        uint widthOfSmetalo = uint.Parse(Console.ReadLine());
        uint[] smetalo = new uint[8];
        uint[,] matrix = new uint[8, widthOfSmetalo];
        uint[] result = new uint[8];

        for (int i = 0; i < 8; i++)
        {
            smetalo[i] = uint.Parse(Console.ReadLine());
        }
        for (int row = 0; row < 8; row++)
        {
            for (int j = 0; j < widthOfSmetalo; j++)
            {
                matrix[row, (widthOfSmetalo - 1) - j] = (uint)((smetalo[row] >> j) & 1);
            }
        }

        //PrintMatrix(matrix);

        string commands;
        int currentRow = new int();
        int currentCol = new int();
        do
        {
            commands = Console.ReadLine();
            if (commands == "left" || commands == "right")
            {
                currentRow = int.Parse(Console.ReadLine());
                currentCol = int.Parse(Console.ReadLine());
            }

            MoveTopchenca(currentRow, currentCol, matrix, commands);
            //PrintMatrix(matrix);
        } while (commands != "stop");

        decimal sum = 0;

        //fill result array
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 1)
                {
                    result[row] |= (uint)(1 << ((matrix.GetLength(1) - 1) - col));
                }
            }
        }

        //calculate emty columns
        bool isOnes = false;
        int columnsWithoutTopchenca = 0;

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == 1)
                {
                    isOnes = true;
                }
            }
            if (!isOnes)
            {
                columnsWithoutTopchenca++;
            }

            isOnes = false;
        }

        for (int i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        sum *= columnsWithoutTopchenca;

        //Print sum
        Console.WriteLine(sum);
    }

    private static void MoveTopchenca(int currentRow, int currentCol, uint[,] matrix, string commands)
    {
        int counter = new int();

        if (currentRow >= matrix.GetLength(0))
        {
            currentRow = matrix.GetLength(0) - 1;
        }
        else if (currentRow < 0)
        {
            currentRow = 0;
        }

        if (currentCol >= matrix.GetLength(1))
        {
            currentCol = matrix.GetLength(1) - 1;
        }
        else if (currentCol < 0)
        {
            currentCol = 0;
        }
        if (commands == "left")
        {
            for (int j = 0; j <= currentCol; j++)
            {
                if (matrix[currentRow, j] == 1)
                {
                    counter++;
                    matrix[currentRow, j] = 0;
                }
            }

            for (int j = 0; j < counter; j++)
            {
                matrix[currentRow, j] = 1;
            }
        }
        else if (commands == "right")
        {

            for (int j = currentCol; j < matrix.GetLength(1); j++)
            {
                if (matrix[currentRow, j] == 1)
                {
                    counter++;
                    matrix[currentRow, j] = 0;
                }
            }
            for (int j = matrix.GetLength(1) - 1; j >= matrix.GetLength(1) - counter; j--)
            {
                matrix[currentRow, j] = 1;
            }
        }
        else if (commands == "reset")
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        counter++;
                        matrix[row, col] = 0;
                    }
                }

                for (int j = 0; j < counter; j++)
                {
                    matrix[row, j] = 1;
                }
                counter = 0;
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
