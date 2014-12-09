namespace _07.ConcurrentChanges
{
    using System;

    using EntityFrameworkDatabaseFirst;

    class ConcurrentChanges
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities northwindEntities1 = new NorthwindEntities())
            {
                using (NorthwindEntities northwindEntities2 = new NorthwindEntities())
                {
                    Employee employeeFirstDataContext = northwindEntities1.Employees.Find(1);
                    employeeFirstDataContext.FirstName = "Pesho";

                    // It works better when we move northwindEntities1.SaveChanges() here                    
                    Employee emmployeeSecondDataContext = northwindEntities2.Employees.Find(1);
                    emmployeeSecondDataContext.FirstName = "Gosho";

                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();
                }
            }

            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var employee = northwindEntities.Employees.Find(1);
                Console.WriteLine("the name of the employee with id: {0} is: {1}", 1, employee.FirstName);
            }
        }
    }
}
