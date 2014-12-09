namespace _03.FindCustomersByOrders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EntityFrameworkDatabaseFirst;

    class FindCustomersByOrders
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                ListCustomersByOrder(northwindEntities, 1997, "Canada");
            }
        }

        private static void ListCustomersByOrder(NorthwindEntities northwindEntities, int year, string shipCountry)
        {
            var customers = northwindEntities.Customers.Join(
            northwindEntities.Orders,
            (customer => customer.CustomerID),
            (order => order.CustomerID),
            (customer, order) => new
            {
                CustomerName = customer.CompanyName,
                OrderDate = order.OrderDate,
                ShipCountry = order.ShipCountry
            }).Where(item => item.OrderDate.Value.Year == year &&
            item.ShipCountry == shipCountry).Distinct();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
