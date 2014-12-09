namespace _06.ExtractSongTitlesLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class ExtractSongTitlesLinq
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"..\..\..\catalog.xml");
            var songs = doc.Descendants("title").Select(x => x.Value);
            Console.WriteLine("All songs:");
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
