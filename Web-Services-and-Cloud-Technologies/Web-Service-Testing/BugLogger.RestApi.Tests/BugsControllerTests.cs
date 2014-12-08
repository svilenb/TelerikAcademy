namespace BugLogger.RestApi.Tests
{
    using System;
    using System.Data.Entity;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BugLogger.RestApi.Tests.Fakes;
    using BugLogger.RestApi.Controllers;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.JustMock;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3"
                }
            };

            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            //act

            var result = controller.GetAll();

            //assert

            CollectionAssert.AreEquivalent(bugs, result.ToList<Bug>());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            //arrange
            var repo = new FakeRepository<Bug>();
            repo.IsSaveCalled = false;
            repo.Entities = new List<Bug>();
            var bug = new Bug()
            {
                Text = "NEW TEST BUG"
            };
            var controller = new BugsController(repo);
            this.SetupController(controller);

            //act
            controller.PostBug(bug);

            //assert
            Assert.AreEqual(repo.Entities.Count, 1);
            var bugInDb = repo.Entities.First();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending, bugInDb.Status);
            Assert.IsTrue(repo.IsSaveCalled);
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsNotValid_ShoulReturnBadRequest()
        {
            //arrange
            var repo = new FakeRepository<Bug>();
            repo.IsSaveCalled = false;
            repo.Entities = new List<Bug>();
            var bug = new Bug()
            {
                Text = ""
            };

            var controller = new BugsController(repo);
            this.SetupController(controller);

            var response = controller.PostBug(bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsFalse(repo.IsSaveCalled);
        }

        [TestMethod]
        public void GetAfterDate_WhenValid_ShouldReturnBugsWithBiggerDate()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1",
                    LogDate = DateTime.Now,
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2",
                    LogDate = DateTime.Now.AddDays(-2)
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3",
                    LogDate = DateTime.Now.AddDays(-3)
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 4",
                    LogDate = DateTime.Now.AddDays(1),
                }
            };

            fakeRepo.Entities = bugs;
            var controller = new BugsController(fakeRepo as IRepository<Bug>);
            this.SetupController(controller);
            DateTime date = DateTime.Now;
            var response = controller.GetAfterDate(date).ExecuteAsync(CancellationToken.None).Result;
            var resultBugs = response.Content.ReadAsAsync<IEnumerable<Bug>>().Result.ToList();

            foreach (var bug in resultBugs)
            {
                Assert.IsTrue(bug.LogDate > date);
            }
        }

        [TestMethod]
        public void GetByStatus_WhenValid_ShouldReturnBugsWithGivenStatus()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3",
                    Status = Status.ForTesting
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 4",
                    Status = Status.Fixed
                }
            };

            fakeRepo.Entities = bugs;
            var controller = new BugsController(fakeRepo as IRepository<Bug>);
            this.SetupController(controller);
            Status status = Status.Pending;

            var response = controller.GetByStatus(status).ExecuteAsync(CancellationToken.None).Result;
            var resultBugs = response.Content.ReadAsAsync<IEnumerable<Bug>>().Result.ToList();

            foreach (var bug in resultBugs)
            {
                Assert.IsTrue(bug.Status == status);
            }
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMocks()
        {
            //arrange
            var repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs =
            {
                new Bug() { Text = "Bug1" },
                new Bug() { Text = "Bug2" }
            };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(repo);
            //act
            var result = controller.GetAll();

            //assert
            CollectionAssert.AreEquivalent(bugs, result.ToArray<Bug>());
        }

        [TestMethod]
        public void GetCount_WhenValid_ShouldReturnSpecificNumberOfBugs()
        {
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3",
                    Status = Status.ForTesting
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 4",
                    Status = Status.Fixed
                }
            };

            fakeRepo.Entities = bugs;
            var controller = new BugsController(fakeRepo as IRepository<Bug>);
            var result = controller.GetCount(2).ToList();
            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void Delete_WhenValidId_ShouldReduceBugsNumber()
        {
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Text = "TEST NEW BUG 1",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Id = 2,
                    Text = "TEST NEW BUG 2",
                    Status = Status.Pending
                },
                new Bug()
                {
                    Id = 3,
                    Text = "TEST NEW BUG 3",
                    Status = Status.ForTesting
                },
                new Bug()
                {
                    Id = 4,
                    Text = "TEST NEW BUG 4",
                    Status = Status.Fixed
                }
            };

            fakeRepo.Entities = bugs;
            var controller = new BugsController(fakeRepo as IRepository<Bug>);
            this.SetupController(controller);
            var result = controller.Delete(2);
            var bugsCount = controller.GetAll().Count();

            Assert.AreEqual(HttpStatusCode.OK, result.ExecuteAsync(CancellationToken.None).Result.StatusCode);
            Assert.AreEqual(3, bugsCount);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}