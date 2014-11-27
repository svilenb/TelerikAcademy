using System;
using System.Numerics;

class PeaceOfCake
{
    static void Main()
    {
        decimal A = decimal.Parse(Console.ReadLine());
        decimal B = decimal.Parse(Console.ReadLine());
        decimal C = decimal.Parse(Console.ReadLine());
        decimal D = decimal.Parse(Console.ReadLine());

        decimal nominatorFractionOne = A * D;
        decimal nominatorFractionTwo = B * C;
        decimal denominatorOFBothFractions = B * D;
        decimal nominator = (nominatorFractionOne + nominatorFractionTwo);

        decimal wholeNumber = 0;
        decimal fraction = new decimal();
        bool isWholeNumber = false;

        if (nominator >= denominatorOFBothFractions)
        {
            wholeNumber = (nominator / denominatorOFBothFractions);
            wholeNumber = Math.Floor(wholeNumber);
            isWholeNumber = true;
        }
        else
        {
            fraction = (nominator / denominatorOFBothFractions);
        }

        if (!isWholeNumber)
        {
            Console.WriteLine("{0:F22}", fraction);
            Console.WriteLine("{0}/{1}", nominator, denominatorOFBothFractions);
        }
        else
        {
            Console.WriteLine(wholeNumber);
            Console.WriteLine("{0}/{1}", nominator, denominatorOFBothFractions);
        }
    }
}
