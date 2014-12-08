namespace BullsAndCows.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        public GuessResult GetResult(string guess, string number)
        {
            int bulls = 0;
            int cows = 0;
            bool[] used = new bool[4];
            char[] checkNumber = number.ToCharArray();

            for (int i = 0; i < checkNumber.Length; i++)
            {
                if (guess[i] == number[i])
                {
                    bulls++;
                    checkNumber[i] = 's';
                }
            }

            for (int i = 0; i < guess.Length; i++)
            {
                for (int j = 0; j < checkNumber.Length; j++)
                {
                    if (guess[i] == checkNumber[j] && i != j)
                    {
                        cows++;
                    }
                }
            }

            var result = new GuessResult
            {
                BullsCount = bulls,
                CowsCount = cows
            };

            return result;
        }
    }
}
