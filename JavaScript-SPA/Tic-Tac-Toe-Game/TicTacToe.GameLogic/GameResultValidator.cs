namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        public GameResult GetResult(string board)
        {
            if (CheckHorizontals(board, 'O') || CheckVericals(board, 'O')
                || CheckFirstDiagonal(board, 'O') || CheckSecondDiagonal(board, 'O'))
            {
                return GameResult.WonByO;
            }
            else if (CheckHorizontals(board, 'X') || CheckVericals(board, 'X')
                || CheckFirstDiagonal(board, 'X') || CheckSecondDiagonal(board, 'X'))
            {
                return GameResult.WonByX;
            }
            else if (CheckIsFinished(board))
            {
                return GameResult.Draw;
            }
            else
            {
                return GameResult.NotFinished;
            }
        }

        private bool CheckHorizontals(string board, char symbol)
        {
            for (int i = 0; i < board.Length; i += 3)
            {
                int counter = 0;
                for (int j = i; j < i + 3; j++)
                {
                    if (board[j] != symbol)
                    {
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }

                if (counter == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckVericals(string board, char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                int counter = 0;
                for (int j = i; j < board.Length; j += 3)
                {
                    if (board[j] != symbol)
                    {
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }

                if (counter == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckFirstDiagonal(string board, char symbol)
        {
            int counter = 0;
            for (int i = 0; i < board.Length; i += 4)
            {
                if (board[i] != symbol)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                return true;
            }

            return false;
        }

        private bool CheckSecondDiagonal(string board, char symbol)
        {
            int counter = 0;
            for (int i = 2; i < board.Length - 2; i += 2)
            {
                if (board[i] != symbol)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                return true;
            }

            return false;
        }

        private bool CheckIsFinished(string board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
