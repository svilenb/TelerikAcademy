namespace _12.EightQueensPuzzle
{
    using System;

    internal class EightQueensPuzzle
    {
        private static int solutionsCount;

        internal static void Main()
        {
            solutionsCount = 0;
            int n = 8;
            var board = new int[n, n];
            PlaceQueen(board, 0);
            Console.WriteLine("Number of solutions for board with size {0} is: {1}", n, solutionsCount);
        }

        private static void PlaceQueen(int[,] board, int col)
        {
            if (col == board.GetLength(0))
            {
                solutionsCount++;
                return;
            }

            for (int row = 0; row < board.GetLength(1); row++)
            {
                if (board[row, col] == 0)
                {
                    MarkBoard(board, row, col, true);
                    PlaceQueen(board, col + 1);
                    MarkBoard(board, row, col, false);
                }
            }
        }

        private static void MarkBoard(int[,] board, int row, int col, bool value)
        {
            for (int i = col; i < board.GetLength(0); i++)
            {
                board[row, i] += value ? 1 : -1;

                if (row + i - col < board.GetLength(1))
                {
                    board[row + i - col, i] += value ? 1 : -1;
                }

                if (row - i + col >= 0)
                {
                    board[row - i + col, i] += value ? 1 : -1;
                }
            }
        }
    }
}
