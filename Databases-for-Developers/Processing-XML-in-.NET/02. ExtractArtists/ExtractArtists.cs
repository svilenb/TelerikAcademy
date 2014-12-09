namespace _02.ExtractArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractArtists
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");
            XmlNode root = doc.DocumentElement;

            Dictionary<string, int> authors = new Dictionary<string, int>();
            foreach (XmlNode node in root.ChildNodes)
            {
                var authorName = node["artist"].InnerText;
                if (!authors.ContainsKey(authorName))
                {
                    authors.Add(authorName, 0);
                }

                authors[authorName]++;
            }

            foreach (var item in authors)
            {
                Console.WriteLine("Author: {0} - Number of Albums: {1}", item.Key, item.Value);
            }
        }
    }
}
