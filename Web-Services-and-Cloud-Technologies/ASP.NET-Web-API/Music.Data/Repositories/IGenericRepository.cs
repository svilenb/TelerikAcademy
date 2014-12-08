namespace Music.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();        

        void Add(T entity);

        T Find(object id);  

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        void Detach(T entity);

        void SaveChanges();
    }
}
