namespace _10.UsingStoredProcedure
{
    using System;
    using System.Linq;

    using EntityFrameworkDatabaseFirst;

    class UsingStoredProcedure
    {
        /*
        CREATE PROC usp_GetTotalIncome(@supplierName nvarchar, @startDate date, @endDate date)
        AS
	        SELECT SUM(od.UnitPrice) FROM [Order Details] od
		        JOIN Orders o ON od.OrderID = o.OrderID
		        JOIN Products p ON od.ProductID = p.ProductID
		        JOIN Suppliers s ON p.SupplierID = s.SupplierID
	        WHERE (o.ShippedDate BETWEEN @startDate AND @endDate) AND s.CompanyName = @supplierName
        GO*/

        static void Main(string[] args)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var supplierName = "Grandma Kelly's Homestead";
                var totalIncome = GetTotalIncomes(supplierName, new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));
                Console.WriteLine("Supplier name: {0}, income: {1}", supplierName, totalIncome);
            }
        }

        private static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (NorthwindEntities northwindEntites = new NorthwindEntities())
            {
                var income = northwindEntites.usp_GetTotalIncome(supplierName, startDate, endDate).First();
                return income;
            }
        }
    }
}
