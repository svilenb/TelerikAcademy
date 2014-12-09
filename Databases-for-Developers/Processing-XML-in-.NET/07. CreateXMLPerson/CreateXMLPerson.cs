namespace _07.CreateXMLPerson
{
    using System;
    using System.IO;
    using System.Xml.Linq;


    class CreateXMLPerson
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\people.txt";
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                int counter = 0;
                string name = string.Empty;
                string address = string.Empty;
                string phone = string.Empty;
                XElement resultXml = new XElement("people");
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 3 == 0)
                    {
                        name = line;
                    }
                    else if (counter % 2 == 1)
                    {
                        address = line;
                    }
                    else
                    {
                        phone = line;

                        resultXml.Add(
                            new XElement("person",
                                new XElement("name", name),
                                new XElement("address", address),
                                new XElement("phone", phone)));
                    }

                    counter++;
                }

                Console.WriteLine("People xml generated.");
                resultXml.Save(@"..\..\people.xml");
            }

        }
    }
}
