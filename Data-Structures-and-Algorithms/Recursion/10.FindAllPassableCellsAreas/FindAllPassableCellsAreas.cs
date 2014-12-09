namespace _10.FindAllPassableCellsAreas
{
    using System;
    using System.Collections.Generic;
    using _07.MatrixPassableCells;

    internal class FindAllPassableCellsAreas
    {
        internal static void Main()
        {
            char charToCheck = ' ';
            char[,] matrix =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }, 
                { ' ', '*', '*', '*', '*', '*', '*' }, 
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' }
            };

            bool[,] isVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var areas = new HashSet<string>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var area = new HashSet<Cell>();
                    CheckNeighbourElements(matrix, isVisited, charToCheck, new Cell(row, col), area);
                    if (area.Count > 0)
                    {
                        areas.Add(string.Format("Area: {0}", string.Join(" ", area)));
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, areas));
        }

        private static void CheckNeighbourElements(char[,] matrix, bool[,] isVisited, char charToCheck, Cell start, HashSet<Cell> area)
        {
            if (start.Row == matrix.GetLength(0) || start.Row < 0 || start.Col == matrix.GetLength(1) || start.Col < 0)
            {
                return;
            }

            if (isVisited[start.Row, start.Col])
            {
                return;
            }

            if (matrix[start.Row, start.Col] != charToCheck)
            {
                return;
            }

            isVisited[start.Row, start.Col] = true;
            area.Add(start);
            CheckNeighbourElements(matrix, isVisited, charToCheck, new Cell(start.Row + 1, start.Col), area);
            CheckNeighbourElements(matrix, isVisited, charToCheck, new Cell(start.Row - 1, start.Col), area);
            CheckNeighbourElements(matrix, isVisited, charToCheck, new Cell(start.Row, start.Col + 1), area);
            CheckNeighbourElements(matrix, isVisited, charToCheck, new Cell(start.Row, start.Col - 1), area);
        }
    }
}
