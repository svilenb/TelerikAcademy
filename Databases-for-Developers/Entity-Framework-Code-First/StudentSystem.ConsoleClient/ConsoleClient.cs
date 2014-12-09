namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;    

    public class ConsoleClient
    {
        static void Main(string[] args)
        {
            //You may need to change the data source of the connection string in the App.cofig file because I am using .\SQLEXPRESS!!!
            var data = new StudentSystemData();

            while (true)
            {
                Console.WriteLine("Enter 1 to list all students\n 2 to list all courses\n 3 to list all materials\n 4 to list all homeworks\n exit to exit the program");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        var students = data.Students.All();
                        foreach (var student in students)
                        {
                            Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Number);
                        }

                        break;
                    case "2":
                        var courses = data.Courses.All();
                        foreach (var course in courses)
                        {
                            Console.WriteLine(course.Name);
                            Console.WriteLine(course.Description);
                        }

                        break;
                    case "3":
                        var materials = data.Materials.All();
                        foreach (var material in materials)
                        {
                            Console.WriteLine(material.Content + " " + material.Course.Name);
                        }

                        break;
                    case "4":
                        var homeworks = data.Homeworks.All();
                        foreach (var homework in homeworks)
                        {
                            Console.WriteLine(homework.Content + " " + homework.TimeSent);
                        }

                        break;
                    case "exit":
                        Console.WriteLine("Goodbye");
                        return;
                    default:
                        Console.WriteLine("Unknown comand");
                        break;
                }
            }
        }
    }
}
