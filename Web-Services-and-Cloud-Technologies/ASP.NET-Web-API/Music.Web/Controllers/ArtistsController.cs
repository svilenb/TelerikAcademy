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

    public class ArtistsController : BaseApiController
    {
        public ArtistsController()
            : this(new MusicData())
        {
        }

        public ArtistsController(IMusicData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data.Artists.All().Select(ArtistViewModel.FromArtist);

            return Ok(artists);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistViewModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var newArtist = new Artist
            {
                Name = artist.Name,
                DateOfBirth = artist.DateOfBirth,
            };

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artist.Id = newArtist.Id;
            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistViewModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existringArtist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (existringArtist == null)
            {
                return BadRequest("Such artist does not exists!");
            }


            existringArtist.Name = artist.Name;
            existringArtist.DateOfBirth = artist.DateOfBirth;
            this.data.SaveChanges();

            artist.Id = id;
            return Ok(artist);
        }
    }
}
