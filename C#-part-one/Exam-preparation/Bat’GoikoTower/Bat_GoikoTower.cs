using System;

class Bat_GoikoTower
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int currentRow = 0;
        int height = N;
        int crossBeams = 0;
        int decrease = 1;

        while (height > 0)
        {
            for (int i = 0; i < height - 1; i++)
            {
                Console.Write('.');
            }
            Console.Write('/');


            if (height == N - (crossBeams + decrease))
            {
                crossBeams += decrease;
                decrease++;

                for (int i = 0; i < currentRow * 2; i++)
                {
                    Console.Write('-');
                }
            }
            else
            {
                for (int i = 0; i < currentRow * 2; i++)
                {
                    Console.Write('.');
                }
            }

            Console.Write('\\');

            for (int i = 0; i < height - 1; i++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
            currentRow++;
            height--;
        }
    }
}
