using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        string number = Console.ReadLine();

        char[] numberArray = number.ToCharArray();
        int startPrintingIndex = 0;

        for (int i = 1; i <= 3; i++)
        {
            char holder = numberArray[numberArray.Length - 1];

            for (int index = numberArray.Length - 1; index > startPrintingIndex; index--)
            {
                numberArray[index] = numberArray[index - 1];
            }

            if (holder != '0')
            {
                numberArray[startPrintingIndex] = holder;
            }
            else
            {
                startPrintingIndex++;
            }
        }

        for (int i = startPrintingIndex; i < numberArray.Length; i++)
        {
            Console.Write(numberArray[i]);
        }
        Console.WriteLine();
    }
}
