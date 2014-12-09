namespace _01.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Wintellect.PowerCollections;

    public class OrderedDictonaryStudents
    {
        public static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\students.txt");
            using (reader)
            {
                SortedDictionary<string, OrderedBag<Student>> students = new SortedDictionary<string, OrderedBag<Student>>();
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    var input = line.Split('|');
                    if (!students.ContainsKey(input[2].Trim()))
                    {
                        var grouped = new OrderedBag<Student>();
                        grouped.Add(new Student(input[0].Trim(), input[1].Trim()));
                        students.Add(input[2].Trim(), grouped);
                    }
                    else
                    {
                        students[input[2].Trim()].Add(new Student(input[0].Trim(), input[1].Trim()));
                    }
                }

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
