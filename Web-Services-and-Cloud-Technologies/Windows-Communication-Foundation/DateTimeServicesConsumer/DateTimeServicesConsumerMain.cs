namespace DateTimeServicesConsumer
{
    using System;

    using DateTimeServicesConsumer.ServiceReferenceDate;

    class DateTimeServicesConsumerMain
    {
        static void Main(string[] args)
        {
            DateServiceClient client = new DateServiceClient();
            Console.WriteLine("Enter date:");
            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Ivalid date");
            }
            else
            {
                string dayOfWeek = client.GetDayOfWeek(date);
                Console.WriteLine(dayOfWeek);
            }

            client.Close();
        }
    }
}
