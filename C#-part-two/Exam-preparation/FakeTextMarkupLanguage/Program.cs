using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    const string UpperOpenTag = "<upper>";
    const string LowerOpenTag = "<lower>";
    const string ToggleOpenTag = "<toggle>";
    const string DelOpenTag = "<del>";
    const string ReverseOpenTag = "<rev>";
    const string UpperCloseTag = "</upper>";
    const string LowerCloseTag = "</lower>";
    const string ToggleCloseTag = "</toggle>";
    const string DelCloseTag = "</del>";
    const string ReverseCloseTag = "</rev>";

    static Regex pattern = new Regex(@"(?<tag><rev>)(?<content>[^<]*)</rev>|(?<tag><upper>)(?<content>[^<]*)</upper>|(?<tag><lower>)(?<content>[^<]*)</lower>|(?<tag><del>)(?<content>[^<]*)</del>|(?<tag><toggle>)(?<content>[^/]*)</toggle>");
    static StringBuilder text = new StringBuilder();
    static Stack<string> openedTags = new Stack<string>();
    //I use regular expressions and recursion for this solution
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            text.Append(Console.ReadLine());
            text.AppendLine();
        }
        while (true)
        {
            MatchCollection matches = pattern.Matches(text.ToString());

            if (matches.Count == 0) break;

            foreach (Match match in matches)
            {
                openedTags.Push(match.Groups["tag"].Value);
                ProccessMatches(match.Groups["content"].Value);
            }
        }

        Console.WriteLine(text);
    }

    private static void ProccessMatches(string input)
    {
        MatchCollection matches = pattern.Matches(input);

        if (matches.Count == 0)
        {
            ProcessText(input);
        }
        else
        {
            foreach (Match match in matches)
            {
                openedTags.Push(match.Groups["tag"].Value);
                ProccessMatches(match.Groups["content"].Value);
            }
        }
    }

    private static void ProcessText(string input)
    {
        string openingTag = openedTags.Pop();
        string closingTag = string.Empty;
        StringBuilder result = new StringBuilder();

        if (openingTag == UpperOpenTag)
        {
            result.Append(input.ToUpper());
            closingTag = UpperCloseTag;
        }
        else if (openingTag == LowerOpenTag)
        {
            result.Append(input.ToLower());
            closingTag = LowerCloseTag;
        }
        else if (openingTag == DelOpenTag)
        {
            closingTag = DelCloseTag;
        }
        else if (openingTag == ReverseOpenTag)
        {
            closingTag = ReverseCloseTag;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }
        }
        else if (openingTag == ToggleOpenTag)
        {
            closingTag = ToggleCloseTag;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLower(input[i])) result.Append(char.ToUpper(input[i]));
                else if (char.IsUpper(input[i])) result.Append(char.ToLower(input[i]));
                else result.Append(input[i]);
            }
        }

        text.Replace(string.Format("{0}{1}{2}", openingTag, input, closingTag), result.ToString());
    }
}
