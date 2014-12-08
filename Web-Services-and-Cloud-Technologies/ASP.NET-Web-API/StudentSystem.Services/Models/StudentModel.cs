namespace StudentSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using StudentSystem.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Courses = s.Courses.Select(c => c.Name)
                };
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public IEnumerable<string> Courses { get; set; }
    }
}