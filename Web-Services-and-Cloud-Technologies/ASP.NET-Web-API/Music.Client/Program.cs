namespace Music.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:2586/") };

        static void Main(string[] args)
        {
            Client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine("Artists:");
            PrintArtists();
            Console.WriteLine("Albums:");
            PrintAlbums();
            Console.WriteLine("Songs:");
            PrintSongs();

            Artist artist = new Artist
            {
                Name = "Pesho",
                DateOfBirth = new DateTime(1990, 5, 4),
            };

            Album album = new Album
            {
                Artist = "Pesho",
                Producer = "Some producer",
                Title = "Pesho master",
                Year = 2014
            };

            Song song = new Song
            {
                Title = "Pesho song",
                Genre = "rock",
                Album = "Pesho master",
                Year = 2014
            };

            CreateArtist(artist);
            CreateAlbum(album);
            CreateSong(song);
            UpdateSong(1, song);
            UpdateAlbum(1, album);
            UpdateArtist(1, artist);
            DeleteSong(2);

            Console.WriteLine("After creating and updating\n");
            Console.WriteLine("Artists:");
            PrintArtists();
            Console.WriteLine("Albums:");
            PrintAlbums();
            Console.WriteLine("Songs:");
            PrintSongs();
        }

        private static void PrintArtists()
        {
            HttpResponseMessage response = Client.GetAsync("api/artists/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0} - {1} -> {2}", artist.Name, artist.DateOfBirth, string.Join(", ", artist.Albums));
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void PrintAlbums()
        {
            HttpResponseMessage response = Client.GetAsync("api/albums/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var album in albums)
                {
                    Console.WriteLine("{0} - {1} -> {2}", album.Title, album.Producer, string.Join(", ", album.Songs));
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void PrintSongs()
        {
            HttpResponseMessage response = Client.GetAsync("api/songs/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var song in songs)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", song.Title, song.Album, song.Year, song.Genre);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void CreateArtist(Artist artist)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(artist));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = Client.PostAsync("api/artists/create", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Artist created!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating artist");
            }
        }

        private static void CreateAlbum(Album album)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(album));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = Client.PostAsync("api/albums/create", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album created!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating album");
            }
        }

        private static void CreateSong(Song song)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(song));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = Client.PostAsync("api/songs/create", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Song created!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating song");
            }
        }

        private static void UpdateSong(int id, Song song)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(song));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = Client.PutAsync(string.Format("api/songs/update/{0}", id), postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Song updated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating song");
            }
        }

        private static void UpdateAlbum(int id, Album album)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(album));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = Client.PutAsync(string.Format("api/albums/update/{0}", id), postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album updated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating album");
            }
        }

        private static void UpdateArtist(int id, Artist artist)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(artist));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = Client.PutAsync(string.Format("api/artists/update/{0}", id), postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Artist updated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating artist");
            }
        }

        private static void DeleteSong(int id)
        {
            var response = Client.DeleteAsync(string.Format("api/songs/delete/{0}", id)).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Song deleted!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error deleting song");
            }
        }
    }
}
