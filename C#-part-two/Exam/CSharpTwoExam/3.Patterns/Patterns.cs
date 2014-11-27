using System;

class Patterns
{
    static int[,] matrix;
    static long currentSum;

    static void Main()
    {
        ReadInput();

        long maxSum = long.MinValue;
        bool isPattern = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentSum = 0;

                if (FoundPattern(row, col))
                {
                    isPattern = true;
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
        }

        if (isPattern)
        {
            Console.WriteLine("YES {0}", maxSum);
        }
        else
        {
            Console.WriteLine("NO {0}", SumMainDiagonal());
        }
    }

    static bool FoundPattern(int row, int col)
    {
        int currentNumber = matrix[row, col];
        currentSum += currentNumber;
        int nextNumber;

        for (int curCol = col + 1; curCol < col + 3; curCol++)
        {
            if (!IsInMatrix(row, curCol)) return false;
            nextNumber = matrix[row, curCol];
            if (nextNumber != currentNumber + 1) return false;
            currentSum += nextNumber;
            currentNumber = nextNumber;
        }

        if (!IsInMatrix(row + 1, col + 2)) return false;
        nextNumber = matrix[row + 1, col + 2];
        if (nextNumber != currentNumber + 1) return false;
        currentSum += nextNumber;
        currentNumber = nextNumber;

        for (int curCol = col + 2; curCol < col + 5; curCol++)
        {
            if (!IsInMatrix(row + 2, curCol)) return false;
            nextNumber = matrix[row + 2, curCol];
            if (nextNumber != currentNumber + 1) return false;
            currentSum += nextNumber;
            currentNumber = nextNumber;
        }

        return true;
    }

    static long SumMainDiagonal()
    {
        long sum = new long();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, i];
        }

        return sum;
    }

    static bool IsInMatrix(int row, int col)
    {
        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void ReadInput()
    {
        int n = int.Parse(Console.ReadLine());
        matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] currentLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < currentLine.Length; j++)
            {
                matrix[i, j] = int.Parse(currentLine[j]);
            }
        }
    }
}
