namespace Music.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Genre { get; set; }

        [Required]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
