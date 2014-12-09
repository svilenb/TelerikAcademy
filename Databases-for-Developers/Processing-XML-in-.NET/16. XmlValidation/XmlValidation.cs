namespace _16.XmlValidation
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    class XmlValidation
    {
        static void Main(string[] args)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", @"..\..\..\catalog.xsd");
            XDocument doc = XDocument.Load(@"..\..\..\catalog.xml");

            Console.WriteLine("Validating the catalog.xml file...");
            string msg = "";
            doc.Validate(schemas, (o, e) =>
            {
                msg = e.Message;
            });

            Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);

            doc = XDocument.Load(@"..\..\..\invalid-catalog.xml");
            Console.WriteLine("Validating the invalid-catalog.xml file...");
            doc.Validate(schemas, (o, e) =>
            {
                msg = e.Message;
            });

            Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);
        }
    }
}
