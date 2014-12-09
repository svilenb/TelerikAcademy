using System;

class DrunkenNumbers
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());

        int totalMitkoBeers = 0;
        int totalVladkoBeers = 0;

        for (int i = 0; i < numberOfRounds; i++)
        {
            int drunkenNumber = int.Parse(Console.ReadLine());

            if (drunkenNumber < 0)
            {
                drunkenNumber = drunkenNumber * (-1);
            }

            string drunkenNumStr = drunkenNumber.ToString();

            if (drunkenNumStr.Length % 2 == 0)
            {
                for (int m = 0; m < drunkenNumStr.Length / 2; m++)
                {
                    totalMitkoBeers += drunkenNumStr[m] - '0';
                    totalVladkoBeers += drunkenNumStr[(drunkenNumStr.Length - 1) - m] - '0';
                }
            }
            else if (drunkenNumStr.Length % 2 != 0)
            {
                for (int m = 0; m <= drunkenNumStr.Length / 2; m++)
                {
                    totalMitkoBeers += drunkenNumStr[m] - '0';
                    totalVladkoBeers += drunkenNumStr[(drunkenNumStr.Length - 1) - m] - '0';
                }
            }
        }

        if (totalMitkoBeers > totalVladkoBeers)
        {
            Console.WriteLine("M {0}", totalMitkoBeers - totalVladkoBeers);
        }
        else if (totalVladkoBeers > totalMitkoBeers)
        {
            Console.WriteLine("V {0}", totalVladkoBeers - totalMitkoBeers);
        }
        else
        {
            Console.WriteLine("No {0}", totalMitkoBeers + totalVladkoBeers);
        }
    }
}
