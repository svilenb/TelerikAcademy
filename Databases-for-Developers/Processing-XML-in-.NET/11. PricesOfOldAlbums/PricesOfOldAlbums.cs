namespace _11.PricesOfOldAlbums
{
    using System;
    using System.Xml;

    class PricesOfOldAlbums
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\catalog.xml");

            string xPathQuery = "/catalog/album[year<2009]";
            XmlNodeList priceList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode priceNode in priceList)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                string price = priceNode.SelectSingleNode("price").InnerText;
                Console.WriteLine("Album: {0} -- Price: {1}", albumName, price);
            }
        }
    }
}
