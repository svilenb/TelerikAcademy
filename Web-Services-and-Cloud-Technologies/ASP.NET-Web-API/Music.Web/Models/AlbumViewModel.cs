namespace Music.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Music.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class AlbumViewModel
    {
        public static Expression<Func<Album, AlbumViewModel>> FromAlbum
        {
            get
            {
                return a => new AlbumViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Year = a.Year,
                    Producer = a.Producer,
                    Songs = a.Songs.Select(s => s.Title),
                    Artist = a.Artist.Name
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
        public string Producer { get; set; }

        public virtual IEnumerable<string> Songs { get; set; }

        public virtual string Artist { get; set; }
    }
}