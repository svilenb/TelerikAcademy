using System;

class AstrologicalDigits
{
    static int SumDigits(int sum)
    {
        int digitsSum = new int();

        while (sum > 0)
        {
            digitsSum += sum % 10;
            sum /= 10;
        }
        return digitsSum;
    }

    static void Main()
    {
        string strN = Console.ReadLine();
        char[] chArrayN = strN.ToCharArray();
        int sum = new int();
        int finalSum = new int();

        for (int i = 0; i < chArrayN.Length; i++)
        {
            if (chArrayN[i] == '1' || chArrayN[i] == '2' || chArrayN[i] == '3' || chArrayN[i] == '4' ||
                chArrayN[i] == '5' || chArrayN[i] == '6' || chArrayN[i] == '7' ||
                chArrayN[i] == '8' || chArrayN[i] == '9')
            {
                sum += chArrayN[i] - '0';
            }
        }

        if (sum > 9)
        {
            finalSum = SumDigits(sum);
        }
        else
        {
            finalSum = sum;
        }

        while (finalSum > 9)
        {
            finalSum = SumDigits(finalSum);
        }

        Console.WriteLine(finalSum);
    }
}

