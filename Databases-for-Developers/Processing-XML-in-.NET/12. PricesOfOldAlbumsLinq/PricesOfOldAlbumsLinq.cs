namespace _12.PricesOfOldAlbumsLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class PricesOfOldAlbumsLinq
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load(@"..\..\..\catalog.xml");

            var albums = xmlDoc.Descendants("album")
                .Where(a => double.Parse(a.Element("year").Value) < 2009)
                .Select(a => new
            {
                Title = a.Element("name").Value,
                Price = a.Element("price").Value
            });

            foreach (var album in albums)
            {
                Console.WriteLine("Album: {0} -- Price: {1}", album.Title, album.Price);
            }
        }
    }
}
