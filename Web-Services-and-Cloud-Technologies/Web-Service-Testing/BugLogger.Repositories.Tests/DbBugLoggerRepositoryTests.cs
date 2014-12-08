namespace BugLogger.Repositories.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Transactions;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using System.Data.Entity.Infrastructure;
    


    [TestClass]
    public class DbBugLoggerRepositoryTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Find_WhenObjectIsInDb_ShouldReturnObject()
        {
            var bug = this.GetValidTestBug();
            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            dbContext.Bugs.Add(bug);
            dbContext.SaveChanges();

            var bugInDb = repo.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void Find_WhenObjectIsNotInDb_ShouldReturnNull()
        {
            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            var bug = dbContext.Bugs.FirstOrDefault();
            int id = bug != null ? bug.Id : 1;
            if (bug != null)
            {
                var bugEntry = dbContext.Entry(bug);
                bugEntry.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }

            var bugInDb = repo.Find(id);

            Assert.IsNull(bugInDb);
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDb()
        {            
            var bug = GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            repo.Add(bug);
            repo.Save();

            var bugInDb = dbContext.Bugs.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddBug_WhenBugIsNotValid_ShouldThrowException()
        {
            var bug = GetInvalidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            repo.Add(bug);
            repo.Save();
        }

        [TestMethod]
        public void DeleteBug_WhenInDb_ShouldRemoveBug()
        {
            var bug = GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);

            repo.Add(bug);
            repo.Save();

            var bugInDb = dbContext.Bugs.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);

            repo.Delete(bug);
            repo.Save();

            bugInDb = dbContext.Bugs.Find(bug.Id);
            Assert.IsNull(bugInDb);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DeleteBug_WhenNotInDb_ShouldThrowExcetion()
        {
            var bug = GetValidTestBug();

            var dbContext = new BugLoggerDbContext();
            var repo = new DbBugsRepository(dbContext);
            
            repo.Delete(bug);
            repo.Save();
        }

        private Bug GetValidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test New bug",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            return bug;
        }

        private Bug GetInvalidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            return bug;
        }
    }
}
