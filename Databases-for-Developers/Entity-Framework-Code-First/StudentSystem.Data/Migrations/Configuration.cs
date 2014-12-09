namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedStudents(context);
            this.SeedCourses(context);
            this.SeedMaterials(context);
            this.SeedHomeworks(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Number = "123456789",
            });

            context.Students.Add(new Student
            {
                FirstName = "Gosho",
                LastName = "spasov",
                Number = "123456788"
            });

            context.Students.Add(new Student
            {
                FirstName = "Stamat",
                LastName = "Stamatov",
                Number = "123456787"
            });

            context.Students.Add(new Student
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Number = "123456786"
            });

            context.SaveChanges();
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "Databases",
                Description = "In this course you will learn how to work with MSSQL, EntityFramework, MySQL, MongoDB ..."
            });

            context.Courses.Add(new Course
            {
                Name = "Data structures and algorithms",
                Description = "In this course you will learn to use proper data structures and write algorithms"
            });

            context.SaveChanges();
        }

        private void SeedMaterials(StudentSystemDbContext context)
        {
            if (context.Materials.Any())
            {
                return;
            }

            context.Materials.Add(new Material
                {
                    Content = "Entity-Framework.pptx",
                    CourseId = 1
                });

            context.Materials.Add(new Material
                {
                    Content = "Trees-and-Traversals.pptx",
                    CourseId = 2
                });
        }

        private void SeedHomeworks(StudentSystemDbContext context)
        {
            if (context.Homeworks.Any())
            {
                return;
            }

            context.Homeworks.Add(new Homework
                {
                    Content = "CodeFirst.zip",
                    StudentId = 1,
                    CourseId = 1,
                    TimeSent = new DateTime(2014, 06, 20)
                });

            context.Homeworks.Add(new Homework
            {
                Content = "LinearDataStructures.zip",
                StudentId = 2,
                CourseId = 2,
                TimeSent = new DateTime(2014, 07, 25)
            });
        }
    }
}
