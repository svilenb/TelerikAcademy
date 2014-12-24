namespace ForumSystem.Data.Common.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        DbContext Context { get; set; }

        int SaveChanges();
    }
}
