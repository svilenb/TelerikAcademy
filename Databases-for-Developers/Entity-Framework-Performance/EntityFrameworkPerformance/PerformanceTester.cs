namespace EntityFrameworkPerformance
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    class PerformanceTester
    {
        static void Main(string[] args)
        {
            // Task 1.
            PrintEmployeesBothWays();

            // Task 2.
            CheckPerformanceWithToList();
        }

        private static void PrintEmployeesBothWays()
        {
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                // calling this to connect to database before making measurements
                context.Departments.Count();
                Stopwatch stopwatch = new Stopwatch();
                StringBuilder result = new StringBuilder();
                stopwatch.Start();
                foreach (var employee in context.Employees)
                {
                    result.AppendLine(string.Format("{0} {1}", employee.FirstName, employee.LastName));
                    result.AppendLine(string.Format("{0}", employee.Department.Name));
                    result.AppendLine(string.Format("{0}", employee.Address.Town.Name));
                }

                stopwatch.Stop();
                var timeForSlowWay = stopwatch.Elapsed;
                Console.WriteLine(result);
                result.Clear();
                stopwatch.Restart();
                foreach (var employee in context.Employees.Include("Address.Town").Include("Department"))
                {
                    result.AppendLine(string.Format("{0} {1}", employee.FirstName, employee.LastName));
                    result.AppendLine(string.Format("{0}", employee.Department.Name));
                    result.AppendLine(string.Format("{0}", employee.Address.Town.Name));
                }

                stopwatch.Stop();
                Console.WriteLine(result);
                Console.WriteLine("Task 1:");
                Console.WriteLine("Elapsed time without Include: {0}", timeForSlowWay);
                Console.WriteLine("Elapsed time with Include: {0}", stopwatch.Elapsed);
            }
        }

        private static void CheckPerformanceWithToList()
        {
            Console.WriteLine("Task 2:");
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                // calling this to connect to database before making measurements
                context.Departments.Count();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var townsSlowWay = context.Employees.ToList()
                                          .Select(e => e.Address).ToList()
                                          .Select(a => a.Town).ToList()
                                          .Where(t => t.Name == "Sofia");

                foreach (var town in townsSlowWay)
                {
                    Console.WriteLine(town.Name);
                }

                stopwatch.Stop();
                Console.WriteLine("Elapsed time with many ToLists: {0}", stopwatch.Elapsed);
                stopwatch.Restart();
                var townsFastWay = context.Employees
                                                   .Select(e => e.Address)
                                                   .Select(a => a.Town)
                                                   .Where(t => t.Name == "Sofia");

                foreach (var town in townsFastWay)
                {
                    Console.WriteLine(town.Name);
                }

                stopwatch.Stop();
                Console.WriteLine("Elapsed time when optimized: {0}", stopwatch.Elapsed);
            }
        }
    }
}
