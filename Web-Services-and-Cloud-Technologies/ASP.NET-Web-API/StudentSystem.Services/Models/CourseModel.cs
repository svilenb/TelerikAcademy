namespace StudentSystem.Services.Models
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using StudentSystem.Models;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Students = c.Students.Select(s => (s.FirstName + " " + s.LastName))
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Name { get; set; }

        public IEnumerable<string> Students { get; set; }
    }
}