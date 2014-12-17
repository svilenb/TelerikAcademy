using System;

class SpecialValue
{
    static int[][] rows;
    static bool[][] visited;

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        rows = new int[N][];
        visited = new bool[N][];

        for (int i = 0; i < N; i++)
        {
            string[] currentLine = Console.ReadLine().Split(new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            rows[i] = new int[currentLine.Length];
            visited[i] = new bool[currentLine.Length];

            for (int j = 0; j < currentLine.Length; j++)
            {
                rows[i][j] = int.Parse(currentLine[j]);
            }
        }

        int maxValue = int.MinValue;

        for (int i = 0; i < rows[0].Length; i++)
        {
            int specialValue = CalculateSpecialValue(i);

            if (specialValue > maxValue)
            {
                maxValue = specialValue;
            }

            Unvisit();
        }

        Console.WriteLine(maxValue);
    }

    private static void Unvisit()
    {
        for (int i = 0; i < visited.GetLength(0); i++)
        {
            for (int j = 0; j < visited[i].Length; j++)
            {
                visited[i][j] = false;
            }
        }
    }

    private static int CalculateSpecialValue(int col)
    {
        int pathLength = 1;
        int nextRow = 0;
        int nextCol = col;
        visited[nextRow][nextCol] = true;

        while (true)
        {
            if (rows[nextRow][nextCol] >= 0 && visited[(nextRow + 1) % rows.GetLength(0)][rows[nextRow][nextCol]] == false)
            {
                pathLength++;
                nextCol = rows[nextRow][nextCol];
                nextRow = (nextRow + 1) % rows.GetLength(0);
                visited[nextRow][nextCol] = true;
            }
            else
            {
                return (pathLength + Math.Abs(rows[nextRow][nextCol]));
            }            
        }
    }
}
