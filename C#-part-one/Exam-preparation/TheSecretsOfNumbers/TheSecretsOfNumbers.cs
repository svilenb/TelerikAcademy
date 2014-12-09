using System;
using System.Numerics;

class TheSecretsOfNumbers
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger oldN = N;
        int digitCounter = 1;
        int currentDigit = new int();
        int specialSum = new int();
        int lengthAlphaSequence = new int();
        char[] alphbet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        while (N != 0)
        {
            currentDigit = (int)N % 10;
            N /= 10;
            if (digitCounter % 2 != 0)
            {
                specialSum += currentDigit * digitCounter * digitCounter;
            }
            else if (digitCounter % 2 == 0)
            {
                specialSum += currentDigit * currentDigit * digitCounter;
            }
            digitCounter++;
        }

        Console.WriteLine(specialSum);

        int R = specialSum % 26;
        lengthAlphaSequence = specialSum % 10;

        if (lengthAlphaSequence != 0)
        {
            for (int i = R + 1; i < R + 1 + lengthAlphaSequence; i++)
            {
                if (i > 26)
                {
                    Console.Write(alphbet[i - 26 - 1]);
                }
                else
                {
                    Console.Write(alphbet[i - 1]);
                }
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("{0} has no secret alpha-sequence", oldN);
        }
    }
}

