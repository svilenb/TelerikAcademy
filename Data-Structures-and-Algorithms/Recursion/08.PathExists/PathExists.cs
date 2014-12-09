namespace _08.PathExists
{
    using System;
    using System.Linq;
    using _07.MatrixPassableCells;

    internal class PathExists
    {
        private static bool pathExist;

        internal static void Main()
        {
            char[,] matrix = new char[100, 100];
            var startCell = new Cell(0, 0);
            var endCell = new Cell(45, 45);
            pathExist = false;
            GetPath(matrix, startCell, endCell);
            Console.WriteLine(pathExist ? "Path found." : "No paths found.");
        }

        private static void GetPath(char[,] matrix, Cell start, Cell end)
        {
            if (pathExist)
            {
                return;
            }

            if (start.Row >= matrix.GetLength(0) || start.Row < 0 || start.Col >= matrix.GetLength(1) || start.Col < 0)
            {
                return;
            }

            if (matrix[start.Row, start.Col] == '*')
            {
                return;
            }

            if (start.Equals(end))
            {
                pathExist = true;
                return;
            }

            matrix[start.Row, start.Col] = '*';
            GetPath(matrix, new Cell(start.Row + 1, start.Col), end);
            GetPath(matrix, new Cell(start.Row, start.Col + 1), end);
            GetPath(matrix, new Cell(start.Row - 1, start.Col), end);
            GetPath(matrix, new Cell(start.Row, start.Col - 1), end);
            matrix[start.Row, start.Col] = ' ';
        }
    }
}
