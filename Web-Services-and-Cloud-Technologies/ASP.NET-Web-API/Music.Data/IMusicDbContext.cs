namespace Music.Data
{    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Music.Models;

    public interface IMusicDbContext
    {
        IDbSet<Artist> Artists { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<Album> Albums { get; set; }

        void SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
