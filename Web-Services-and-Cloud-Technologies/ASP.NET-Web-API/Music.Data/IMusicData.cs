namespace Music.Data
{
    using Music.Data.Repositories;
    using Music.Models;

    public interface IMusicData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
