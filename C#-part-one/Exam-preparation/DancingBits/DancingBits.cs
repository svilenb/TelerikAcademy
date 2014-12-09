using System;

class DancingBits
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        int[] array = new int[N];
        int lastBit = -1;
        int lenght = 0;
        int dancingBits = 0;

        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(Console.ReadLine());

            int firstNonZeroBit = -1;

            for (int bit = 31; bit >= 0; bit--)
            {
                int currentBit = (array[i] >> bit) & 1;

                if (currentBit == 1)
                {
                    firstNonZeroBit = bit;
                    break;
                }
            }

            for (int bit = firstNonZeroBit; bit >= 0; bit--)
            {
                int currentBit = (array[i] >> bit) & 1;

                if (currentBit == lastBit)
                {
                    lenght++;
                }

                else
                {
                    if (lenght == K)
                    {
                        dancingBits++;
                    }
                    lenght = 1;
                }
                lastBit = currentBit;
            }
        }

        if (lenght == K)
        {
            dancingBits++;
        }

        Console.WriteLine(dancingBits);
    }
}

