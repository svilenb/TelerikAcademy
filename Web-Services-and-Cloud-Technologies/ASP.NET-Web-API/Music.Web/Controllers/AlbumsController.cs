namespace Music.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Music.Data;
    using Music.Models;
    using Music.Web.Models;

    public class AlbumsController : BaseApiController
    {

        public AlbumsController()
            : this(new MusicData())
        {
        }

        public AlbumsController(IMusicData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums.All().Select(AlbumViewModel.FromAlbum);
            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumViewModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistId = this.data.Artists.All().FirstOrDefault(a => a.Name== album.Artist).Id;
            if (artistId == null)
            {
                return BadRequest("Such artist doesn't exist");
            }

            var newAlbum = new Album
            {
                ArtistId = artistId,
                Producer = album.Producer,
                Year = album.Year,
                Title = album.Title,                
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            album.Id = newAlbum.Id;
            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumViewModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such album does not exists!");
            }

            var artistId = this.data.Artists.All().FirstOrDefault(a => a.Name == album.Artist).Id;
            if (artistId == null)
            {
                return BadRequest("Such artist doesn't exist");
            }

            existingAlbum.ArtistId = artistId;
            existingAlbum.Producer = album.Producer;
            existingAlbum.Year = album.Year;
            existingAlbum.Title = album.Title;
            this.data.SaveChanges();

            album.Id = id;
            return Ok(album);
        }
    }
}
