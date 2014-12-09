using System;

class Fire
{
    private static int N = int.Parse(Console.ReadLine());
    private static int currentRow = 1;

    private static void PrintFire()
    {
        while ((currentRow - 1) < N / 2)
        {
            for (int i = 0; i < N / 2 - currentRow; i++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int i = 0; i < 2 * (currentRow - 1); i++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int i = 0; i < N / 2 - currentRow; i++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
            currentRow++;
        }

        currentRow--;

        while (2 * (currentRow - 1) >= N / 2)
        {
            for (int i = 0; i < N / 2 - currentRow; i++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int i = 0; i < 2 * (currentRow - 1); i++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int i = 0; i < N / 2 - currentRow; i++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
            currentRow--;
        }
    }

    private static void PrintTorch()
    {
        for (int i = 0; i < N; i++)
        {
            Console.Write('-');
        }

        Console.WriteLine();
        currentRow = 0;

        while (currentRow < N / 2)
        {
            for (int i = 0; i < currentRow; i++)
            {
                Console.Write('.');
            }
            for (int i = 0; i < N / 2 - currentRow; i++)
            {
                Console.Write('\\');
            }
            for (int i = 0; i < N / 2 - currentRow; i++)
            {
                Console.Write('/');
            }
            for (int i = 0; i < currentRow; i++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
            currentRow++;
        }
    }

    static void Main()
    {
        PrintFire();
        PrintTorch();
    }
}

