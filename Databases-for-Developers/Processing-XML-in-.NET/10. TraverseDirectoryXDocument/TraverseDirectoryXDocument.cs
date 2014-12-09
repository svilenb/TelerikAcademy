namespace _10.TraverseDirectoryXDocument
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    class TraverseDirectoryXDocument
    {
        static void Main(string[] args)
        {
            string directory = @"..\..\";
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            var doc = new XDocument(CreateDirectoryXml(dirInfo, true));
            doc.Save(@"..\..\directory.xml");
            Console.WriteLine("Created directory.xml file.");
        }

        private static XElement CreateDirectoryXml(DirectoryInfo dirInfo, bool inRoot)
        {
            XElement root;
            if (inRoot)
            {
                root = new XElement("root");
            }
            else
            {
                root = new XElement("dir", new XAttribute("name", dirInfo.Name));
            }

            foreach (var file in dirInfo.GetFiles())
            {
                root.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            foreach (var subDir in dirInfo.GetDirectories())
            {
                root.Add(CreateDirectoryXml(subDir, false));
            }

            return root;
        }
    }
}
