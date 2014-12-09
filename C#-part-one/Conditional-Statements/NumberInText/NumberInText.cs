using System;

class NumberInText
{
    static int EnterIntegers()
    {
        string strNum;
        int number = new int();
        bool success = false;

        while (!success || number < 0 || number >= 1000)
        {
            Console.WriteLine("Enter integer number in the range [0...999]: ");
            strNum = Console.ReadLine();
            success = int.TryParse(strNum, out number);
        }
        return number;
    }

    static void Cases(int number)
    {
        switch (number)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                PrintingNumberName(number, 0); break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
                PrintingNumberName(number, 1); break;
            case 10:
            case 20:
            case 30:
            case 40:
            case 50:
            case 60:
            case 70:
            case 80:
            case 90:
                PrintingNumberName(number, 2); break;
            case 100:
            case 200:
            case 300:
            case 400:
            case 500:
            case 600:
            case 700:
            case 800:
            case 900:
                PrintingNumberName(number, 3); break;
            default:
                break;
        }
    }

    static void PrintingNumberName(int number, int numberOfString)
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] exceptions = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string[] hundreds = { "hundred", "hundreds" };
        //With the numberOfString variable I am choosing with which array to work 
        if (numberOfString == 0)
        {
            Console.Write("{0} ", digits[number]);
        }
        else if (numberOfString == 1)
        {
            Console.Write("{0} ", exceptions[number - 11]);
        }
        else if (numberOfString == 2)
        {
            Console.Write("{0} ", tens[number / 10 - 1]);
        }
        else if (numberOfString == 3)
        {
            Console.Write("{0} ", digits[number / 100]);
            Console.Write("hundred ");
        }
    }

    static void Main()
    {
        int number = EnterIntegers();

        if (number <= 20)
        {
            Cases(number);
        }
        else if (number > 20 && number < 100)
        {
            Cases(number - number % 10);
            if (number % 10 > 0)
            {
                Cases(number % 10);
            }
        }
        else if (number >= 100)
        {
            Cases(number - number % 100);

            if (number % 100 > 0)
            {
                Console.Write("and ");

                if (number % 100 <= 20)
                {
                    Cases(number % 100);
                }
                else if (number % 100 > 20 && number % 100 < 100)
                {
                    Cases(number % 100 - number % 10);
                    if (number % 10 > 0)
                    {
                        Cases(number % 10);
                    }
                }
            }
        }
        Console.WriteLine();
    }
}
