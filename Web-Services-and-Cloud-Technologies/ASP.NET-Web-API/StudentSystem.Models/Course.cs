namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
