namespace _04.FindCustomersNativeSQL
{
    using System;
    using System.Linq;
    using EntityFrameworkDatabaseFirst;

    class FindCustomersNativeSQL
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities northwindentities = new NorthwindEntities())
            {
                ListCustomersByOrder(northwindentities, 1997, "Canada");
            }
        }

        private static void ListCustomersByOrder(NorthwindEntities northwindEntities, int year, string shipCountry)
        {
            string nativeSQLQuery = "SELECT cust.CompanyName " +
                                    "FROM Customers cust " +
                                        "INNER JOIN Orders ord " +
                                            "ON ord.CustomerID = cust.CustomerID " +
                                    "WHERE YEAR(ord.OrderDate) = {0} AND ord.ShipCountry = {1} ";

            object[] parameters = { year, shipCountry };

            var customers = northwindEntities.Database.SqlQuery<string>(nativeSQLQuery, parameters);

            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
