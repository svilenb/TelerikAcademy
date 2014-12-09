namespace _03.ExtractArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractArtistsXPath
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            var authors = new Dictionary<string, int>();
            string query = "catalog/album";
            XmlNodeList albums = doc.SelectNodes(query);
            foreach (XmlNode album in albums)
            {
                string artistName = album.SelectSingleNode("artist").InnerText;

                if (!authors.ContainsKey(artistName))
                {
                    authors.Add(artistName, 0);
                }

                authors[artistName]++;
            }

            foreach (var item in authors)
            {
                Console.WriteLine("Author: {0} - Number of albums: {1}", item.Key, item.Value);
            }
        }
    }
}
