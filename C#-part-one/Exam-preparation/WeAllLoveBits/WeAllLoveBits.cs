using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbersToTransform = new int[n];
        int[] transformedNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbersToTransform[i] = int.Parse(Console.ReadLine());

            transformedNumbers[i] = int.MaxValue & reversedInBinary(numbersToTransform[i]);//"int.MaxValue &" can be omitted
            Console.WriteLine(transformedNumbers[i]);
        }
    }

    private static int reversedInBinary(int p)
    {
        int reversedP = new int();

        while (p > 0)
        {
            reversedP <<= 1;

            if ((p & 1) == 1)
            {
                reversedP |= 1;
            }
            p >>= 1;
        }

        return reversedP;
    }
}

