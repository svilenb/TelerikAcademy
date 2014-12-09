namespace _14.XSLTransformCatalog
{
    using System;
    using System.Xml.Xsl;

    class XSLTransformCatalog
    {
        static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(@"..\..\..\catalog.xslt");
            xslt.Transform(@"..\..\..\catalog.xml", @"..\..\catalog.html");
            Console.WriteLine("Catalog transformed.");
        }
    }
}
