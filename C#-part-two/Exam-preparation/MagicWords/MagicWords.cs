using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    private static int numberOfWords = int.Parse(Console.ReadLine());
    private static List<string> words = new List<string>();

    private static void Reorder()
    {
        for (int i = 0; i < words.Count; i++)
        {
            int j = words[i].Length % (words.Count + 1);

            string currentWord = words[i];
            words[i] = null;
            words.Insert(j, currentWord);
            words.Remove(null);
        }
    }

    private static void ReadInput()
    {
        for (int i = 0; i < numberOfWords; i++)
        {
            words.Add(Console.ReadLine());
        }
    }

    private static void Print()
    {
        int maxLength = new int();

        foreach (string item in words)
        {
            if (maxLength < item.Length)
            {
                maxLength = item.Length;
            }
        }

        StringBuilder result = new StringBuilder(); //Using StringBuilder because printing every single character every time is slower
        for (int i = 0; i < maxLength; i++)
        {
            foreach (string item in words)
            {
                if (item.Length > i)
                {
                    result.Append(item[i]);
                }
            }
        }
        Console.WriteLine(result);
    }

    static void Main()
    {
        ReadInput();
        Reorder();
        Print();
    }
}
