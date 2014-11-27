using System;

class Eggcelent
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int surroundingDots = n + 1;
        int topBottomSize = n - 1;
        int middleDots = n + 1;
        int currentHeght = 1;
        int width = 3 * n + 1;
        int middles = 0;
        //top
        for (int i = 0; i < surroundingDots; i++)
        {
            Console.Write(".");
        }
        for (int i = 0; i < topBottomSize; i++)
        {
            Console.Write("*");
        }
        for (int i = 0; i < surroundingDots; i++)
        {
            Console.Write(".");
        }
        Console.WriteLine();
        currentHeght++;

        //before  @
        surroundingDots -= 2;
        while (currentHeght <= n / 2)
        {

            for (int i = 0; i < surroundingDots; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = 0; i < middleDots; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = 0; i < surroundingDots; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            currentHeght++;
            if (surroundingDots != 1)
            {
                surroundingDots -= 2;
                middleDots += 4;
            }
        }
        while (currentHeght <= n - 1)
        {
            Console.Write(".");
            Console.Write("*");
            for (int i = 0; i < middleDots; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            Console.Write(".");
            Console.WriteLine();
            currentHeght++;
            middles++;
        }

        // @
        Console.Write(".");
        Console.Write("*");
        for (int i = 0; i < width - 4; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("@");
            }
            else if (i % 2 == 1)
            {
                Console.Write(".");
            }
        }
        Console.Write("*");
        Console.Write(".");
        Console.WriteLine();

        Console.Write(".");
        Console.Write("*");
        for (int i = 0; i < width - 4; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(".");
            }
            else if (i % 2 == 1)
            {
                Console.Write("@");
            }
        }
        Console.Write("*");
        Console.Write(".");
        Console.WriteLine();


        //after @
        //currentHeght = 1;
        while (middles - 1 > 0)
        {
            Console.Write(".");
            Console.Write("*");
            for (int i = 0; i < middleDots; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            Console.Write(".");
            Console.WriteLine();
            currentHeght++;
            middles--;
        }
        surroundingDots = 1;
        while (currentHeght + 1 < 2 * n - 1) //surroundingDots < n + 1 && middleDots >= n+1
        {
            for (int i = 0; i < surroundingDots; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = 0; i < middleDots; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = 0; i < surroundingDots; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            currentHeght++;
            middleDots -= 4;
            surroundingDots += 2;
        }

        //bottom
        surroundingDots = n + 1;
        for (int i = 0; i < surroundingDots; i++)
        {
            Console.Write(".");
        }
        for (int i = 0; i < topBottomSize; i++)
        {
            Console.Write("*");
        }
        for (int i = 0; i < surroundingDots; i++)
        {
            Console.Write(".");
        }
        Console.WriteLine();
    }
}
