namespace Music.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Music.Data.Repositories;
    using Music.Models;

    public class MusicData : IMusicData
    {
        private IMusicDbContext context;
        private IDictionary<Type, object> repositories;

        public MusicData()
            :this(new MusicDbContext())
        {
        }

        public MusicData(IMusicDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IGenericRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IGenericRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
