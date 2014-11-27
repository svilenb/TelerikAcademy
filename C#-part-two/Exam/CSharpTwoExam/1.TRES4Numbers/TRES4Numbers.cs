using System;
using System.Numerics;
using System.Text;

class TRES4Numbers
{
    static string[] tresDigits = { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };

    static void Main()
    {
        BigInteger decNumber = BigInteger.Parse(Console.ReadLine());

        string result = ConvertToTres(decNumber);
        Console.WriteLine(result);
    }

    private static string ConvertToTres(BigInteger decNumber)
    {
        StringBuilder result = new StringBuilder();

        if (decNumber == 0)
        {
            return "LON+";
        }

        while (decNumber > 0)
        {
            result.Insert(0, tresDigits[(int)(decNumber % 9)]);
            decNumber /= 9;
        }

        return result.ToString();
    }
}
