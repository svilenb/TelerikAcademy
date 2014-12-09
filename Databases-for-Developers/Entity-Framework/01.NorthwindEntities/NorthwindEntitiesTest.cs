namespace _01.NorthwindEntities
{
    using System;    
    using System.Linq;
    using EntityFrameworkDatabaseFirst;

    class NorthwindEntitiesTest
    {
        static void Main(string[] args)
        {
            using(var nwDB = new NorthwindEntities())
            {
                var employees = nwDB.Employees.Select(emp => emp.FirstName);

                foreach (var emp in employees)
                {
                    Console.WriteLine(emp);
                }
            }
        }
    }
}
