using System;
using System.Collections.Generic;
using System.Text;

class DecodeAndDecrypt
{
    static string Decrypt(string message, string cypher)
    {
        StringBuilder result = new StringBuilder(message);

        int longerLength = (message.Length >= cypher.Length ? message.Length : cypher.Length);
        int messageIndex = 0;
        int cypherIndex = 0;

        for (int i = 0; i < longerLength; i++)
        {
            result[messageIndex] = Convert.ToChar(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
            messageIndex = (messageIndex + 1) % message.Length;
            cypherIndex = (cypherIndex + 1) % cypher.Length;
        }

        return result.ToString();
    }

    static string Decode(string input)
    {
        StringBuilder result = new StringBuilder();

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < input.Length; index++)
        {
            int digit;
            if (int.TryParse(input[index].ToString(), out digit))
            {
                sb.Insert(0, digit);
            }
            else
            {
                if (sb.Length != 0)
                {
                    result.Append(input[index], (int.Parse(sb.ToString()) + 1));
                }
                else
                {
                    result.Append(input[index]);
                }
                sb.Clear();
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();
        int lastNonDigitIndex = new int();
        for (int index = input.Length - 1; index >= 0; index--)
        {
            int digit;
            if (int.TryParse(input[index].ToString(), out digit))
            {
                sb.Insert(0, digit);
            }
            else
            {
                lastNonDigitIndex = index;
                break;
            }
        }

        int cypherLegth = int.Parse(sb.ToString());
        Stack<char> stack = new Stack<char>();
        StringBuilder number = new StringBuilder();
        char previousChar = input[lastNonDigitIndex];
        int currentLoopIndex = 0;
        int bottomBorder = lastNonDigitIndex - (cypherLegth - 1);
        int loopIndex = lastNonDigitIndex;

        while (stack.Count < cypherLegth)
        {            
            int digit;

            while (int.TryParse(input[loopIndex].ToString(), out digit))
            {
                number.Insert(0, digit);
                loopIndex--;
            }

            if (number.Length != 0)
            {
                char lastChar = stack.Pop();
                int num = int.Parse(number.ToString());

                for (int i = 0; i < num; i++)
                {
                    stack.Push(lastChar);    
                }
                number.Clear();
                loopIndex++;
            }
            else
            {
                stack.Push(input[loopIndex]);
            }
            currentLoopIndex = loopIndex;
            loopIndex--;
        }

        sb = new StringBuilder();
        int stackLength = stack.Count;

        for (int i = 0; i < stackLength; i++)
        {
            sb.Append(stack.Pop());
        }

        string cypher = sb.ToString();
        string message = input.Substring(0, currentLoopIndex);
        string decoded = Decode(message);
        string finalResult = Decrypt(decoded, cypher);
        Console.WriteLine(finalResult);
    }
}
