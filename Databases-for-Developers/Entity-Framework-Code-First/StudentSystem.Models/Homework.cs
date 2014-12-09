namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public int HomeworkId { get; set; }

        [MinLength(5)]
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }
        
        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
