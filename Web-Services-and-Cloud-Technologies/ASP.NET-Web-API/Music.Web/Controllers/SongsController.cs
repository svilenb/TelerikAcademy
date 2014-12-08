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

    public class SongsController : BaseApiController
    {
        public SongsController()
            : this(new MusicData())
        {
        }

        public SongsController(IMusicData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.data.Songs.All().Select(SongViewModel.FromSong);
            return Ok(songs);
        }

        [HttpPost]
        public IHttpActionResult Create(SongViewModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var albumId = this.data.Albums.All().FirstOrDefault(a => a.Title == song.Album).Id;
            if (albumId == null)
            {
                return BadRequest("Such album doesn't exist");
            }

            var newSong = new Song
            {
                Title = song.Title,
                Year = song.Year,
                AlbumId = albumId,
                Genre = song.Genre
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();

            song.Id = newSong.Id;
            return Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongViewModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSong = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (existingSong == null)
            {
                return BadRequest("Such song does not exists!");
            }

            var albumId = this.data.Albums.All().FirstOrDefault(a => a.Title == song.Album).Id;
            if (albumId == null)
            {
                return BadRequest("Such album doesn't exist");
            }

            existingSong.Title = song.Title;
            existingSong.Year = song.Year;
            existingSong.AlbumId = albumId;
            existingSong.Genre = song.Genre;
            this.data.SaveChanges();

            song.Id = id;
            return Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (existingSong == null)
            {
                return BadRequest("Such song does not exists!");
            }

            this.data.Songs.Delete(existingSong);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
