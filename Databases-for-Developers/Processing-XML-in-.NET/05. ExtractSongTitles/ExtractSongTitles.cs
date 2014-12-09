namespace _05.ExtractSongTitles
{
    using System;
    using System.Xml;

    class ExtractSongTitles
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All songs: ");
            using (XmlReader reader = XmlReader.Create(@"..\..\..\catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
