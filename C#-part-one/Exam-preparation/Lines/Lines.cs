using System;

class Lines
{
    static void Main()
    {
        int[] rows = new int[8];

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = int.Parse(Console.ReadLine());
        }

        int longestLenght = 0;
        int curretLenght = 0;
        int numberOfLines = 0;

        //Horizontally
        for (int row = 0; row < rows.Length; row++)
        {
            curretLenght = 0;
            for (int col = 7; col >= 0; col--)
            {
                if ((rows[row] >> col & 1) == 0)
                {
                    curretLenght = 0;
                }
                else if ((rows[row] >> col & 1) != 0)
                {
                    curretLenght++;
                    if (curretLenght > longestLenght)
                    {
                        longestLenght = curretLenght;
                        numberOfLines = 1;
                    }
                    else if (curretLenght == longestLenght)
                    {
                        numberOfLines++;
                    }
                }
            }
        }

        //Vertically
        for (int column = 7; column >= 0; column--)
        {
            curretLenght = 0;
            for (int row = 0; row < rows.Length; row++)
            {
                if ((rows[row] >> column & 1) == 0)
                {
                    curretLenght = 0;
                }
                else if ((rows[row] >> column & 1) != 0)
                {
                    curretLenght++;

                    if (curretLenght > longestLenght)
                    {
                        longestLenght = curretLenght;
                        numberOfLines = 1;
                    }
                    else if (curretLenght == longestLenght)
                    {
                        numberOfLines++;
                    }
                }
            }
        }

        if (longestLenght == 1)
        {
            numberOfLines /= 2;
        }
        Console.WriteLine(longestLenght);
        Console.WriteLine(numberOfLines);
    }
}

