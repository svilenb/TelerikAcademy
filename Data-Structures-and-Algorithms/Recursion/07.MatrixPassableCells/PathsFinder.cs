namespace _07.MatrixPassableCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PathsFinder
    {
        internal static void Main()
        {
            char[,] matrix =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', ' ' }, 
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };
            var startCell = new Cell(0, 0);
            var endCell = new Cell(4, 6);
            GetPath(matrix, startCell, endCell, new Stack<Cell>());
        }

        private static void GetPath(char[,] matrix, Cell start, Cell end, Stack<Cell> path)
        {
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
                path.Push(end);
                Console.WriteLine("Path: {0}", string.Join(" ", path.Reverse()));
                path.Pop();
                return;
            }

            matrix[start.Row, start.Col] = '*';
            path.Push(start);
            GetPath(matrix, new Cell(start.Row + 1, start.Col), end, path);
            GetPath(matrix, new Cell(start.Row, start.Col + 1), end, path);
            GetPath(matrix, new Cell(start.Row - 1, start.Col), end, path);
            GetPath(matrix, new Cell(start.Row, start.Col - 1), end, path);
            matrix[start.Row, start.Col] = ' ';
            path.Pop();
        }
    }
}
