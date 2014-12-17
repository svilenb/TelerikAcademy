using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ConsoleJustification
{
    static int numberOfLines;
    static int symbolsOnLine;

    static string InsertGaps(StringBuilder line)
    {
        string[] words = line.ToString().Split();

        int numberOfGapsToInsert = symbolsOnLine - (line.Length - (words.Length - 1));
        int[] gaps;

        StringBuilder finishedLine = new StringBuilder();

        if (words.Length > 1)
        {
            gaps = new int[words.Length - 1];
            for (int i = 0; i < numberOfGapsToInsert; i++)
            {
                gaps[i % gaps.Length]++;
            }

            for (int i = 0; i < gaps.Length; i++)
            {
                finishedLine.Append(words[i]);
                finishedLine.Append(new string(' ', gaps[i]));
            }
            finishedLine.Append(words[words.Length - 1]);

            return finishedLine.ToString();
        }
        else
        {
            return words[0];
        }
    }

    static void Main()
    {
        numberOfLines = int.Parse(Console.ReadLine());
        symbolsOnLine = int.Parse(Console.ReadLine());

        StringBuilder text = new StringBuilder();

        for (int line = 0; line < numberOfLines; line++)
        {
            text.Append(" " + Console.ReadLine());
        }

        Regex pattern = new Regex(@"\b\w+\b");

        MatchCollection words = pattern.Matches(text.ToString());
        Queue<string> queue = new Queue<string>();

        foreach (Match match in words)
        {
            queue.Enqueue(match.Value);
        }

        while (queue.Count > 0)
        {
            StringBuilder currentLine = new StringBuilder();

            currentLine.Append(queue.Dequeue());
            while (queue.Count != 0 && currentLine.Length + queue.Peek().Length + 1 <= symbolsOnLine)
            {
                currentLine.Append(' ');
                currentLine.Append(queue.Dequeue());
            }
            string resultLine = InsertGaps(currentLine);
            Console.WriteLine(resultLine);
        }
    }
}
