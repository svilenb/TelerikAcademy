namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Music.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicDbContext context)
        {
            this.SeedArtists(context);
            this.SeedAlbums(context);
            this.SeedSongs(context);
        }

        private void SeedArtists(MusicDbContext context)
        {
            if (context.Artists.Any())
            {
                return;
            }

            context.Artists.Add(new Artist
             {
                 Name = "Michael Jackson",
                 DateOfBirth = new DateTime(1958, 8, 29)                 
             });

            context.Artists.Add(new Artist
            {
                Name = "Madonna",
                DateOfBirth = new DateTime(1958, 8, 16)
            });

            context.SaveChanges();
        }

        private void SeedAlbums(MusicDbContext context)
        {
            if (context.Albums.Any())
            {
                return;
            }

            context.Albums.Add(new Album
            {
                Title = "Bad",
                Producer = "Epic Records",
                Year = 1987,
                ArtistId = 1
            });

            context.Albums.Add(new Album
            {
                Title = "Thriller",
                Producer = "Quincy Jones",
                Year = 1982,
                ArtistId = 1
            });

            context.Albums.Add(new Album
            {
                Title = "American Lifer",
                Producer = "Warner Bros.",
                Year = 2000,
                ArtistId = 2
            });

            context.SaveChanges();
        }

        private void SeedSongs(MusicDbContext context)
        {
            if (context.Songs.Any())
            {
                return;
            }

            context.Songs.Add(new Song
            {
                Title = "Smooth Criminal",
                AlbumId = 1,
                Year = 1987,
                Genre = "dance-pop"
            });

            context.Songs.Add(new Song
            {
                Title = "Dirty Diana",
                AlbumId = 1,
                Year = 1985,
                Genre = "pop rock"
            });

            context.Songs.Add(new Song
            {
                Title = "Billie Jean",
                AlbumId = 2,
                Year = 1982,
                Genre = "Post-disco"
            });

            context.Songs.Add(new Song
            {
                Title = "Thriller",
                AlbumId = 2,
                Year = 1982,
                Genre = "Disco"
            });

            context.Songs.Add(new Song
            {
                Title = "Die Another Day",
                AlbumId = 3,
                Year = 2002,
                Genre = "Electroclash"
            });

            context.Songs.Add(new Song
            {
                Title = "Hollywood",
                AlbumId = 3,
                Year = 2002,
                Genre = "dance-pop"
            });
        }
    }
}
