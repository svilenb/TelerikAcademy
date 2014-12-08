namespace StringAppearancesServicesConsumer
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string text = "pesho is very cool pesho";

            string searched = "pesho";

            StringAppearancesServiceClient client = new StringAppearancesServiceClient();

            int result = client.CountAppearances(searched, text);
            Console.WriteLine(result);

            client.Close();
        }
    }
}
