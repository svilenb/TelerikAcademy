using System;
using System.Text;

class MultiverseCommunication
{
    private static int[] ExtractNumbers(string input)
    {
        StringBuilder digit = new StringBuilder();
        int[] output = new int[input.Length / 3];

        int counter = new int();
        int index = new int();

        for (int i = 0; i < input.Length; i++)
        {
            digit.Append(input[i]);
            counter++;

            if (counter % 3 == 0)
            {
                switch (digit.ToString())
                {
                    case "CHU": output[index] = 0; break;
                    case "TEL": output[index] = 1; break;
                    case "OFT": output[index] = 2; break;
                    case "IVA": output[index] = 3; break;
                    case "EMY": output[index] = 4; break;
                    case "VNB": output[index] = 5; break;
                    case "POQ": output[index] = 6; break;
                    case "ERI": output[index] = 7; break;
                    case "CAD": output[index] = 8; break;
                    case "K-A": output[index] = 9; break;
                    case "IIA": output[index] = 10; break;
                    case "YLO": output[index] = 11; break;
                    case "PLA": output[index] = 12; break;
                    default:
                        break;
                }
                index++;
                digit.Clear();
            }
        }

        return output;
    }

    private static long ConvertFrom13BaseToDecimal(int[] input)
    {
        int power = new int();
        long result = new int();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            result += (int)input[i] * GetPowerOFThirdteen(power);
            power++;
        }

        return result;
    }

    private static long GetPowerOFThirdteen(int power)
    {
        long result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= 13;
        }

        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        int[] numbers = ExtractNumbers(input);
        long result = ConvertFrom13BaseToDecimal(numbers);
        Console.WriteLine(result);
    }
}
