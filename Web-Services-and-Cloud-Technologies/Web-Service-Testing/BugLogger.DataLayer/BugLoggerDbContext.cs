namespace BugLogger.DataLayer
{    
    using System.Data.Entity;
    using BugLogger.DataLayer.Migrations;

    public class BugLoggerDbContext : DbContext, IBugLoggerDbContext
    {
        public BugLoggerDbContext()
            : base("BugLoggerDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
