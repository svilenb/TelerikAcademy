namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
            });

            context.Students.Add(new Student
            {
                FirstName = "Ivan",
                LastName = "Petrov",
            });

            context.Students.Add(new Student
            {
                FirstName = "Gosho",
                LastName = "Stamatov",
            });

            context.Students.Add(new Student
            {
                FirstName = "Stamat",
                LastName = "Georgiev",
            });
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
            });

            context.Courses.Add(new Course
            {
                Name = "Web services"
            });
        }
    }
}
