namespace Music.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using Music.Models;

    public class SongViewModel
    {
        public static Expression<Func<Song, SongViewModel>> FromSong
        {
            get
            {
                return s => new SongViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Genre = s.Genre,                    
                    Year = s.Year,
                    Album = s.Album.Title
                };
            }
        }

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
        public string Album { get; set; }
    }
}