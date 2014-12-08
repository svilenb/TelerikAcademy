namespace Music.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using Music.Models;
    using System.ComponentModel.DataAnnotations;

    public class ArtistViewModel
    {
        public static Expression<Func<Artist, ArtistViewModel>> FromArtist
        {
            get
            {
                return a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Albums = a.Albums.Select(x => x.Title)
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<string> Albums { get; set; }
    }
}