namespace TelerikForumRSS
{
    using System;
    using System.Net;
    using System.Linq;

    using Newtonsoft.Json;
    using System.Xml.Linq;
    using Newtonsoft.Json.Linq;
    using System.Text;

    class TelerikForumRSSMain
    {
        static void Main(string[] args)
        {
            // 2. Download the content of the feed programmatically
            string xmlFilePath = @"..\..\telerik-forum.xml";
            WebClient webclient = new WebClient();
            webclient.DownloadFile("http://forums.academy.telerik.com/feed/qa.rss", xmlFilePath);
            XDocument doc = XDocument.Load(xmlFilePath);

            // 3. Parse the XML from the feed to JSON
            string json = JsonConvert.SerializeXNode(doc);

            // 4. Using LINQ-to-JSON select all the question titles and print them to the console
            var jsonObject = JObject.Parse(json);
            var titles = jsonObject["rss"]["channel"]["item"].Select(item => item["title"]);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            var template = new
            {
                RSS = new RSS()
            };

            // 5. Parse the JSON string to POCO
            var poco = JsonConvert.DeserializeAnonymousType(json, template);

            // 6. Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page
            StringBuilder html = new StringBuilder("<html>\n <body>\n  <ul>\n");
            foreach (var item in poco.RSS.Channel.Item)
            {
                html.AppendFormat("   <li>\n    <p>Question : {0}</p>\n    <p>Category : {1}</p>\n    <p>Link : {2}</p>\n    </li>\n", item.Title, item.Category, item.Link);
            }

            html.AppendLine("  </ul>\n </body>\n</html>");
            Console.WriteLine(html);
        }
    }
}
