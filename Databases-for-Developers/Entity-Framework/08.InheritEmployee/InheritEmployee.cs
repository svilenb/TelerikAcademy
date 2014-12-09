namespace _08.InheritEmployee
{
    using System;
    using System.Linq;

    using EntityFrameworkDatabaseFirst;

    class InheritEmployee
    {
        static void Main(string[] args)
        {
            // check the Extender.cs file in EntityFrameworkDatabaseFirst class library

            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var extended = northwindEntities.Employees.Find(1);

                foreach (var item in extended.EntityTerritories)
                {
                    Console.WriteLine("Teritory description - {0}", item.TerritoryDescription);
                }
            }
        }
    }
}
