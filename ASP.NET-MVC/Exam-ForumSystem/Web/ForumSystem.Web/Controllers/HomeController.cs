namespace ForumSystem.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Home;
    using System.Web;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using AutoMapper;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<Tag> tags;

        public HomeController(IDeletableEntityRepository<Post> posts, IDeletableEntityRepository<Tag> tags)
        {
            this.posts = posts;
            this.tags = tags;
        }

        public ActionResult Index()
        {
            var posts = this.posts.All().ToList();
            var model = posts.AsQueryable().Project().To<IndexBlogPostViewModel>().ToList();

            if (model == null)
            {
                throw new HttpException(404, "Ticket not found");
            }

            for (int i = 0; i < model.Count; i++)
            {
                model[i].Tags = posts[i].Tags.AsQueryable().Project().To<IndexTagViewModel>().ToList();
                model[i].Votes = posts[i].Votes.AsQueryable().Project().To<IndexVoteViewModel>().ToList();
            }

            return this.View(model);
        }

        public ActionResult Vote(IndexVoteViewModel vote)
        {
            var post = this.posts.GetById(vote.PostId);
            if (post == null)
            {
                throw new HttpException(404, "Post not found");
            }

            var previousVote = post.Votes.FirstOrDefault(v => v.UserId == this.User.Identity.GetUserId());
            if (previousVote == null)
            {
                var dbVote = new Vote()
                {
                    UserId = this.User.Identity.GetUserId(),
                    Value = vote.Value
                };

                post.Votes.Add(dbVote);
                this.posts.SaveChanges();

                Mapper.Map<IndexVoteViewModel, Vote>(vote, dbVote);
                return this.PartialView("_VotePartialView", vote);
            }
            else
            {
                previousVote.Value = vote.Value;
                this.posts.SaveChanges();
                Mapper.Map<IndexVoteViewModel, Vote>(vote, previousVote);
                return this.PartialView("_VotePartialView", vote);
            }
        }
    }
}