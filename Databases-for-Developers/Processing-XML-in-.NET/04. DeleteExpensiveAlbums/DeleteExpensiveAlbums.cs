namespace _04.DeleteExpensiveAlbums
{
    using System;
    using System.Xml;

    class DeleteExpensiveAlbums
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            string query = "/catalog/album/price";
            XmlNodeList prices = doc.SelectNodes(query);
            XmlNode catalog = doc.SelectSingleNode("catalog");
            foreach (XmlNode price in prices)
            {
                if (double.Parse(price.InnerText) > 20)
                {
                    XmlNode album = price.ParentNode;
                    catalog.RemoveChild(album);
                }
            }

            Console.WriteLine("Modified XML document:");
            Console.WriteLine(doc.OuterXml);

            doc.Save("../../catalogue-modified.xml");
        }
    }
}
