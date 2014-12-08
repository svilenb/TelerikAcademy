namespace Music.Data
{
    using System.Data.Entity;

    using Music.Models;
    using Music.Data.Migrations;

    class MusicDbContext : DbContext, IMusicDbContext
    {
        public MusicDbContext()
            : base("MusicConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicDbContext, Configuration>());
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
