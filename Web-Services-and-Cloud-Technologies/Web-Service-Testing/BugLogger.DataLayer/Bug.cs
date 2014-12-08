namespace BugLogger.DataLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Text { get; set; }

        public DateTime? LogDate { get; set; }
    }
}
