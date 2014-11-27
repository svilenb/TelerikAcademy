using System;

class AngryFemaleGPS
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());

        int oddNumbersSum = new int();
        int evenNumbersSum = new int();

        if (n < 0)
        {
            n = (-1) * n;
        }

        while (n > 0)
        {
            int nextDigit = (int)(n % 10);
            n /= 10;

            if (nextDigit % 2 == 0)
            {
                evenNumbersSum += nextDigit;
            }
            else if (nextDigit % 2 != 0)
            {
                oddNumbersSum += nextDigit;
            }
        }

        string direction;

        if (oddNumbersSum > evenNumbersSum)
        {
            direction = "left";
            Console.WriteLine("{0} {1}", direction, oddNumbersSum);
        }
        else if (evenNumbersSum > oddNumbersSum)
        {
            direction = "right";
            Console.WriteLine("{0} {1}", direction, evenNumbersSum);
        }
        else
        {
            direction = "straight";
            Console.WriteLine("{0} {1}", direction, evenNumbersSum);
        }
    }
}
