using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        int numberOfGames = int.Parse(Console.ReadLine());

        string[] firstPlayerHand = new string[3];
        string[] secondPlayerHand = new string[3];
        int firstPlayerPoints = 0;
        int secondPlayerPoints = 0;
        BigInteger firstPLayerScore = 0;
        BigInteger secondPLayerScore = 0;
        int firstPlayerGamesWon = 0;
        int secondPlayerGamesWon = 0;
        bool firstPlayerHasXCard = false;
        bool secondPlayerHasXCard = false;

        for (int i = 0; i < numberOfGames; i++)
        {
            firstPlayerHand[0] = Console.ReadLine();
            firstPlayerHand[1] = Console.ReadLine();
            firstPlayerHand[2] = Console.ReadLine();
            secondPlayerHand[0] = Console.ReadLine();
            secondPlayerHand[1] = Console.ReadLine();
            secondPlayerHand[2] = Console.ReadLine();

            firstPlayerPoints = 0;
            secondPlayerPoints = 0;

            for (int index = 0; index < 3; index++)
            {
                switch (firstPlayerHand[index])
                {
                    case "2":
                        firstPlayerPoints += 10; break;
                    case "3":
                        firstPlayerPoints += 9; break;
                    case "4":
                        firstPlayerPoints += 8; break;
                    case "5":
                        firstPlayerPoints += 7; break;
                    case "6":
                        firstPlayerPoints += 6; break;
                    case "7":
                        firstPlayerPoints += 5; break;
                    case "8":
                        firstPlayerPoints += 4; break;
                    case "9":
                        firstPlayerPoints += 3; break;
                    case "10":
                        firstPlayerPoints += 2; break;
                    case "A":
                        firstPlayerPoints += 1; break;
                    case "J":
                        firstPlayerPoints += 11; break;
                    case "Q":
                        firstPlayerPoints += 12; break;
                    case "K":
                        firstPlayerPoints += 13; break;
                    case "Z":
                        firstPLayerScore *= 2; break;
                    case "Y":
                        firstPLayerScore -= 200; break;
                    case "X":
                        firstPlayerHasXCard = true; break;
                    default:
                        break;
                }

                switch (secondPlayerHand[index])
                {
                    case "2":
                        secondPlayerPoints += 10; break;
                    case "3":
                        secondPlayerPoints += 9; break;
                    case "4":
                        secondPlayerPoints += 8; break;
                    case "5":
                        secondPlayerPoints += 7; break;
                    case "6":
                        secondPlayerPoints += 6; break;
                    case "7":
                        secondPlayerPoints += 5; break;
                    case "8":
                        secondPlayerPoints += 4; break;
                    case "9":
                        secondPlayerPoints += 3; break;
                    case "10":
                        secondPlayerPoints += 2; break;
                    case "A":
                        secondPlayerPoints += 1; break;
                    case "J":
                        secondPlayerPoints += 11; break;
                    case "Q":
                        secondPlayerPoints += 12; break;
                    case "K":
                        secondPlayerPoints += 13; break;
                    case "Z":
                        secondPLayerScore *= 2; break;
                    case "Y":
                        secondPLayerScore -= 200; break;
                    case "X":
                        secondPlayerHasXCard = true; break;
                    default:
                        break;
                }
            }

            if (firstPlayerHasXCard && secondPlayerHasXCard)
            {
                firstPLayerScore += 50;
                secondPLayerScore += 50;
                firstPlayerHasXCard = false;
                secondPlayerHasXCard = false;
                continue;

            }
            else if (firstPlayerHasXCard && !secondPlayerHasXCard)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }
            else if (secondPlayerHasXCard && !firstPlayerHasXCard)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }
            else if (firstPlayerPoints > secondPlayerPoints)
            {
                firstPLayerScore += firstPlayerPoints;
                firstPlayerGamesWon++;
            }
            else if (secondPlayerPoints > firstPlayerPoints)
            {
                secondPLayerScore += secondPlayerPoints;
                secondPlayerGamesWon++;
            }
        }


        if (firstPLayerScore > secondPLayerScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", firstPLayerScore);
            Console.WriteLine("Games won: {0}", firstPlayerGamesWon);
        }
        else if (secondPLayerScore > firstPLayerScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", secondPLayerScore);
            Console.WriteLine("Games won: {0}", secondPlayerGamesWon);
        }
        else if (firstPLayerScore == secondPLayerScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", firstPLayerScore);
        }
    }
}

