using System;

class AngryBits
{
    private static int number = new int();
    private static int bitValue = new int();
    private static int[,] matrix = new int[8, 16];
    private static string direction = "up";
    private static int lengthOfFlight = new int();
    private static int destroyedPigs = new int();
    private static int score = new int();
    private static string winning = "Yes";

    private static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,2} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void FirePigs()
    {
        int currentCol = new int();
        int currentRow = new int();

        for (int col = 8; col <= 15; col++)
        {
            for (int row = 0; row <= 7; row++)
            {
                if (matrix[row, col] == 1)
                {
                    currentCol = col;
                    currentRow = row;

                    while (currentCol >= 0)
                    {
                        if (currentRow == 0)
                        {
                            direction = "down";
                        }                        

                        if (direction == "up" && matrix[currentRow - 1, currentCol - 1] == 0)
                        {
                            //Do nothing
                        }
                        else if (direction == "up" && matrix[currentRow - 1, currentCol - 1] == 1)
                        {
                            matrix[row, col] = 0;
                            DestroyPigs(currentRow - 2, currentCol, (col - (currentCol - 1)));
                            break;
                        }
                        else if (direction == "down" && matrix[currentRow + 1, currentCol - 1] == 0)
                        {
                            //Do nothing
                        }
                        else if (direction == "down" && matrix[currentRow + 1, currentCol - 1] == 1)
                        {
                            matrix[row, col] = 0;
                            DestroyPigs(currentRow, currentCol, (col - (currentCol - 1)));
                            break;
                        }

                        if (direction == "up")
                        {
                            currentCol--;
                            currentRow--;
                        }
                        else if (direction == "down")
                        {
                            currentCol--;
                            currentRow++;
                        }

                        if (currentCol == 0)
                        {
                            direction = "up";
                            lengthOfFlight = 0;
                            matrix[row, col] = 0;
                            break;
                        }
                        if (currentRow == 7)
                        {
                            lengthOfFlight = 0;
                            direction = "up";
                            matrix[row, col] = 0;
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void DestroyPigs(int row, int col, int length)
    {
        lengthOfFlight = length;

        for (int i = row; i <= row + 2; i++)
        {
            for (int j = col; j >= col - 2; j--)
            {
                if (i >= 0 && i <= 7 && j >= 0 && j <= 7)
                {
                    if (matrix[i, j] == 1)
                    {
                        destroyedPigs++;
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        score += (lengthOfFlight * destroyedPigs);
        lengthOfFlight = 0;
        destroyedPigs = 0;
        direction = "up";
    }

    private static void CheckForPigs()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 16; col++)
            {
                if (matrix[row, col] == 1)
                {
                    winning = "No";
                }
            }
        }
    }

    static void Main()
    {
        for (int i = 0; i < 8; i++)
        {
            number = int.Parse(Console.ReadLine());

            for (int j = 0; j < 16; j++)
            {
                bitValue = ((number >> j) & 1);
                matrix[i, j] = bitValue;
            }
        }
        //PrintMatrix(); <-- to help find mistakes
        FirePigs();
        CheckForPigs();

        Console.WriteLine("{0} {1}", score, winning);
        //PrintMatrix(); <-- to help find mistakes
    }
}

