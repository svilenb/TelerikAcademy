namespace BugLogger.Repositories
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BugLogger.DataLayer;

    public class DbBugsRepository : IBugsReposity
    {
        private DbContext dbContext;
        private IDbSet<Bug> set;

        public DbBugsRepository(BugLoggerDbContext context)
        {
            this.dbContext = context;
            this.set = context.Set<Bug>();
        }

        public IQueryable<Bug> All()
        {
            return this.set.AsQueryable();
        }

        public Bug Add(Bug entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
            return entity;
        }

        public void Delete(Bug entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(Bug entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public Bug Find(int id)
        {
            return this.set.Find(id);
        }
       
        private DbEntityEntry AttachIfDetached(Bug entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
