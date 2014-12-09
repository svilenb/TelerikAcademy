namespace _05.FindSalesByRegionAndPeriod
{
    using System;
    using System.Linq;

    using EntityFrameworkDatabaseFirst;

    class FindSalesByRegionAndPeriod
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                ListSalesByRegionAndPeriod(northwindEntities, "Canada", new DateTime(1995, 10, 22), new DateTime(1998, 10, 22));
            }
        }

        private static void ListSalesByRegionAndPeriod(NorthwindEntities northwindEntites, string region, DateTime startDate, DateTime endDate)
        {
            var sales = northwindEntites.Orders
                .Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate && order.ShipCountry == region);

            foreach (var sale in sales)
            {
                Console.WriteLine("{0}   {1}   {2}", sale.OrderID, sale.OrderDate, sale.ShipCountry);
            }
        }
    }
}
