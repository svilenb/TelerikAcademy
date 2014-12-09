using System;

class LargestAreaEqualElements
{
    static char[,] matrix = 
    {
        { '*', '*', '*', '*', '*', '*', '*', '*', '*' },
        { '*', ' ', ' ', ' ', '*', '*', ' ', ' ', '*' },
        { '*', '*', '*', ' ', '*', ' ', '*', ' ', '*' },
        { '*', ' ', ' ', ' ', '*', ' ', '*', ' ', '*' },
        { '*', '*', '*', '*', '*', '*', '*', ' ', '*' },
        { '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '*' },
        { '*', '*', '*', '*', '*', '*', '*', '*', '*' },
    };

    static char[,] traverseMatrix = (char[,])matrix.Clone();
    static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; //I am using characters from the alphabet to mark elements from different areas
    static int largestAreaSize = new int();
    static int currentAreaSize = new int();
    static int alphabetIndex = 0;
    static int bestAlphabetIndex = -1;

    static void Main()
    {
        for (int i = 0; i < traverseMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < traverseMatrix.GetLength(1); j++)
            {
                //Check if we have already included this element in some area
                if (traverseMatrix[i, j] == ' ') 
                {
                    currentAreaSize = 0;
                    IncreaseAlphabetIndex(); //For each area we use different character
                    CheckNeighbourElements(i, j, traverseMatrix[i, j]);
                }
            }
        }

        Console.WriteLine("Largest connected area has size: {0}", largestAreaSize);
        Console.WriteLine();
        PrintMatrix(matrix);
    }

    private static void CheckNeighbourElements(int row, int col, char lastElement)
    {
        if ((col < 0) || (row < 0) || (col >= traverseMatrix.GetLength(1)) || (row >= traverseMatrix.GetLength(0)))
        {
            return;
        }

        if (traverseMatrix[row, col] != lastElement)
        {
            if (currentAreaSize > largestAreaSize)
            {
                largestAreaSize = currentAreaSize;
                bestAlphabetIndex = alphabetIndex;
            }

            return;
        }
        else if (traverseMatrix[row, col] == lastElement)
        {
            currentAreaSize++;
            traverseMatrix[row, col] = alphabet[alphabetIndex];
            CheckNeighbourElements(row, col - 1, matrix[row, col]);
            CheckNeighbourElements(row - 1, col, matrix[row, col]);
            CheckNeighbourElements(row, col + 1, matrix[row, col]);
            CheckNeighbourElements(row + 1, col, matrix[row, col]);
        }
        return;
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == ' ' && traverseMatrix[row, col] == alphabet[bestAlphabetIndex])
                {
                    // We change the background colour in order to show the elements making the largest area
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                Console.Write(matrix[row, col] + (col == (matrix.GetLength(1) - 1) ? Environment.NewLine : " "));
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }

    private static void IncreaseAlphabetIndex()
    {
        if ((alphabetIndex + 1) > 51) //if alphabetIndex == 51 
        {
            alphabetIndex = 0;
        }
        else
        {
            alphabetIndex++;
        }
    }
}