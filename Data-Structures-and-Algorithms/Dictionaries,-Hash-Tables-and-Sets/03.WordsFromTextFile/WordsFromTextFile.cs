namespace _03.WordsFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Linq;

    class WordsFromTextFile
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\words.txt";

            StringBuilder fileContents = new StringBuilder();
            using (var reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    fileContents.Append(line);
                    line = reader.ReadLine();
                }
            }

            string[] words = fileContents.ToString().Split(new char[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                string wordLower = word.ToLower();
                int count = 1;
                if (wordsCount.ContainsKey(wordLower))
                {
                    count = wordsCount[wordLower] + 1;
                }

                wordsCount[wordLower] = count;
            }

            var wordsCountOrdered = wordsCount.OrderBy(w => w.Value);
            foreach (var item in wordsCountOrdered)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
