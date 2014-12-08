namespace BugLogger.RestApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Policy;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using BugLogger.DataLayer;
    using BugLogger.Repositories;

    public class BugsController : ApiController
    {
        private IRepository<Bug> repo;

        public BugsController()
            : this(new DbBugsRepository(new BugLoggerDbContext()))
        {
        }

        public BugsController(IRepository<Bug> repository)
        {
            this.repo = repository;
        }

        [EnableCors("*", "*", "*")]
        public IQueryable<Bug> GetAll()
        {
            var bugs = this.repo.All();
            return bugs;
        }

        public IHttpActionResult GetAfterDate(DateTime date)
        {
            var bugs = this.repo.All().Where(b => b.LogDate > date);
            return Ok(bugs);
        }

        public IHttpActionResult GetByStatus(Status type)
        {
            var bugs = this.repo.All().Where(b => b.Status == type);
            return Ok(bugs);
        }

        public IQueryable<Bug> GetCount(int count)
        {
            return this.GetAll()
                    .Take(count);
        }

        [HttpPut]
        public IHttpActionResult ChangeBugStatus(int id, Status status)
        {
            var existingBug = this.repo.All().FirstOrDefault(a => a.Id == id);
            if (existingBug == null)
            {
                return BadRequest("Such bug does not exists!");
            }

            existingBug.Status = status;
            this.repo.Save();
            return Ok(existingBug);
        }

        public HttpResponseMessage PostBug(Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid model state");
            }

            if (string.IsNullOrEmpty(bug.Text))
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Text cannot bu null or empty");
            }

            bug.LogDate = DateTime.Now;
            bug.Status = Status.Pending;
            this.repo.Add(bug);
            this.repo.Save();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.Id }));
            return response;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingBug = this.repo.All().FirstOrDefault(a => a.Id == id);
            if (existingBug == null)
            {
                return BadRequest("Such bug does not exists!");
            }

            this.repo.Delete(existingBug);
            this.repo.Save();
            return Ok();
        }
    }
}
