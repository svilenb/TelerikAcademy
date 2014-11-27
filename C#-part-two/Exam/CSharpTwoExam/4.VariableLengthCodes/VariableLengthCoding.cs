using System;
using System.Collections.Generic;
using System.Text;

class VariableLengthCoding
{
    static string[] strNums;
    static int[] decimalNums;
    static string[] binaryNums;
    static Dictionary<char, int> encodeTable = new Dictionary<char, int>();
    static StringBuilder text = new StringBuilder();

    static void Main()
    {
        ReadInput();
        ExtractBinaryNums();
        RecieveText();
        Console.WriteLine(text);
    }

    private static void RecieveText()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string item in binaryNums)
        {
            sb.Append(item);
        }

        string temp = sb.ToString().TrimEnd('0');
        sb = new StringBuilder(temp);

        StringBuilder currentCode = new StringBuilder();

        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] != '0')
            {
                currentCode.Append(sb[i]);
            }
            else
            {
                ExtractCharacter(currentCode.ToString());
                currentCode.Clear();
            }
        }

        if (currentCode.Length != 0)
        {
            ExtractCharacter(currentCode.ToString());
        }
    }

    private static void ExtractCharacter(string p)
    {
        foreach (var item in encodeTable)
        {
            if (item.Value == p.Length)
            {
                text.Append(item.Key);
                return;
            }
        }
    }

    private static void ExtractBinaryNums()
    {
        binaryNums = new string[decimalNums.Length];

        for (int i = 0; i < decimalNums.Length; i++)
        {
            binaryNums[i] = ConvertDecimalToBinary(decimalNums[i]);
        }
    }

    private static void ReadInput()
    {
        strNums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        decimalNums = new int[strNums.Length];

        for (int i = 0; i < strNums.Length; i++)
        {
            decimalNums[i] = int.Parse(strNums[i]);
        }

        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            string currentLine = Console.ReadLine();

            if (!encodeTable.ContainsKey(currentLine[0]))
            {
                encodeTable.Add(currentLine[0], int.Parse(currentLine.Substring(1)));
            }
        }
    }

    private static string ConvertDecimalToBinary(int input)
    {
        StringBuilder remainders = new StringBuilder();

        while (input != 0)
        {
            remainders.Append(input % 2);
            input /= 2;
        }

        char[] result = remainders.ToString().ToCharArray();
        Array.Reverse(result);
        return new string(result).PadLeft(8, '0');
    }
}
