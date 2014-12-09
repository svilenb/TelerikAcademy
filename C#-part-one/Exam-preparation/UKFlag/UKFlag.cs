using System;

class UKFlag
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int middleDots = (N - 3) / 2;
        int sideDots = 0;

        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string('.', sideDots));
            Console.Write('\\');
            Console.Write(new string('.', middleDots));
            Console.Write('|');
            Console.Write(new string('.', middleDots));
            middleDots--;
            Console.Write('/');
            Console.Write(new string('.', sideDots));
            sideDots++;
            Console.WriteLine();
        }

        Console.Write(new string('-', N / 2));
        Console.Write('*');
        Console.Write(new string('-', N / 2));
        Console.WriteLine();
        middleDots++;
        sideDots--;

        for (int i = N / 2; i > 0; i--)
        {
            Console.Write(new string('.', sideDots));
            Console.Write('/');
            Console.Write(new string('.', middleDots));
            Console.Write('|');
            Console.Write(new string('.', middleDots));
            middleDots++;
            Console.Write('\\');
            Console.Write(new string('.', sideDots));
            sideDots--;
            Console.WriteLine();
        }
    }
}
