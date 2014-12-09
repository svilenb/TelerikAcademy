namespace _09.TraverseDirectory
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class TraverseDirectory
    {
        static void Main(string[] args)
        {
            string directory = @"..\..\";
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(@"..\..\directory.xml", encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                CreateDirectoryXml(writer, dirInfo, true);
                writer.WriteEndDocument();
            }

            Console.WriteLine("Created directory.xml file.");
        }

        private static void CreateDirectoryXml(XmlTextWriter writer, DirectoryInfo dirInfo, bool inRoot)
        {
            if (!inRoot)
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", dirInfo.Name);
            }

            foreach (var file in dirInfo.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (var dir in dirInfo.GetDirectories())
            {
                CreateDirectoryXml(writer, dir, false);
            }
        }
    }
}
