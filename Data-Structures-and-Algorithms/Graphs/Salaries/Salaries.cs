using System;

class Salaries
{
    private const int maxEmployees = 50;
    private static int employeesCount;
    private static bool[,] adjMatrix;
    private static long[] cache = new long[maxEmployees];

    static void Main(string[] args)
    {
        employeesCount = int.Parse(Console.ReadLine());
        adjMatrix = new bool[employeesCount, employeesCount];
        for (int i = 0; i < employeesCount; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                adjMatrix[i, j] = (line[j] == 'Y');
            }
        }

        long salariesSum = new long();
        for (int i = 0; i < employeesCount; i++)
        {
            salariesSum += FindSalary(i);
        }

        Console.WriteLine(salariesSum);
    }

    private static long FindSalary(int employee)
    {
        if (cache[employee] > 0)
        {
            return cache[employee];
        }

        long salary = 0;
        for (int i = 0; i < employeesCount; i++)
        {
            if (adjMatrix[employee, i])
            {
                salary += FindSalary(i);
            }
        }

        if (salary == 0)
        {
            salary = 1;
        }

        cache[employee] = salary;
        return salary;
    }
}

