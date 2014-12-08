namespace BugLogger.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugLogger.DataLayer.BugLoggerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugLoggerDbContext context)
        {
            if (context.Bugs.Any())
            {
                return;
            }

            context.Bugs.Add(new Bug
            {
                Status = DataLayer.Status.Pending,
                LogDate = DateTime.Now,
                Text = "Some bug 1"
            });           

            context.Bugs.Add(new Bug
            {
                Status = DataLayer.Status.Assigned,
                LogDate = DateTime.Now.AddDays(2),
                Text = "Some bug 2"
            });

            context.Bugs.Add(new Bug
            {
                Status = DataLayer.Status.Fixed,
                LogDate = DateTime.Now.AddDays(-5),
                Text = "Some bug 3"
            });

            context.Bugs.Add(new Bug
            {
                Status = DataLayer.Status.ForTesting,
                LogDate = DateTime.Now.AddDays(-1),
                Text = "Some bug 4"
            });

            context.Bugs.Add(new Bug
            {
                Status = DataLayer.Status.Pending,
                LogDate = DateTime.Now.AddDays(-1),
                Text = "Some bug 5"
            });

            context.Bugs.Add(new Bug
            {
                Status = DataLayer.Status.Fixed,
                LogDate = DateTime.Now.AddDays(-2),
                Text = "Some bug 6"
            });
        }
    }
}
