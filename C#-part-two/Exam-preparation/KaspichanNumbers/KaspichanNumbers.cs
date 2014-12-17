using System;
using System.Collections.Generic;
using System.Text;

class KaspichanNumbers
{
    static string[] KaspichanDigits = new string[256];

    static void Main()
    {
        FillDigits();

        ulong decimalNumber = ulong.Parse(Console.ReadLine());
        string KaspichanNumber = ConvertToKaspichan(decimalNumber);
        Console.WriteLine(KaspichanNumber);
    }

    private static string ConvertToKaspichan(ulong decimalNumber)
    {
        List<string> list = new List<string>();

        if (decimalNumber == 0)
        {
            return "A";
        }

        while (decimalNumber > 0)
        {
            list.Add(KaspichanDigits[decimalNumber % 256]);
            decimalNumber /= 256;
        }

        list.Reverse();

        StringBuilder result = new StringBuilder();

        foreach (string item in list)
        {
            result.Append(item);
        }

        return result.ToString();
    }

    private static void FillDigits()
    {
        int index = 0;
        for (char i = 'A'; i <= 'Z'; i++)
        {
            KaspichanDigits[index] = i.ToString();
            index++;
        }

        for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                KaspichanDigits[index] = string.Format("{0}{1}", i, j);

                index++;
                if (index >= 256) return;
            }
        }
    }
}
