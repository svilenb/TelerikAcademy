using System;

class Pillars
{
    static int[] rows = new int[8];

    static void Main()
    {
        for (int index = 0; index < rows.Length; index++)
        {
            rows[index] = int.Parse(Console.ReadLine());
        }

        int leftSum = 0;
        int rightSum = 0;
        bool foundPillar = false;

        for (int pillar = 7; pillar >= 0; pillar--)
        {
            leftSum = SumOneSideOfPillar(7, pillar + 1);
            rightSum = SumOneSideOfPillar(pillar - 1, 0);

            if (leftSum == rightSum)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(leftSum);
                foundPillar = true;
                return;
            }
        }

        if (!foundPillar)
        {
            Console.WriteLine("No");
        }
    }

    private static int SumOneSideOfPillar(int startIndex, int endIndex)
    {
        if (startIndex < endIndex)
        {
            return 0;
        }

        int sum = 0;

        for (int row = 0; row < rows.Length; row++)
        {
            for (int position = startIndex; position >= endIndex; position--)
            {
                sum += rows[row] >> position & 1;
            }
        }

        return sum;
    }
}

