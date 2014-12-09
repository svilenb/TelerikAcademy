using System;

class QuadronacciRectangle
{
    static void Main()
    {
        long[] previousFourNumbers = new long[4];

        for (int i = 0; i < 4; i++)
        {
            previousFourNumbers[i] = int.Parse(Console.ReadLine());
        }

        int R = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());

        long[,] QuadronacciRec = new long[R, C];

        QuadronacciRec[0, 0] = previousFourNumbers[0];
        QuadronacciRec[0, 1] = previousFourNumbers[1];
        QuadronacciRec[0, 2] = previousFourNumbers[2];
        QuadronacciRec[0, 3] = previousFourNumbers[3];

        int startCol = 4;

        for (int row = 0; row < QuadronacciRec.GetLength(0); row++)
        {
            if (row != 0)
            {
                startCol = 0;
            }
           
            for (int col = startCol; col < QuadronacciRec.GetLength(1); col++)
            {
                for (int index = 0; index < 4; index++)
                {
                    QuadronacciRec[row, col] += previousFourNumbers[index];
                }

                for (int i = 0; i < 3; i++)
                {
                    previousFourNumbers[i] = previousFourNumbers[i + 1];
                }
                previousFourNumbers[3] = QuadronacciRec[row, col];
            }
        }

        for (int row = 0; row < QuadronacciRec.GetLength(0); row++)
        {
            for (int col = 0; col < QuadronacciRec.GetLength(1); col++)
            {
                if (col == QuadronacciRec.GetLength(1) - 1)
                {
                    Console.Write("{0}", QuadronacciRec[row, col]);
                }
                else
                {
                    Console.Write("{0} ", QuadronacciRec[row, col]);
                }
            }
            Console.WriteLine();
        }
    }
}

