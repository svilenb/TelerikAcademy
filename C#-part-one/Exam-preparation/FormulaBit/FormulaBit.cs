using System;

class FormulaBit
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        string[] directions = { "south", "west", "north", "west" };
        string direction = directions[0];

        for (int i = 0; i < 8; i++)
        {
            int input = int.Parse(Console.ReadLine());

            for (int j = 0; j < 8; j++)
            {
                matrix[i, j] = input >> j & 1;
            }
        }

        int currentRow = 0;
        int currentCol = 0;
        int index = 0;
        int length = 1;
        int countOfTurns = 0;

        if (matrix[0, 0] == 1)
        {
            Console.WriteLine("No 0");
            return;
        }
        while (currentRow != 7 || currentCol != 7)
        {
            matrix[currentRow, currentCol] = 3;

            if (direction == "south" && (currentRow == 7 || matrix[currentRow + 1, currentCol] != 0))
            {
                index++;
                index %= 4;
                direction = directions[index];
                countOfTurns++;
            }
            else if (direction == "west" && (currentCol == 7 || matrix[currentRow, currentCol + 1] != 0))
            {
                index++;
                index %= 4;
                direction = directions[index];
                countOfTurns++;
            }
            else if (direction == "north" && (currentRow == 0 || matrix[currentRow - 1, currentCol] != 0))
            {
                index++;
                index %= 4;
                direction = directions[index];
                countOfTurns++;
            }

            if (direction == "south")
            {
                if (currentRow == 7 || matrix[currentRow + 1, currentCol] != 0)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("No {0}", length);
                    return;
                }
                else
                {
                    currentRow++;
                    length++;
                }
            }
            else if (direction == "west")
            {
                if (currentCol == 7 || matrix[currentRow, currentCol + 1] != 0)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine("No {0}", length);
                    return;
                }
                else
                {
                    currentCol++;
                    length++;
                }
            }
            else if (direction == "north")
            {

                if (currentRow == 0 || matrix[currentRow - 1, currentCol] != 0)
                {
                    //PrintMatrix(matrix);
                    Console.WriteLine("No {0}", length);
                    return;
                }
                else
                {
                    currentRow--;
                    length++;
                }
            }
        }

        //PrintMatrix(matrix);
        Console.WriteLine("{0} {1}", length, countOfTurns);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 7; col >= 0; col--)
            {
                Console.Write("{0,-2}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

