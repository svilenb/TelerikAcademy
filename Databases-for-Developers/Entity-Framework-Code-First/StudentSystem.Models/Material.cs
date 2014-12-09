namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Material
    {
        public int MaterialId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
